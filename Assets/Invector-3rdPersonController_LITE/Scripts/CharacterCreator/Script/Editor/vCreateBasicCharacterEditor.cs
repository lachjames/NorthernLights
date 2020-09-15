using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Invector.vCharacterController
{
    public class vCreateBasicCharacterEditor : EditorWindow
    {
        GUISkin skin;
        GameObject charObj;
        Animator charAnimator;
        public  RuntimeAnimatorController controller;
        public GameObject hud;
        Vector2 rect = new Vector2(500, 540);
        Vector2 scrool;
        Editor humanoidpreview;
        Texture2D m_Logo;

        /// <summary>
        /// 3rdPersonController Menu 
        /// </summary>    
        [MenuItem("Invector/Basic Locomotion/Create Basic Controller", false, 0)]
        public static void CreateNewCharacter()
        {
            GetWindow<vCreateBasicCharacterEditor>();
        }

        bool isHuman, isValidAvatar, charExist;
        void OnEnable()
        {           
            m_Logo = Resources.Load("icon_v2") as Texture2D;
            charObj = Selection.activeGameObject;
            if (charObj)
            {
                charAnimator = charObj.GetComponent<Animator>();
                humanoidpreview = Editor.CreateEditor(charObj);
            }
                
            charExist = charAnimator != null;
            isHuman = charExist ? charAnimator.isHuman : false;
            isValidAvatar = charExist ? charAnimator.avatar.isValid : false;
        }

        void OnGUI()
        {
            if (!skin) skin = Resources.Load("vSkin") as GUISkin;
            GUI.skin = skin;

            this.maxSize = rect;
            this.minSize = rect;
            this.titleContent = new GUIContent("Character", null, "Third Person Character Creator");
            GUILayout.BeginVertical("Character Creator Window", "window");
            GUILayout.Label(m_Logo, GUILayout.MaxHeight(25));
            GUILayout.Space(5);

            GUILayout.BeginVertical("box");

            if (!charObj)
                EditorGUILayout.HelpBox("Make sure your FBX model is set as Humanoid!", MessageType.Info);
            else if (!charExist)
                EditorGUILayout.HelpBox("Missing a Animator Component", MessageType.Error);
            else if (!isHuman)
                EditorGUILayout.HelpBox("This is not a Humanoid", MessageType.Error);
            else if (!isValidAvatar)
                EditorGUILayout.HelpBox(charObj.name + " is a invalid Humanoid", MessageType.Info);

            charObj = EditorGUILayout.ObjectField("FBX Model", charObj, typeof(GameObject), true, GUILayout.ExpandWidth(true)) as GameObject;

            if (GUI.changed && charObj != null && charObj.GetComponent<vThirdPersonController>() == null)
                humanoidpreview = Editor.CreateEditor(charObj);
            if (charObj != null && charObj.GetComponent<vThirdPersonController>() != null)
                EditorGUILayout.HelpBox("This gameObject already contains the component vThirdPersonController", MessageType.Warning);

            controller = EditorGUILayout.ObjectField("Animator Controller: ", controller, typeof(RuntimeAnimatorController), false) as RuntimeAnimatorController;            
            
            GUILayout.EndVertical();          

            if (charObj)
            {
                charAnimator = charObj.GetComponent<Animator>();    
            }
                
            charExist = charAnimator != null;
            isHuman = charExist ? charAnimator.isHuman : false;
            isValidAvatar = charExist ? charAnimator.avatar.isValid : false;

            if (CanCreate())
            {
                DrawHumanoidPreview();
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                if (controller != null)
                {
                    if (GUILayout.Button("Create"))
                        Create();
                }
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }

            GUILayout.EndVertical();
        }

        bool CanCreate()
        {
            return isValidAvatar && isHuman && charObj != null && charObj.GetComponent<vThirdPersonController>() == null;
        }

        /// <summary>
        /// Draw the Preview window
        /// </summary>
        void DrawHumanoidPreview()
        {
            GUILayout.FlexibleSpace();

            if (humanoidpreview != null)
            {
                humanoidpreview.OnInteractivePreviewGUI(GUILayoutUtility.GetRect(100, 400), "window");
            }
        }

        /// <summary>
        /// Created the Third Person Controller
        /// </summary>
        void Create()
        {
            // base for the character
            var _ThirdPerson = GameObject.Instantiate(charObj, Vector3.zero, Quaternion.identity) as GameObject;
            if (!_ThirdPerson)
                return;          
            _ThirdPerson.name = "vBasicController_" + charObj.gameObject.name;
            _ThirdPerson.AddComponent<vThirdPersonController>();
            _ThirdPerson.AddComponent<vThirdPersonInput>();

            var rigidbody = _ThirdPerson.AddComponent<Rigidbody>();
            var collider = _ThirdPerson.AddComponent<CapsuleCollider>();

            // camera
            GameObject camera = null;
            if (Camera.main == null)
            {
                var cam = new GameObject("vThirdPersonCamera");
                cam.AddComponent<Camera>();
                cam.AddComponent<AudioListener>();
                camera = cam;
                camera.GetComponent<Camera>().tag = "MainCamera";
                camera.GetComponent<Camera>().nearClipPlane = 0.03f;
            }
            else
            {
                camera = Camera.main.gameObject;
                camera.GetComponent<Camera>().tag = "MainCamera";
                camera.GetComponent<Camera>().nearClipPlane = 0.03f;
                camera.gameObject.name = "vThirdPersonCamera";
            }
            var tpcamera = camera.GetComponent<vThirdPersonCamera>();

            if (tpcamera == null)
                tpcamera = camera.AddComponent<vThirdPersonCamera>();           

            _ThirdPerson.tag = "Player";

            // rigidbody
            rigidbody.useGravity = true;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rigidbody.mass = 50;

            // capsule collider 
            collider.height = ColliderHeight(_ThirdPerson.GetComponent<Animator>());
            collider.center = new Vector3(0, (float)System.Math.Round(collider.height * 0.5f, 2), 0);
            collider.radius = (float)System.Math.Round(collider.height * 0.15f, 2);

            if (controller)
                _ThirdPerson.GetComponent<Animator>().runtimeAnimatorController = controller;
            Selection.activeGameObject = _ThirdPerson;
            UnityEditor.SceneView.lastActiveSceneView.FrameSelected();
            this.Close();
        }

        /// <summary>
        /// Capsule Collider height based on the Character height
        /// </summary>
        /// <param name="animator">animator humanoid</param>
        /// <returns></returns>
        float ColliderHeight(Animator animator)
        {
            var foot = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
            var hips = animator.GetBoneTransform(HumanBodyBones.Hips);
            return (float)System.Math.Round(Vector3.Distance(foot.position, hips.position) * 2f, 2);
        }       

    }
}