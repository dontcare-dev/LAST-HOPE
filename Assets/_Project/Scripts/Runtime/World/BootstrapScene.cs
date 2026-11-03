using UnityEngine;
namespace LastHope.World {
 public static class BootstrapScene {
  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
  static void EnsureWorld(){if(Object.FindObjectOfType<WorldBootstrap>()!=null)return;new GameObject("LAST HOPE World Bootstrap").AddComponent<WorldBootstrap>();}
 }
}
