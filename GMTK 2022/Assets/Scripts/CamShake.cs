using UnityEngine;

public class CamShake : MonoBehaviour
{
    [SerializeField] private Animator camAnim;

    public void ShakeCamera() {
        var rand = Random.Range(0, 3);

        if (rand == 0) {
            camAnim.SetTrigger("shake");
        }
        else if (rand == 1) {
            camAnim.SetTrigger("shake2");
        } 
        else if (rand == 2) {
            camAnim.SetTrigger("shake3");
        }
    }
}