using UnityEngine;using LastHope.Player;using LastHope.Survival;using LastHope.Interaction;
namespace LastHope.World {
 public sealed class WorldBootstrap:MonoBehaviour {
  [SerializeField]bool generateOnStart=true;void Start(){if(generateOnStart)Build();}
  public void Build(){if(FindObjectOfType<FirstPersonMotor>()!=null)return;
   RenderSettings.ambientLight=new Color(.48f,.48f,.48f);
   var ground=GameObject.CreatePrimitive(PrimitiveType.Cube);ground.name="Greybox Ground";ground.transform.position=new Vector3(0,-.5f,0);ground.transform.localScale=new Vector3(60,1,60);ground.GetComponent<Renderer>().material.color=new Color(.22f,.28f,.22f);
   var player=new GameObject("Player");player.transform.position=new Vector3(0,1,0);var cc=player.AddComponent<CharacterController>();cc.height=1.8f;cc.radius=.32f;
   var motor=player.AddComponent<FirstPersonMotor>();player.AddComponent<SurvivalVitals>();var interactor=player.AddComponent<PlayerInteractor>();
   var camObj=new GameObject("Player Camera");camObj.tag="MainCamera";camObj.transform.SetParent(player.transform);camObj.transform.localPosition=new Vector3(0,.62f,0);camObj.transform.localRotation=Quaternion.identity;var cam=camObj.AddComponent<Camera>();cam.fieldOfView=75;camObj.AddComponent<AudioListener>();motor.SetCameraPivot(camObj.transform);
   var eventObj=new GameObject("EventSystem");eventObj.AddComponent<EventSystem>();eventObj.AddComponent<StandaloneInputModule>();
   var canvasObj=new GameObject("Mobile HUD");var canvas=canvasObj.AddComponent<Canvas>();canvas.renderMode=RenderMode.ScreenSpaceOverlay;canvasObj.AddComponent<CanvasScaler>();canvasObj.AddComponent<GraphicRaycaster>();
   var hud=canvasObj.AddComponent<MobileHUD>();var joystick=CreateUI<RectTransform>("Move Joystick",canvasObj.transform);joystick.anchorMin=new Vector2(0,0);joystick.anchorMax=new Vector2(0,0);joystick.anchoredPosition=new Vector2(150,150);joystick.sizeDelta=new Vector2(180,180);Image ji=joystick.gameObject.AddComponent<Image>();ji.color=new Color(1,1,1,.18f);var j=joystick.gameObject.AddComponent<VirtualJoystick>();hud.SendMessage("SetJoystick",j,SendMessageOptions.DontRequireReceiver);
   var look=CreateUI<RectTransform>("Look Area",canvasObj.transform);look.anchorMin=new Vector2(.4f,0);look.anchorMax=new Vector2(1,1);look.offsetMin=Vector2.zero;look.offsetMax=Vector2.zero;look.gameObject.AddComponent<TouchLook>().SendMessage("BindMotor",motor,SendMessageOptions.DontRequireReceiver);
   var jump=MakeButton(canvasObj.transform,"JUMP",new Vector2(-150,150),new Vector2(1,0));var sprint=MakeButton(canvasObj.transform,"RUN",new Vector2(-150,280),new Vector2(1,0));var interact=MakeButton(canvasObj.transform,"USE",new Vector2(-300,150),new Vector2(1,0));
   var health=MakeSlider(canvasObj.transform,"HEALTH",new Vector2(20,-30),new Vector2(0,1));var hunger=MakeSlider(canvasObj.transform,"HUNGER",new Vector2(20,-65),new Vector2(0,1));var thirst=MakeSlider(canvasObj.transform,"THIRST",new Vector2(20,-100),new Vector2(0,1));
   hud.Configure(motor,player.GetComponent<SurvivalVitals>(),interactor,j,jump,sprint,interact,health,hunger,thirst);
   CreatePickup("Water Bottle",new Vector3(2,.35f,4),ConsumableType.Water,new Color(.2f,.55f,1));CreatePickup("Food Ration",new Vector3(-2,.35f,4),ConsumableType.Food,new Color(.8f,.55f,.2f));
   CreateObstacle(new Vector3(5,1,8),new Vector3(2,2,2));CreateObstacle(new Vector3(-5,.75f,10),new Vector3(3,1.5f,2));
   var sun=new GameObject("Sun").AddComponent<Light>();sun.type=LightType.Directional;sun.intensity=1.1f;sun.transform.rotation=Quaternion.Euler(50,-30,0);
  }
  RectTransform CreateUI<T>(string n,Transform parent)where T:Component{var o=new GameObject(n,typeof(RectTransform));o.transform.SetParent(parent,false);return o.GetComponent<RectTransform>();}
  Button MakeButton(Transform parent,string text,Vector2 pos,Vector2 anchor){var rt=CreateUI<RectTransform>(text+" Button",parent);rt.anchorMin=rt.anchorMax=anchor;rt.anchoredPosition=pos;rt.sizeDelta=new Vector2(110,90);var im=rt.gameObject.AddComponent<Image>();im.color=new Color(.08f,.08f,.08f,.65f);var b=rt.gameObject.AddComponent<Button>();var label=CreateUI<RectTransform>("Label",rt);label.anchorMin=Vector2.zero;label.anchorMax=Vector2.one;var tx=label.gameObject.AddComponent<Text>();tx.text=text;tx.alignment=TextAnchor.MiddleCenter;tx.color=Color.white;tx.font=Resources.GetBuiltinResource<Font>("Arial.ttf");return b;}
  Slider MakeSlider(Transform parent,string n,Vector2 pos,Vector2 anchor){var rt=CreateUI<RectTransform>(n,parent);rt.anchorMin=rt.anchorMax=anchor;rt.anchoredPosition=pos;rt.sizeDelta=new Vector2(220,20);rt.gameObject.AddComponent<Image>().color=new Color(.15f,.15f,.15f,.6f);var s=rt.gameObject.AddComponent<Slider>();s.minValue=0;s.maxValue=1;s.value=1;return s;}
  void CreatePickup(string n,Vector3 p,ConsumableType type,Color c){var o=GameObject.CreatePrimitive(PrimitiveType.Cylinder);o.name=n;o.transform.position=p;o.transform.localScale=new Vector3(.35f,.35f,.35f);o.GetComponent<Renderer>().material.color=c;o.AddComponent<ConsumablePickup>().Configure(type,35);}
  void CreateObstacle(Vector3 p,Vector3 s){var o=GameObject.CreatePrimitive(PrimitiveType.Cube);o.name="Greybox Shelter";o.transform.position=p;o.transform.localScale=s;o.GetComponent<Renderer>().material.color=new Color(.35f,.32f,.28f);}
 }
}
