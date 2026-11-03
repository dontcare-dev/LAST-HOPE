using UnityEngine;using UnityEngine.Events;
namespace LastHope.Survival {
 public sealed class SurvivalVitals:MonoBehaviour {
  [SerializeField,Min(1)] float maxHealth=100,maxHunger=100,maxThirst=100;
  [SerializeField,Min(0)] float hungerDrainPerSecond=.12f,thirstDrainPerSecond=.2f,starvationDamagePerSecond=1,dehydrationDamagePerSecond=2;
  public float Health{get;private set;} public float Hunger{get;private set;} public float Thirst{get;private set;} public bool IsDead=>Health<=0;
  public UnityEvent<float,float,float> OnVitalsChanged=new UnityEvent<float,float,float>();public UnityEvent OnDeath=new UnityEvent();
  void Awake(){Health=maxHealth;Hunger=maxHunger;Thirst=maxThirst;Publish();}
  void Update(){if(IsDead)return;Hunger=Mathf.Max(0,Hunger-hungerDrainPerSecond*Time.deltaTime);Thirst=Mathf.Max(0,Thirst-thirstDrainPerSecond*Time.deltaTime);
   if(Hunger<=0)Damage(starvationDamagePerSecond*Time.deltaTime);if(Thirst<=0)Damage(dehydrationDamagePerSecond*Time.deltaTime);Publish();}
  public void Eat(float n){Hunger=Mathf.Clamp(Hunger+Mathf.Max(0,n),0,maxHunger);Publish();}
  public void Drink(float n){Thirst=Mathf.Clamp(Thirst+Mathf.Max(0,n),0,maxThirst);Publish();}
  public void Heal(float n){Health=Mathf.Clamp(Health+Mathf.Max(0,n),0,maxHealth);Publish();}
  public void Damage(float n){if(IsDead||n<=0)return;Health=Mathf.Max(0,Health-n);Publish();if(Health<=0)OnDeath.Invoke();}
  void Publish()=>OnVitalsChanged.Invoke(Health,Hunger,Thirst);
 }
}
