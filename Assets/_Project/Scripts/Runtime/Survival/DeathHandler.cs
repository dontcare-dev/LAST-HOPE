using UnityEngine;
namespace LastHope.Survival {
 public sealed class DeathHandler:MonoBehaviour {
  [SerializeField]SurvivalVitals vitals;[SerializeField]GameObject deathPanel;
  void Awake(){if(!vitals)vitals=GetComponent<SurvivalVitals>();if(vitals)vitals.OnDeath.AddListener(Show);}
  void Show(){if(deathPanel)deathPanel.SetActive(true);Time.timeScale=0;}
  public void Restart(){Time.timeScale=1;UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);}
  void OnDestroy(){Time.timeScale=1;}
 }
}
