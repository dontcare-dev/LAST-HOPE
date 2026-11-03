using UnityEngine;using UnityEngine.EventSystems;using LastHope.Player;
namespace LastHope.UI {
 public sealed class TouchLook:MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler {
  [SerializeField]FirstPersonMotor motor;[SerializeField]float sensitivity=.12f;Vector2 last;bool dragging;
  public void BindMotor(FirstPersonMotor m)=>motor=m;public void OnPointerDown(PointerEventData e){last=e.position;dragging=true;}
  public void OnDrag(PointerEventData e){if(!dragging)return;Vector2 d=e.position-last;last=e.position;if(motor)motor.AddLookDelta(d,sensitivity);}
  public void OnPointerUp(PointerEventData e)=>dragging=false;
 }
}
