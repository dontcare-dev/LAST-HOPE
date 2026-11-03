using UnityEngine;using UnityEngine.UI;
namespace LastHope.UI {
 public sealed class PauseMenu:MonoBehaviour {
  [SerializeField]GameObject panel;[SerializeField]Button pauseButton,resumeButton,saveButton,loadButton;[SerializeField]LastHope.Survival.SurvivalSave save;
  void Awake(){if(pauseButton)pauseButton.onClick.AddListener(()=>SetPaused(true));if(resumeButton)resumeButton.onClick.AddListener(()=>SetPaused(false));if(saveButton)saveButton.onClick.AddListener(()=>save?.Save());if(loadButton)loadButton.onClick.AddListener(()=>save?.Load());}
  public void SetPaused(bool p){if(panel)panel.SetActive(p);Time.timeScale=p?0:1;}
  void OnDestroy(){Time.timeScale=1;}
 }
}
