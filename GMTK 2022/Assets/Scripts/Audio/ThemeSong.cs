using UnityEngine;

public class ThemeSong : MonoBehaviour
{
    public static ThemeSong instance;

    private bool doesPlayerExist = true;
    private AudioSource source;
    private AudioLowPassFilter lowPassFilter;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        source = GetComponent<AudioSource>();
        lowPassFilter = GetComponent<AudioLowPassFilter>();
        source.Play();
    }

    private void Update() {
        if (PlayerCollisionManager.IsDead) {
            doesPlayerExist = false;
        }
        else {
            doesPlayerExist = true;
        }

        if (doesPlayerExist) {
            lowPassFilter.cutoffFrequency = 22000f;     
        }
        else {
            lowPassFilter.cutoffFrequency = 1500f;
        }
    }
}
