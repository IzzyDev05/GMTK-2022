using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour
{
    [SerializeField] float waitBeforeProgressing = 2f;
    [SerializeField] float waitBeforeRestarting = 2f;
    [SerializeField] GameObject levelLostPanel;
    [SerializeField] GameObject levelWonPanel;

    private PlayerManager playerManager;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private void Start() {
        levelLostPanel.SetActive(false);
        levelWonPanel.SetActive(false);

        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void Update() {
        player1 = playerManager.Player1;
        player2 = playerManager.Player2;
        
        if (player1.GetComponent<PlayerCollisionManager>().hasWon && player2.GetComponent<PlayerCollisionManager>().hasWon) {
            StartCoroutine(LevelWon());
        }

        if (PlayerCollisionManager.IsDead) {
            StartCoroutine(LevelLost());
        }
    }

    private IEnumerator LevelWon() {
        yield return new WaitForSeconds(waitBeforeProgressing);
        levelWonPanel.SetActive(true);
    }

    private IEnumerator LevelLost() {
        yield return new WaitForSeconds(waitBeforeRestarting);
        levelLostPanel.SetActive(true);
    }
}