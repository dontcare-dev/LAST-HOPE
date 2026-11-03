using UnityEngine;using LastHope.Survival;
namespace LastHope.Interaction {
 public enum ResourceKind{Berry,Water}
 public sealed class ResourceNode:Interactable {
  [SerializeField]ResourceKind resource;[SerializeField,Min(1)]int uses=3;[SerializeField,Min(0)]float restore=18;
  public override bool Interact(GameObject actor){if(!actor)return false;var v=actor.GetComponentInParent<SurvivalVitals>();if(!v)return false;
   if(resource==ResourceKind.Berry)v.Eat(restore);else v.Drink(restore);uses--;if(uses<=0)Destroy(gameObject);return true;}
 }
}
