using UnityEngine;
namespace LastHope.Interaction {
 public sealed class PlayerInteractor:MonoBehaviour {
  [SerializeField] Camera viewCamera;[SerializeField,Min(.1f)] float range=2.8f;[SerializeField] LayerMask mask=~0;
  public Interactable CurrentTarget{get;private set;}
  public void SetCamera(Camera c)=>viewCamera=c;void Awake(){if(!viewCamera)viewCamera=Camera.main;}
  void Update(){CurrentTarget=null;if(viewCamera&&Physics.Raycast(viewCamera.transform.position,viewCamera.transform.forward,out RaycastHit hit,range,mask))CurrentTarget=hit.collider.GetComponentInParent<Interactable>();}
  public bool TryInteract(GameObject actor)=>CurrentTarget&&CurrentTarget.Interact(actor);
 }
}
