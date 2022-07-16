using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // WARNING: USING STRING REFERENCE!
    public void StartGame() {
        SceneManager.LoadScene("Level01");
    }

    // WARNING: USING STRING REFERENCE!
    public void KnownBugs() {
        SceneManager.LoadScene("KnownBugs");
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {
        print("Closed game!");
        Application.Quit();
    }
}