using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
  public void StartGame() {
    SceneManager.LoadScene(Constants.SceneBattle);
  }

  public void Quit() {
    Application.Quit();
  }
}