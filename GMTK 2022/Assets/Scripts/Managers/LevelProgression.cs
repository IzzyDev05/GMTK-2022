using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour
{
    [SerializeField] float waitBeforeProgressing = 2f;

    private PlayerManager playerManager;
    private GameObject player1;
    private GameObject player2;

    private void Start() {
        playerManager = FindObjectOfType<PlayerManager>();
        player1 = playerManager.Player1;
        player2 = playerManager.Player2;
    }

    private void Update() {
        if (player1.GetComponent<PlayerCollisionManager>().hasWon && player2.GetComponent<PlayerCollisionManager>().hasWon) {
            StartCoroutine(LevelWon());
        }
    }

    IEnumerator LevelWon() {
        yield return new WaitForSeconds(waitBeforeProgressing);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}