using UnityEngine;using UnityEngine.UI;using LastHope.Player;using LastHope.Survival;using LastHope.Interaction;
namespace LastHope.UI {
 public sealed class MobileHUD:MonoBehaviour {
  [SerializeField] FirstPersonMotor motor;[SerializeField] SurvivalVitals vitals;[SerializeField] PlayerInteractor interactor;
  [SerializeField] VirtualJoystick joystick;[SerializeField] Button jumpButton,sprintButton,interactButton;
  [SerializeField] Slider health,hunger,thirst;[SerializeField] Text interactionLabel;
  void Awake(){if(joystick)joystick.Changed+=OnMove;if(jumpButton)jumpButton.onClick.AddListener(()=>motor?.QueueJump());
   if(sprintButton){var trigger=sprintButton.gameObject.AddComponent<SprintButton>();trigger.Bind(motor);}
   if(interactButton)interactButton.onClick.AddListener(()=>interactor?.TryInteract(motor?motor.gameObject:null));
   if(vitals)vitals.OnVitalsChanged.AddListener(UpdateBars);}
  void Update(){if(interactionLabel)interactionLabel.text=interactor&&interactor.CurrentTarget?interactor.CurrentTarget.DisplayName:"";}
  void OnMove(Vector2 v){if(motor)motor.SetMoveInput(v);}
  void UpdateBars(float h,float f,float w){if(health)health.value=h/100;if(hunger)hunger.value=f/100;if(thirst)thirst.value=w/100;}
 }
 public sealed class SprintButton:MonoBehaviour,IPointerDownHandler,IPointerUpHandler {
  FirstPersonMotor motor;public void Bind(FirstPersonMotor m)=>motor=m;
  public void OnPointerDown(PointerEventData e)=>motor?.SetSprint(true);public void OnPointerUp(PointerEventData e)=>motor?.SetSprint(false);
 }
}
