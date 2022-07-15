using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
    public enum PlayerNumber { player1, player2 };

    [SerializeField] private int translateValue = 1;
    public PlayerNumber playerNumber;

    private void Update() {
        GridMovement();
    }

    private void GridMovement() {
        if (Input.GetKeyDown(KeyCode.W)) {
            transform.Translate(new Vector3(0, ChooseRandomTranslate(), 0));
        }
        else if (Input.GetKeyDown(KeyCode.S)) {
            transform.Translate(new Vector3(0, ChooseRandomTranslate(), 0));
        }
        else if (Input.GetKeyDown(KeyCode.A)) {
            transform.Translate(new Vector3(ChooseRandomTranslate(), 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D)) {
            transform.Translate(new Vector3(ChooseRandomTranslate(), 0, 0));
        }
    }

    private int ChooseRandomTranslate() {
        var translate = translateValue;
        var rand = Random.Range(0, 100);

        if (rand >= 50) {
            translate = translateValue;
        }
        else {
            translate = -translateValue;
        }

        return translate;
    }
}