using System.IO;using UnityEngine;
namespace LastHope.Survival {
 [System.Serializable]public struct SurvivalSnapshot{public float health,hunger,thirst;public Vector3 position;public Quaternion rotation;}
 public sealed class SurvivalSave:MonoBehaviour {
  [SerializeField]SurvivalVitals vitals;[SerializeField]Transform player;string PathName=>Path.Combine(Application.persistentDataPath,"last-hope-save.json");
  public void Configure(SurvivalVitals v,Transform t){vitals=v;player=t;}\n  public void Save(){if(!vitals||!player)return;var s=new SurvivalSnapshot{health=vitals.Health,hunger=vitals.Hunger,thirst=vitals.Thirst,position=player.position,rotation=player.rotation};File.WriteAllText(PathName,JsonUtility.ToJson(s,true));}
  public bool Load(){if(!vitals||!player||!File.Exists(PathName))return false;var s=JsonUtility.FromJson<SurvivalSnapshot>(File.ReadAllText(PathName));vitals.SetVitals(s.health,s.hunger,s.thirst);player.SetPositionAndRotation(s.position,s.rotation);return true;}
 }
}
