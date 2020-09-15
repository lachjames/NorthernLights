using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Microsoft.CSharp;
using System.Linq;

namespace AuroraEngine
{
	public partial class AuroraModel
	{
		private Game importFrom;

        public MDL mdlObject;

		public AuroraModel(Stream mdlStream, Stream mdxStream, Game importFrom)
		{
			this.importFrom = importFrom;
            mdlObject = new MDL();
            Dictionary<string, Stream> other = new Dictionary<string, Stream>
            {
                { "mdl", mdlStream },
                { "mdx", mdxStream }
            };
            mdlObject.Load(mdlStream, other);
        }

        public AnimationClip[] GetUnityAnimationClips(Dictionary<string, GameObject> modelCache, Dictionary<int, (GameObject, MDLNode)> nodeInts)
		{
			AnimationClip[] clips = new AnimationClip[mdlObject.animations.Length];

			for (int i = 0; i < mdlObject.animations.Length; i++) {
				clips[i] = new AnimationClip();
				clips[i].name = mdlObject.animations[i].animationHeader.geometryHeader.modelName.ToLower();
                clips[i].legacy = true;         //have to set this flag to use the legacy animation component unless someone can figure out how to procedurally generate animations for mecanim

                SetAnimationClip(mdlObject.animations[i].rootNode, nodeInts, clips[i]);
            }


            List<AnimationClip> superclips = new List<AnimationClip>();
            // If there is a supermodel, add its animations too
            if (mdlObject.supermodelName != "NULL")
            {
                if (!modelCache.ContainsKey(mdlObject.supermodelName))
                {
                    modelCache[mdlObject.supermodelName] = Resources.LoadModel(mdlObject.supermodelName);
                }
                UnityEngine.Animation superanim = modelCache[mdlObject.supermodelName].GetComponent<UnityEngine.Animation>();

                foreach (AnimationState x in superanim)
                {
                   superclips.Add(x.clip);
                }
            }

            return clips.Concat(superclips).ToArray();
		}

