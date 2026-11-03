using UnityEngine;
using UnityEngine.EventSystems;
namespace LastHope.UI {
 public sealed class VirtualJoystick:MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler {
  [SerializeField] RectTransform knob;[SerializeField,Min(20)] float radius=90;
  public Vector2 Value{get;private set;} public System.Action<Vector2> Changed;
  public void OnPointerDown(PointerEventData e)=>OnDrag(e);
  public void OnDrag(PointerEventData e){if(!RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)transform,e.position,e.pressEventCamera,out var p))return;Value=Vector2.ClampMagnitude(p/radius,1);if(knob)knob.anchoredPosition=Value*radius;Changed?.Invoke(Value);}
  public void OnPointerUp(PointerEventData e){Value=Vector2.zero;if(knob)knob.anchoredPosition=Vector2.zero;Changed?.Invoke(Value);}
 }
}
