using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
    private void Update() {
        GridMovement();
    }

    private void GridMovement() {
        if (Input.GetKeyDown(KeyCode.W)) {
            transform.Translate(new Vector3(0, 1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.S)) {
            transform.Translate(new Vector3(0, -1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.A)) {
            transform.Translate(new Vector3(-1, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D)) {
            transform.Translate(new Vector3(1, 0, 0));
        }
    }
}