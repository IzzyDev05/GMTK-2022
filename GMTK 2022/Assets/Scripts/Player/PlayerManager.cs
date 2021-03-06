using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;

    private bool player1Spawned = false;
    private bool player2Spawned = false;
    private GridSystem gridSystem;
    private List<GameObject> gridPoints = new List<GameObject>();

    private void Start() {
        gridSystem = FindObjectOfType<GridSystem>();
        gridPoints = gridSystem.gridPoints;   
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            CastRay();
        }

        if (!player1Spawned || !player2Spawned) {
            SpawnPlayers();
        }
    }

    private void SpawnPlayers() {
        if (!player1Spawned) {
            for (int i = 0; i < 1; i++) {
                var rand = Random.Range(0, gridPoints.Count);

                if (!gridPoints[rand].GetComponentInChildren<SpriteRenderer>()) {
                    var p1 = Instantiate(Player1, gridPoints[rand].transform.position, Quaternion.identity);
                    p1.gameObject.name = "Player1";
                    Player1 = p1;
                    player1Spawned = true;
                }
            }
        }

        if (!player2Spawned) {
            for (int i = 0; i < 1; i++) {
                var rand = Random.Range(0, gridPoints.Count);

                if (!gridPoints[rand].GetComponentInChildren<SpriteRenderer>()) {
                    var p2 = Instantiate(Player2, gridPoints[rand].transform.position, Quaternion.identity);
                    p2.gameObject.name = "Player2";
                    Player2 = p2;
                    player2Spawned = true;
                }
            }
        }

        /*
        if (!player1Spawned) {
            var rand = Random.Range(0, gridPoints.Count);

            if (!gridPoints[rand].GetComponentInChildren<SpriteRenderer>()) {
                var p1 = Instantiate(Player1, gridPoints[rand].transform.position, Quaternion.identity);
                p1.gameObject.name = "Player1";
                Player1 = p1;
                player1Spawned = true;
            }
        }

        if (!player2Spawned) {
            var rand = Random.Range(0, gridPoints.Count);

            if (!gridPoints[rand].GetComponentInChildren<SpriteRenderer>()) {
                var p2 = Instantiate(Player2, gridPoints[rand].transform.position, Quaternion.identity);
                p2.gameObject.name = "Player2";
                Player2 = p2;
                player2Spawned = true;
            }
        }
        */
    }

    private void CastRay() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider != null) {
            if (hit.collider.gameObject.tag == "Player") {
                SwitchPlayers(hit);
            }
        }
    }

    private void SwitchPlayers(RaycastHit2D hit) {
        if (hit.collider.gameObject.GetComponent<PlayerGridMovement>().playerNumber == PlayerGridMovement.PlayerNumber.player2) {
            Player1.GetComponent<PlayerGridMovement>().enabled = false;
            Player2.GetComponent<PlayerGridMovement>().enabled = true;
        }
        else {
            Player1.GetComponent<PlayerGridMovement>().enabled = true;
            Player2.GetComponent<PlayerGridMovement>().enabled = false;
        }
    }
}