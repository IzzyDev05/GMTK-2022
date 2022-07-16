using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField] private int numberOfLives = 3;

    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.gameObject.tag) {
            case "ItemBlock":
                print("You got an item");
                other.gameObject.SetActive(false);
                break;
            case "WinBlock":
                print("You won!");
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
            Destroy(gameObject);
        }
    }
}