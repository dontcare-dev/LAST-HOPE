using UnityEngine;
namespace LastHope {
 public static class LastHopeBootstrap {
  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
  static void StartGame(){if(Object.FindObjectOfType<LastHopeGame>()!=null)return;new GameObject("LAST HOPE Runtime").AddComponent<LastHopeGame>();}
 }
}
