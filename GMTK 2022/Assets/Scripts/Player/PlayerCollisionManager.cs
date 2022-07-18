using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    public static bool IsDead = false;

    [HideInInspector] public bool hasWon = false;
    [HideInInspector] public bool isDead = false;

    [SerializeField] private GameObject itemParticles;
    [SerializeField] private Sprite apple;
    [SerializeField] private Sprite potion;
    [SerializeField] private Sprite gears;
    [SerializeField] private Sprite shield;

    [SerializeField] private GameObject hitParticles;
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
                print("Normal");
                playerGrid.randomizeMovement = false;
                audioManager.Play("NormalMovement");
                PlayItemParticles(other);
                camShake.ShakeCamera();
                other.gameObject.SetActive(false);
                break;
            case "Invincible":
                print("Invincible");
                numberOfLives = 500;
                PlayItemParticles(other);
                camShake.ShakeCamera();
                audioManager.Play("Invincible");
                other.gameObject.SetActive(false);
                break;
            case "AddLife":
                print("+1 Life");
                numberOfLives++;
                PlayItemParticles(other);
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
                print("-1 Life");
                numberOfLives--;
                PlayItemParticles(other);
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

    private void PlayItemParticles(Collider2D other) {
        var randOffsetX = Random.Range(0, 0.1f);
        var randOffsetY = Random.Range(0, 0.1f);
        var pos = this.transform.position + new Vector3(randOffsetX, randOffsetY, 0);

        var particles = itemParticles.GetComponent<ParticleSystem>().textureSheetAnimation;
        switch (other.gameObject.tag) {
            case "NormalMovements":
                particles.SetSprite(0, gears);
                break;
            case "Invincible":
                particles.SetSprite(0, shield);
                break;
            case "AddLife":
                particles.SetSprite(0, apple);
                break;
            case "RemoveLife":
                particles.SetSprite(0, potion);
                break;
        }

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