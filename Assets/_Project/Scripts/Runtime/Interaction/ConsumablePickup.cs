using UnityEngine;using LastHope.Survival;
namespace LastHope.Interaction {
 public enum ConsumableType{Food,Water}
 public sealed class ConsumablePickup:Interactable {
  [SerializeField] ConsumableType type;[SerializeField,Min(0)] float restoreAmount=30;
  public void Configure(ConsumableType itemType,float amount){type=itemType;restoreAmount=Mathf.Max(0,amount);}
  public override bool Interact(GameObject actor){if(!actor)return false;var v=actor.GetComponentInParent<SurvivalVitals>();if(!v)return false;
   if(type==ConsumableType.Food)v.Eat(restoreAmount);else v.Drink(restoreAmount);Destroy(gameObject);return true;}
 }
}
