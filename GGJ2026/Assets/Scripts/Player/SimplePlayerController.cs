using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    public float speed = 5f;

    public float climbSpeed = 5f;
    private Rigidbody2D rb;
    public bool canClimb = false;
    public bool isClimbing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0f, 0f);

        transform.Translate(move * speed * Time.deltaTime);

        // Climbing Logic
        if (canClimb && Mathf.Abs(vertical) > 0.1f)
        {
            isClimbing = true;
            if (rb != null) rb.gravityScale = 0f;
            // Stop vertical momentum when starting to climb to prevent sliding
            if (rb != null) rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); 
        }

        if (isClimbing)
        {
            if (!canClimb)
            {
                isClimbing = false;
                if (rb != null) rb.gravityScale = 1f;
            }
            else
            {
                transform.Translate(new Vector3(0, vertical * climbSpeed * Time.deltaTime, 0));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stair"))
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Stair"))
        {
            canClimb = false;
            isClimbing = false;
            if (rb != null) rb.gravityScale = 1f;
        }
    }

    public void TimeTravel(Vector2 destination) {
        this.gameObject.transform.position = new Vector2(destination.x, destination.y);
    }
}
