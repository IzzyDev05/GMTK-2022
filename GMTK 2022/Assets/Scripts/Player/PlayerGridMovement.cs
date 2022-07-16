using UnityEngine;

public class PlayerGridMovement : MonoBehaviour
{
    public enum PlayerNumber { player1, player2 };
    [HideInInspector] public bool randomizeMovement = true;

    [SerializeField] private int translateValue = 1;
    public PlayerNumber playerNumber;


    private void Update() {
        GridMovement();
        DiscretePositions();
    }

    private void GridMovement() {
        if (Debug.isDebugBuild && Input.GetKeyDown(KeyCode.L)) {
            randomizeMovement = !randomizeMovement;
        }

        if (!randomizeMovement) {
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
        else {
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
    }

    private int ChooseRandomTranslate() {
        var translate = translateValue;
        var rand = Random.Range(0, 100);

        if (rand >= 70) {
            translate = translateValue;
        }
        else {
            translate = -translateValue;
        }

        return translate;
    }

    private void DiscretePositions() {
        Vector3 playerPos = gameObject.transform.position;
        
        int discPosX = Mathf.RoundToInt(playerPos.x);
        int discPosY = Mathf.RoundToInt(playerPos.y);

        gameObject.transform.position = new Vector3(discPosX, discPosY, 0);
    }
}