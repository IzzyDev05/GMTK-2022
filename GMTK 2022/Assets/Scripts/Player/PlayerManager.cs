using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            CastRay();
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