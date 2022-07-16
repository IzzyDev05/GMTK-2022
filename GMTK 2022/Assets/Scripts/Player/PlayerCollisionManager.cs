using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    public static bool IsDead = false;

    [HideInInspector] public bool hasWon = false;
    [HideInInspector] public bool isDead = false;

    [SerializeField] private GameObject hitParticles;
    [SerializeField] private GameObject itemParticles;
    [SerializeField] private GameObject winParticles;
    public int numberOfLives = 3;

    private CamShake camShake;
    private PlayerGridMovement playerGrid;
    private AudioManager audioManager;

    private void Start() {
        IsDead = false;
        
        camShake = FindObjectOfType<CamShake>();
        playerGrid = FindObjectOfType<PlayerGridMovement>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.gameObject.tag) {
            case "NormalMovements":
                playerGrid.randomizeMovement = false;
                audioManager.Play("NormalMovement");
                PlayItemParticles();
                camShake.ShakeCamera();
                other.gameObject.SetActive(false);
                break;
            case "Invincible":
                numberOfLives = 500;
                PlayItemParticles();
                camShake.ShakeCamera();
                audioManager.Play("Invincible");
                other.gameObject.SetActive(false);
                break;
            case "AddLife":
                numberOfLives++;
                PlayItemParticles();
                camShake.ShakeCamera();

                var rand = Random.Range(0, 10);
                if (rand <= 5) {
                    audioManager.Play("PickupGood1");
                }
                else {
                    audioManager.Play("PickupGood2");
                }

                other.gameObject.SetActive(false);
                break;
            case "RemoveLife":
                numberOfLives--;
                PlayHitParticles();
                camShake.ShakeCamera();
                audioManager.Play("Hurt2");
                other.gameObject.SetActive(false);
                break;
            case "WinBlock":
                hasWon = true;
                PlayWinParticless();
                camShake.ShakeCamera();
                audioManager.Play("LevelWin");
                DisablePlayer();
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "ObstacleBlock") {
            numberOfLives--;

            var rand = Random.Range(0, 10);
            if (rand <= 5) {
                audioManager.Play("Hurt");
            }
            else {
                audioManager.Play("Hurt2");
            }

            PlayHitParticles();
            camShake.ShakeCamera();
        }
    }

    private void PlayItemParticles() {
        var randOffsetX = Random.Range(0, 0.1f);
        var randOffsetY = Random.Range(0, 0.1f);
        var pos = this.transform.position + new Vector3(randOffsetX, randOffsetY, 0);
        Instantiate(itemParticles, pos, Quaternion.identity);
    }

    private void PlayHitParticles() {
        var randOffsetX = Random.Range(0, 0.1f);
        var randOffsetY = Random.Range(0, 0.1f);
        var pos = this.transform.position + new Vector3(randOffsetX, randOffsetY, 0);
        Instantiate(hitParticles, pos, Quaternion.identity);
    }

    private void PlayWinParticless() {
        var randOffsetX = Random.Range(0, 0.1f);
        var randOffsetY = Random.Range(0, 0.1f);
        var pos = this.transform.position + new Vector3(randOffsetX, randOffsetY, 0);
        Instantiate(winParticles, pos, Quaternion.identity);
    }

    private void Update() {
        if (numberOfLives <= 0) {
            isDead = true;
            IsDead = true;
            DisablePlayer();
        }
    }

    // Don't destroy player as that gives errors
    private void DisablePlayer() {
        audioManager.Play("Death");
        Destroy(this.GetComponent<SpriteRenderer>()); // Need to destory sprite renderer to avoid players not spawning
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<PlayerGridMovement>().enabled = false;
        this.enabled = false;
    }
}