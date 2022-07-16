using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    [HideInInspector] public bool hasWon = false;
    [HideInInspector] public bool isDead = false;
    public int numberOfLives = 3;
    private PlayerGridMovement playerGrid;

    private void Start() {
        playerGrid = FindObjectOfType<PlayerGridMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.gameObject.tag) {
            case "NormalMovements":
                playerGrid.randomizeMovement = false;
                print("Normal movements");
                other.gameObject.SetActive(false);
                break;
            case "Invincible":
                numberOfLives = 500;
                other.gameObject.SetActive(false);
                break;
            case "AddLife":
                numberOfLives++;
                other.gameObject.SetActive(false);
                break;
            case "RemoveLife":
                numberOfLives--;
                other.gameObject.SetActive(false);
                break;
            case "WinBlock":
                hasWon = true;
                this.gameObject.SetActive(false);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "ObstacleBlock") {
            numberOfLives--;
        }
    }

    private void Update() {
        if (numberOfLives <= 0) {
            print(gameObject.name + " is dead!");
            isDead = true;
            DisablePlayer();
        }
    }

    // Don't destroy player as that gives errors
    private void DisablePlayer() {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<PlayerGridMovement>().enabled = false;
        this.enabled = false;
    }
}