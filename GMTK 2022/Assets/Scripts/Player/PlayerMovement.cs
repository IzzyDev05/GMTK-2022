using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10.0f;

    private float horizontal;
    private float vertical;

    private BoxCollider2D boxColl;
    private Rigidbody2D rb;

    private void Start() {
        boxColl = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() {
        float horizontalSpeed = horizontal * movementSpeed * Time.deltaTime;
        float verticalSpeed = vertical * movementSpeed * Time.deltaTime;

        rb.velocity = new Vector2(horizontalSpeed, verticalSpeed);
    }
}