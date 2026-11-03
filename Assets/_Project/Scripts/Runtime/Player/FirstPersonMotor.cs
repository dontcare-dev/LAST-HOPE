using UnityEngine;
namespace LastHope.Player {
 [RequireComponent(typeof(CharacterController))]
 public sealed class FirstPersonMotor : MonoBehaviour {
  [SerializeField,Min(0)] float walkSpeed=4.2f,sprintSpeed=6.5f,jumpHeight=1.15f;
  [SerializeField] float gravity=-20f; [SerializeField] Transform cameraPivot;
  CharacterController controller; Vector2 moveInput; float verticalVelocity; bool sprintHeld,jumpQueued;
  public void SetMoveInput(Vector2 v)=>moveInput=Vector2.ClampMagnitude(v,1f);
  public void SetSprint(bool held)=>sprintHeld=held; public void QueueJump()=>jumpQueued=true;
  void Awake(){controller=GetComponent<CharacterController>();if(!cameraPivot&&Camera.main)cameraPivot=Camera.main.transform;}
  void Update(){bool grounded=controller.isGrounded;if(grounded&&verticalVelocity<0)verticalVelocity=-2f;
   if(grounded&&jumpQueued)verticalVelocity=Mathf.Sqrt(jumpHeight*-2f*gravity);jumpQueued=false;verticalVelocity+=gravity*Time.deltaTime;
   Vector3 v=(transform.right*moveInput.x+transform.forward*moveInput.y)*(sprintHeld?sprintSpeed:walkSpeed);v.y=verticalVelocity;controller.Move(v*Time.deltaTime);}
  public void AddLookDelta(Vector2 d,float sensitivity=.12f){transform.Rotate(Vector3.up,d.x*sensitivity,Space.World);if(!cameraPivot)return;
   Vector3 e=cameraPivot.localEulerAngles;float p=e.x>180?e.x-360:e.x;p=Mathf.Clamp(p-d.y*sensitivity,-85,85);cameraPivot.localEulerAngles=new Vector3(p,0,0);}
 }
}
