using UnityEngine;
using LastHope.Player;
using LastHope.Survival;

namespace LastHope.World
{
    /// <summary>Temporary greybox world generator. Attach to an empty scene object to create a playable test space.</summary>
    public sealed class WorldBootstrap : MonoBehaviour
    {
        [SerializeField] bool generateOnStart = true;
        void Start() { if (generateOnStart) Build(); }

        public void Build()
        {
            if (FindObjectOfType<FirstPersonMotor>() != null) return;
            RenderSettings.ambientLight = new Color(.48f,.48f,.48f);
            var ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ground.name="Greybox Ground"; ground.transform.position=new Vector3(0,-.5f,0);ground.transform.localScale=new Vector3(60,1,60);
            ground.GetComponent<Renderer>().material.color=new Color(.22f,.28f,.22f);

            var player=new GameObject("Player");
            player.transform.position=new Vector3(0,1,0);
            var cc=player.AddComponent<CharacterController>();cc.height=1.8f;cc.radius=.32f;cc.center=new Vector3(0,.0f,0);
            player.AddComponent<FirstPersonMotor>();player.AddComponent<SurvivalVitals>();
            var camObj=new GameObject("Player Camera");camObj.tag="MainCamera";camObj.transform.SetParent(player.transform);
            camObj.transform.localPosition=new Vector3(0,.62f,0);camObj.transform.localRotation=Quaternion.identity;
            var cam=camObj.AddComponent<Camera>();cam.fieldOfView=75;camObj.AddComponent<AudioListener>();
            player.GetComponent<FirstPersonMotor>().SendMessage("SetCameraPivot",camObj.transform,SendMessageOptions.DontRequireReceiver);

            CreatePickup("Water Bottle",new Vector3(2,.35f,4),ConsumableType.Water,new Color(.2f,.55f,1));
            CreatePickup("Food Ration",new Vector3(-2,.35f,4),ConsumableType.Food,new Color(.8f,.55f,.2f));
            CreateObstacle(new Vector3(5,1,8),new Vector3(2,2,2));
            CreateObstacle(new Vector3(-5,.75f,10),new Vector3(3,1.5f,2));
            var light=new GameObject("Sun");var sun=light.AddComponent<Light>();sun.type=LightType.Directional;sun.intensity=1.1f;light.transform.rotation=Quaternion.Euler(50,-30,0);
        }
        void CreatePickup(string n,Vector3 p,ConsumableType type,Color c){var o=GameObject.CreatePrimitive(PrimitiveType.Cylinder);o.name=n;o.transform.position=p;o.transform.localScale=new Vector3(.35f,.35f,.35f);o.GetComponent<Renderer>().material.color=c;o.AddComponent<ConsumablePickup>();}
        void CreateObstacle(Vector3 p,Vector3 s){var o=GameObject.CreatePrimitive(PrimitiveType.Cube);o.name="Greybox Shelter";o.transform.position=p;o.transform.localScale=s;o.GetComponent<Renderer>().material.color=new Color(.35f,.32f,.28f);}
    }
}
