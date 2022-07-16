using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private GridSystem gridSystem;
    private List<GameObject> gridPoints = new List<GameObject>();

    private void Start() {
        gridSystem = FindObjectOfType<GridSystem>();
        gridPoints = gridSystem.gridPoints;

        SpawnPlayers();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            CastRay();
        }
    }

    private void SpawnPlayers() {
        for (int i = 0; i < 1; i++) {
            var rand = Random.Range(0, gridPoints.Count);

            if (!gridPoints[rand].GetComponentInChildren<SpriteRenderer>()) {
                var p1 = Instantiate(player1, gridPoints[rand].transform.position, Quaternion.identity);
                p1.gameObject.name = "Player1";
                player1 = p1;
            }
        }

        for (int i = 0; i < 1; i++) {
            var rand = Random.Range(0, gridPoints.Count);

            if (!gridPoints[rand].GetComponentInChildren<SpriteRenderer>()) {
                var p2 = Instantiate(player2, gridPoints[rand].transform.position, Quaternion.identity);
                p2.gameObject.name = "Player2";
                player2 = p2;
            }
        }
    }

    private void CastRay() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider.gameObject.tag == "Player") {
            SwitchPlayers(hit);
        }
    }

    private void SwitchPlayers(RaycastHit2D hit) {
        if (hit.collider.gameObject.GetComponent<PlayerGridMovement>().playerNumber == PlayerGridMovement.PlayerNumber.player2) {
            player1.GetComponent<PlayerGridMovement>().enabled = false;
            player2.GetComponent<PlayerGridMovement>().enabled = true;
        }
        else {
            player1.GetComponent<PlayerGridMovement>().enabled = true;
            player2.GetComponent<PlayerGridMovement>().enabled = false;
        }
    }
}