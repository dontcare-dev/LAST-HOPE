using UnityEngine;
namespace LastHope.World {
 public sealed class DayNightCycle:MonoBehaviour {
  [SerializeField]Light sun;[SerializeField,Min(1)]float cycleMinutes=20;[SerializeField]Gradient ambient;[SerializeField]AnimationCurve intensity=AnimationCurve.EaseInOut(0,0,1,1);
  float time01;
  void Update(){time01=(time01+Time.deltaTime/(cycleMinutes*60))%1;float angle=time01*360-90;if(sun){sun.transform.rotation=Quaternion.Euler(angle,170,0);sun.intensity=Mathf.Max(0,intensity.Evaluate(Mathf.Clamp01(Mathf.Sin(time01*Mathf.PI*2)*.5f+.5f))*1.2f);}
   if(ambient!=null&&ambient.colorKeys.Length>0)RenderSettings.ambientLight=ambient.Evaluate(time01);}
 }
}
