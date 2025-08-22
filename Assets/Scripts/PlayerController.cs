//script basically lets the player move left and right and jump
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;//how fast the player moves
    public float jumpForce = 7f;//how high the player jumps
    private Rigidbody rb;// Rigidbody component for physics interactions

    private bool isOnGround = true;// Checks if the player is on the ground to allow jumping

    void Start()

    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Left/Right movement
        float horizontalInput = Input.GetAxis("Horizontal");//A and D keys or Left and Right arrows
        transform.Translate(Vector3.right * horizontalInput * moveSpeed * Time.deltaTime);

        // Jumping w spacebar and if the player is on the ground.
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            //Apply an upward force to the player
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //When that happens ground is set to falls so u cant double jump
            isOnGround = false;
        }
    }
    // Check if the player collides with the ground to reset jumping ability
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
