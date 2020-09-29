using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace AuroraEngine
{
    public static partial class Resources
    {
        static StateSystem manager;
        static Resources () {
            manager = GameObject.Find("State System").GetComponent<StateSystem>();
        }

        static Dictionary<string, GameObject> modelCache = new Dictionary<string, GameObject>();

        static Mesh CreateUnityMesh(MDLNode node)
        {
            Mesh mesh = new Mesh();

            mesh.SetVertices(new List<Vector3>(node.vertices));
            mesh.SetTriangles(new List<int>(node.faces), 0);
            //mesh.SetNormals(new List<Vector3>(node.tVertices));
            if (node.uvs.Length >= 1)
            {
                mesh.SetUVs(0, new List<Vector2>(node.uvs[0]));
            }
            if (node.uvs.Length >= 2)
            {
                mesh.SetUVs(1, new List<Vector2>(node.uvs[1]));
            }
            if (node.uvs.Length >= 3)
            {
                mesh.SetUVs(2, new List<Vector2>(node.uvs[2]));
            }
            if (node.uvs.Length >= 4)
            {
                mesh.SetUVs(3, new List<Vector2>(node.uvs[3]));
            }

            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            mesh.RecalculateTangents();

            if (node.skinmeshHeader != null)
            {
                BoneWeight[] weights = new BoneWeight[node.vertices.Length];

                // This node needs weights
                for (int i = 0; i < node.vertices.Length; i++)
                {
                    if (node.weights[i][0] == 0)
                    {
                        throw new System.Exception("Invalid zero weight detected");
                    }
                    
                    weights[i] = new BoneWeight
                    {
                        weight0 = node.weights[i][0],
                        weight1 = node.weights[i][1],
                        weight2 = node.weights[i][2],
                        weight3 = node.weights[i][3],
                        boneIndex0 = node.weightIdxs[i][0],
                        boneIndex1 = node.weightIdxs[i][1] == -1 ? 0 : node.weightIdxs[i][1],
                        boneIndex2 = node.weightIdxs[i][2] == -1 ? 0 : node.weightIdxs[i][2],
                        boneIndex3 = node.weightIdxs[i][3] == -1 ? 0 : node.weightIdxs[i][3]
                    };

                    //Debug.Log(weights[i]);
                }

                mesh.boneWeights = weights;
            }

            //mesh.Optimize();

            return mesh;
        }

        static GameObject CreateObject(MDLNode node, NodeName[] names, Transform parent,
            Dictionary<int, (GameObject, MDLNode)> nodeIdx, Dictionary<string, (GameObject, MDLNode)> nodeStr,
            string cubemap, AuroraObject obj)
        {
            GameObject go = new GameObject();

            if (parent)
            {
                go.transform.SetParent(parent, false);
            }

            go.transform.localPosition = new Vector3(
                node.nodeHeader.position[0],
                node.nodeHeader.position[2],
                node.nodeHeader.position[1]
            );
            go.transform.localRotation = new Quaternion(
                -node.nodeHeader.rotation[1],
                -node.nodeHeader.rotation[3],
                -node.nodeHeader.rotation[2],
                node.nodeHeader.rotation[0]
            );

            go.name = node.nodeHeader.nodeNumber < names.Length ? names[node.nodeHeader.nodeNumber].name : "";
            go.name = go.name.ToLower();
            nodeIdx[node.nodeHeader.nodeNumber] = (go, node);
            nodeStr[go.name] = (go, node);

            if (go.name == "camerahook")
            {
                go.tag = "CameraHook";
            }
            else if (go.name == "lookathook" || go.name == "freelookhook")
            {
                go.tag = "LookAtHook";
                SphereCollider sc = go.AddComponent<SphereCollider>();
                sc.radius = 0.2f;
                go.AddComponent<LookAtHook>().obj = obj;
            }

            CreateTrimesh(node, go, cubemap);
            CreateLight(node, go);
            CreateEmitter(node, go);
            CreateReference(node, go);

            //Debug.Log("Creating " + node.childNodes.Length + " child nodes");
            for (int i = 0; i < node.childNodes.Length; i++)
            {
                CreateObject(node.childNodes[i], names, go.transform, nodeIdx, nodeStr, cubemap, obj);
            }

            return go;
        }


        static Material CreateMaterial (MDLNode node, string cubemap)
        {
            Material mat = LoadMaterial(node.trimeshHeader.textureName, node.trimeshHeader.lightmapName, cubemap);
            Color emissive = new Color(
                node.meshParameters.selfIllumColor.r * node.trimeshHeader.diffuseColor[0],
                node.meshParameters.selfIllumColor.g * node.trimeshHeader.diffuseColor[1],
                node.meshParameters.selfIllumColor.b * node.trimeshHeader.diffuseColor[2],
                node.meshParameters.alpha
            );

            if (emissive.r == 0 && emissive.g == 0 && emissive.b == 0)
            {

            }
            else
            {
                // Node is self-illuminated
                mat.EnableKeyword("_EMISSION");
                mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
                mat.SetColor("_EmissionColor", emissive);
            }

            mat.SetFloat("_Metallic", 0.5f);

            if (cubemap != null)
            {
                // This material is reflective - we don't actually use cubemaps, but instead use reflection probes
                // (because it looks WAY better)
                mat.SetFloat("_Metallic", 1f);
                mat.SetFloat("_Glossiness", 0.9f);
            } else
            {
                //mat.SetFloat("_Metallic", 0.2f);
                mat.SetFloat("_Glossiness", 0f);
            }

            return mat;
        }

        static void CreateTrimesh (MDLNode node, GameObject go, string cubemap)
        {
            if (node.trimeshHeader == null)
            {
                return;
            }
            Mesh mesh = CreateUnityMesh(node);

            MeshCollider col = go.AddComponent<MeshCollider>();
            col.cookingOptions = MeshColliderCookingOptions.None;

            go.AddComponent<MeshFilter>().sharedMesh = mesh;

            col.sharedMesh = mesh;

            //meshes with a NULL texture should be invisible
            if (node.trimeshHeader.textureName != "NULL")
            {
                //Debug.Log("Loading texture " + node.trimeshHeader.textureName);
                if (node.skinmeshHeader == null)
                {
                    MeshRenderer r = go.AddComponent<MeshRenderer>();
                    r.material = CreateMaterial(node, cubemap);
                    //Material mat = new Material(Shader.Find("Standard"));


                    //// TODO: Set specular color
                    ////mat.SetColor("_SpecColor", node.trimeshHeader.)

                    //Texture2D tDiffuse = LoadTexture2D(node.trimeshHeader.textureName);
                    //if (tDiffuse)
                    //{
                    //    mat.SetTexture("_MainTex", tDiffuse);
                    //}

                    //// Set the light map details
                    //Texture2D tLightmap;
                    //if (node.trimeshHeader.lightmapName != null && (tLightmap = LoadTexture2D(node.trimeshHeader.lightmapName)))
                    //{
                    //    mat.SetTexture("_LightMap", tLightmap);
                    //}

                    //r.material = mat;

                }
            }
        }

        public static void CreateLight (MDLNode node, GameObject go)
        {
            if (node.lightHeader == null)
            {
                return;
            }

            Light light = go.AddComponent<Light>();

            // TODO: Is 200 a good number?
            if (node.lightParameters.radius > 200)
            {
                // Make it a directional light
                light.type = LightType.Directional;
                
                // Directional light intensity is a bit much in Unity
                light.intensity = 0.5f;
                
                // Make it point to the origin
                light.transform.LookAt(Vector3.zero);
            }
            else
            {
                // Make it a point light
                light.type = LightType.Point;

                // Lights are a bit too bright here
                light.intensity = Mathf.Clamp(node.lightParameters.multiplier, 0f, 3f);
                light.range = node.lightParameters.radius;
            }

            light.color = node.lightParameters.color;
            light.shadows = LightShadows.Soft;
        }

        public static void CreateEmitter (MDLNode node, GameObject go)
        {
            if (node.emitterHeader == null)
            {
                return;
            }
            Debug.Log("Creating emitter with " +
                "texture " + node.emitterHeader.texture +
                "blast radius " + node.emitterHeader.blastRadius +
                "size start " + node.emitterParameters.sizeStart +
                "size end " + node.emitterParameters.sizeEnd +
                "texture " + node.emitterHeader.texture
            );

            //AuroraEmitter emitter = go.AddComponent<AuroraEmitter>();
            //emitter.header = node.emitterHeader;
            //emitter.emitterParameters = node.emitterParameters;

            //emitter.mat = LoadParticleMaterial(node.emitterHeader.texture);
        }

        public static void CreateReference(MDLNode node, GameObject go)
        {
            if (node.referenceHeader == null)
            {
                return;
            }
            Debug.Log("Creating reference to " + node.referenceHeader.refModel);
        }

        static GameObject CreateBones(MDLNode node, NodeName[] names, Transform parent,
            Dictionary<int, (GameObject, MDLNode)> nodeIdx, Dictionary<string, (GameObject, MDLNode)> nodeStr, Dictionary<GameObject, GameObject> bones,
            string cubemap)
        {
            (GameObject go, _) = nodeIdx[node.nodeHeader.nodeNumber];
            if (node.trimeshHeader != null)
            {
                //meshes with a NULL texture should be invisible
                if (node.trimeshHeader.textureName != "NULL")
                {
                    //Debug.Log("Loading texture " + node.trimeshHeader.textureName);
                    if (node.skinmeshHeader != null)
                    {
                        Mesh raw = go.GetComponent<MeshFilter>().sharedMesh;
                        GameObject.DestroyImmediate(go.GetComponent<MeshFilter>());

                        SkinnedMeshRenderer sk = go.AddComponent<SkinnedMeshRenderer>();

                        sk.material = CreateMaterial(node, cubemap);
                        Mesh mesh = (Mesh)GameObject.Instantiate(raw);

                        sk.forceRenderingOff = false;

                        Transform[] boneTransforms = new Transform[17];
                        Matrix4x4[] bindPoses = new Matrix4x4[17];

                        MeshCollider c = go.GetComponent<MeshCollider>();
                        if (c != null)
                        {
                            if (Application.isPlaying)
                            {
                                GameObject.Destroy(c);
                            }
                            else
                            {
                                GameObject.DestroyImmediate(c);
                            }
                        }

                        //Debug.Log("Beginning bone map");
                        for (int i = 0; i < node.skinmeshHeader.bonesMapCount; i++)
                        {
                            if (node.skinmeshHeader.boneMap[i] == -1)
                            {
                                continue;
                            }
                            //Debug.Log("Assigning bone " + i + " to node " + node.skinmeshHeader.boneMap[i]);

                            if (!nodeIdx.ContainsKey(i))
                            {
                                Debug.LogWarning("Bonemap node not found for " + go.name);
                                boneTransforms[node.skinmeshHeader.boneMap[i]] = go.transform;
                                continue;
                            }

                            (GameObject g, _) = nodeIdx[i];
                            MeshRenderer r = g.GetComponent<MeshRenderer>();
                            if (r != null)
                            {
                                GameObject.Destroy(r);
                            }

                            MeshFilter f = g.GetComponent<MeshFilter>();
                            if (f != null)
                            {
                                GameObject.Destroy(f);
                            }

                            boneTransforms[node.skinmeshHeader.boneMap[i]] = g.transform;

                            bindPoses[node.skinmeshHeader.boneMap[i]] = g.transform.worldToLocalMatrix * go.transform.localToWorldMatrix;
                        }

                        mesh.bindposes = bindPoses;

                        //mesh.Optimize();
                        //sk.BakeMesh(mesh);
                        sk.sharedMesh = mesh;
                        sk.bones = boneTransforms;
                        sk.forceMatrixRecalculationPerRender = true;
                        sk.updateWhenOffscreen = true;

                        //(GameObject dummy, _) = nodeStr["cutscenedummy"];
                        //sk.rootBone = dummy.transform;

                        //sk.localBounds = new Bounds(
                        //    Vector3.zero,
                        //    10 * Vector3.one
                        //);
                    }
                }
            }

            //Debug.Log("Creating " + node.childNodes.Length + " child nodes");
            for (int i = 0; i < node.childNodes.Length; i++)
            {
                CreateBones(node.childNodes[i], names, go.transform, nodeIdx, nodeStr, bones, cubemap);
            }
            
            return go;
        }

        public static GameObject LoadModel(string resref, AuroraObject obj = null, GameObject body = null, string cubemap = null)
        {
            //if (modelCache.ContainsKey(resref))
            //{
            //    return GameObject.Instantiate(modelCache[resref]);
            //}
            Stream mdl = data.GetStream(resref, ResourceType.MDL), mdx = data.GetStream(resref, ResourceType.MDX);

            if (mdl == null || mdx == null)
            {
                Debug.Log("Missing model: " + resref);
                return new GameObject(resref);
            }

            Vector3 pos;

            if (body != null)
            {
                // Find the head attachment point
                pos = body.transform.Find("cutscenedummy/rootdummy/torso_g/torsoupr_g/headhook").position;
            }
            else
            {
                pos = Vector3.zero;
            }
            GameObject model = LoadModel(mdl, mdx, modelCache, pos, body, cubemap, obj);

            modelCache[resref] = model;

            return model;
        }

        static void AttachHead(GameObject model, GameObject body)
        {
            if (body == null)
            {
                return;
            }

            // This is a head which needs to be attached to the body
            // Attach it to the left collar (as this is what the animations expect)
            Transform attach = body.transform.Find("cutscenedummy/rootdummy/torso_g/torsoupr_g");
            Transform bones = model.transform.Find("cutscenedummy/rootdummy/torso_g/torsoupr_g/necklwr_g");

            if (attach == null)
            {
                throw new System.Exception("Failed to find attachment point");
            }
            if (bones == null)
            {
                throw new System.Exception("Failed to find bones");
            }

            // Move it to the headhook position
            Transform headPos = body.transform.Find("cutscenedummy/rootdummy/torso_g/torsoupr_g/headhook");
            if (headPos != null)
            {
                bones.transform.parent = attach ?? throw new System.Exception("Failed to attach head " + model.name + " to body " + body.name);
                bones.transform.position = headPos.transform.position;
                bones.transform.rotation = headPos.transform.rotation;

                model.transform.parent = body.transform;
                model.transform.position = headPos.transform.position;
                model.transform.rotation = headPos.transform.rotation;
            } else
            {
                throw new System.Exception("Failed to find headPos");
            }
        }

        public static GameObject LoadModel(Stream mdl, Stream mdx, Dictionary<string, GameObject> modelCache, Vector3 basePos, 
            GameObject body, string cubemap, AuroraObject obj)
        {
            // TODO: Make this work for K2 as well
            AuroraModel auroraModel = new AuroraModel(mdl, mdx, Game.KotOR);
            Dictionary<int, (GameObject, MDLNode)> nodeIdx = new Dictionary<int, (GameObject, MDLNode)>();
            Dictionary<string, (GameObject, MDLNode)> nodeNames = new Dictionary<string, (GameObject, MDLNode)>();

            Dictionary<GameObject, GameObject> bones = new Dictionary<GameObject, GameObject>();

            GameObject model = CreateObject(
                auroraModel.mdlObject.rootNode,
                auroraModel.mdlObject.nameHeader.names,
                null,
                nodeIdx,
                nodeNames,
                cubemap,
                obj
            );
            model.transform.position = basePos;

            AttachHead(model, body);

            CreateBones(
                auroraModel.mdlObject.rootNode,
                auroraModel.mdlObject.nameHeader.names,
                null,
                nodeIdx,
                nodeNames,
                bones,
                cubemap
            );

            model.AddComponent<DrawBones>().enabled = false;

            Animation animComponent = model.AddComponent<Animation>();

            AnimationClip[] clips = auroraModel.GetUnityAnimationClips(modelCache, nodeIdx);

            for (int i = 0; i < clips.Length; i++)
            {
                clips[i].legacy = true;
                animComponent.AddClip(clips[i], clips[i].name.ToLower());
            }


            return model;
        }
    }
}