        /// <summary>
        /// Take an empty animation clip and recursively add the curves for each mesh node that it affects
        /// </summary>
        private void SetAnimationClip(MDLNode node, Dictionary<int, (GameObject, MDLNode)> nodeInts, AnimationClip clip, string relativePath = "", bool isRoot = true)
        {
            GameObject parentObj = null;
            MDLNode parent = null;
            //if (node.nodeHeader.supernode < nodeInts.Count())
            //{
            //    (parentObj, parent) = nodeInts[node.nodeHeader.supernode];
            //}
            //else
            //{
            //    (parentObj, parent) = nodeInts[node.nodeHeader.nodeNumber];
            //}

            if (nodeInts.ContainsKey(node.nodeHeader.nodeNumber))
            {
                (parentObj, parent) = nodeInts[node.nodeHeader.nodeNumber];
            }
            else if (nodeInts.ContainsKey(node.nodeHeader.supernode))
            {
                (parentObj, parent) = nodeInts[node.nodeHeader.supernode];
            }
            else
            {
                // Seems some models are broken?
                parentObj = new GameObject();
            }

            //Debug.Log(node.nodeHeader.controllers.Length + ", " + node.nodeHeader.controllerData.Length);
            for (int c = 0; c < node.nodeHeader.controllers.Length; c++)
            {
                Controller controller = node.nodeHeader.controllers[c];
                ControllerData cData = node.nodeHeader.controllerData[c];

                int frames = controller.dataRowCount;
                int cols = controller.columnCount;
                int rows = cData.data.Length;
                //Debug.Log("Frames: " + frames + ", cols: " + cols + ", rows: " + rows);

                bool isBezier = false;

                switch (controller.controllerType)
                {
                    case 8: // Position
                        Keyframe[] curveXFrames = new Keyframe[frames];
                        Keyframe[] curveYFrames = new Keyframe[frames];
                        Keyframe[] curveZFrames = new Keyframe[frames];

                        //position animation vectors are relative to the object's initial position
                        //also need to invert the y and z axes to convert to unity coordinates
                        for (int f = 0; f < frames; f++)
                        {
                            if (cols == 1)
                            {
                                curveXFrames[f] = new Keyframe(cData.times[f], cData.data[f][0]);
                                curveYFrames[f] = new Keyframe(cData.times[f], cData.data[f][0]);
                                curveZFrames[f] = new Keyframe(cData.times[f], cData.data[f][0]);
                            }
                            else if (cols == 3)
                            {
                                //Debug.Log(cData.data.Count() + ", " + f);
                                curveXFrames[f] = new Keyframe(cData.times[f], cData.data[f][0] + parentObj.transform.localPosition.x);
                                curveYFrames[f] = new Keyframe(cData.times[f], cData.data[f][2] + parentObj.transform.localPosition.y);
                                curveZFrames[f] = new Keyframe(cData.times[f], cData.data[f][1] + parentObj.transform.localPosition.z);
                            }
                            else
                            {
                                isBezier = true;
                                Vector3[] bezier = new Vector3[] {
                                    new Vector3(
                                        cData.data[f][0],
                                        cData.data[f][1],
                                        cData.data[f][2]
                                    ),
                                    new Vector3(
                                        cData.data[f][3],
                                        cData.data[f][4],
                                        cData.data[f][5]
                                    ),
                                    new Vector3(
                                        cData.data[f][6],
                                        cData.data[f][7],
                                        cData.data[f][8]
                                    ),
                                };

                                // TODO: Do something with the bezier curves...
                                curveXFrames[f] = new Keyframe(cData.times[f], cData.data[f][0] + parentObj.transform.localPosition.x);
                                curveYFrames[f] = new Keyframe(cData.times[f], cData.data[f][2] + parentObj.transform.localPosition.y);
                                curveZFrames[f] = new Keyframe(cData.times[f], cData.data[f][1] + parentObj.transform.localPosition.z);
                            }
                            //Debug.Log("Created frame: " +
                            //    curveXFrames[f].time + ": " + curveXFrames[f].value +
                            //    curveYFrames[f].time + ": " + curveYFrames[f].value +
                            //    curveZFrames[f].time + ": " + curveZFrames[f].value
                            //);
                        }

                        AnimationCurve curveX = new AnimationCurve(curveXFrames);
                        AnimationCurve curveY = new AnimationCurve(curveYFrames);
                        AnimationCurve curveZ = new AnimationCurve(curveZFrames);

                        clip.SetCurve(relativePath, typeof(Transform), "m_LocalPosition.x", curveX);
                        clip.SetCurve(relativePath, typeof(Transform), "m_LocalPosition.y", curveY);
                        clip.SetCurve(relativePath, typeof(Transform), "m_LocalPosition.z", curveZ);
                        
                        break;
                    case 20: // Orientation
                        Keyframe[] rcurveXFrames = new Keyframe[frames];
                        Keyframe[] rcurveYFrames = new Keyframe[frames];
                        Keyframe[] rcurveZFrames = new Keyframe[frames];
                        Keyframe[] rcurveWFrames = new Keyframe[frames];

                        // position animation vectors are relative to the object's initial position
                        // also need to invert the y and z axes to convert to unity coordinates
                        for (int f = 0; f < frames; f++)
                        {
                            rcurveXFrames[f] = new Keyframe(cData.times[f], -cData.data[f][0]); //- node.nodeHeader.rotation[1]);
                            rcurveYFrames[f] = new Keyframe(cData.times[f], -cData.data[f][2]); //- node.nodeHeader.rotation[2]);
                            rcurveZFrames[f] = new Keyframe(cData.times[f], -cData.data[f][1]); //- node.nodeHeader.rotation[1]);
                            rcurveWFrames[f] = new Keyframe(cData.times[f], cData.data[f][3]); //- node.nodeHeader.rotation[3]);
                        }

                        AnimationCurve rcurveX = new AnimationCurve(rcurveXFrames);
                        AnimationCurve rcurveY = new AnimationCurve(rcurveYFrames);
                        AnimationCurve rcurveZ = new AnimationCurve(rcurveZFrames);
                        AnimationCurve rcurveW = new AnimationCurve(rcurveWFrames);

                        clip.SetCurve(relativePath, typeof(Transform), "m_LocalRotation.x", rcurveX);
                        clip.SetCurve(relativePath, typeof(Transform), "m_LocalRotation.y", rcurveY);
                        clip.SetCurve(relativePath, typeof(Transform), "m_LocalRotation.z", rcurveZ);
                        clip.SetCurve(relativePath, typeof(Transform), "m_LocalRotation.w", rcurveW);
                        break;
                    default:
                        //Debug.LogError("Have not implemented curve of type " + node.curves[c].type + " for node " + node.name);
                        break;
                }
            }

            if (relativePath != "")
            {
                relativePath += "/";
            }
            
            for (int i = 0; i < node.childNodes.Length; i++)
            {
                int idx = node.childNodes[i].nodeHeader.nodeNumber;
                string name = idx < mdlObject.nameHeader.names.Length ? mdlObject.nameHeader.names[idx].name : "";
                SetAnimationClip(node.childNodes[i], nodeInts, clip, relativePath + name.ToLower(), false);
            }
        }
    }
}