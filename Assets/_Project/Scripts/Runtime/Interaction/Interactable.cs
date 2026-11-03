using UnityEngine;
namespace LastHope.Interaction {
 public abstract class Interactable:MonoBehaviour {
  [SerializeField] string displayName="Interact";public string DisplayName=>displayName;
  public abstract bool Interact(GameObject actor);
 }
}
