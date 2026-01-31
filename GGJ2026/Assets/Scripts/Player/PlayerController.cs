using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator anim;
    private float horizontalInput;
    
    public int speed;
    private bool isFacingRight;

    [SerializeField] Sprite playerPast;
    [SerializeField] Sprite playerPresent;
    [SerializeField] Sprite playerFuture;

    //public int jumpForce;
    //public LayerMask groundLayer;


    //[SerializeField] bool isGrounded;
    //[SerializeField] GameObject groundCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        this.gameObject.GetComponent<SpriteRenderer>().sprite = playerPresent;
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, 0.1f, groundLayer);
        Movement();
        //Jump();

        //Flip
        if (horizontalInput > 0)
        {
            anim.SetBool("Idle", true);
            if (!isFacingRight)
            {
                Flip();
            }
        }

        if (horizontalInput < 0)
        {
            anim.SetBool("Idle", true);
            if (isFacingRight)
            {
                Flip();
            }
        }

        else if (horizontalInput == 0)
        {
            anim.SetBool("Idle", false);
        }
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.linearVelocity = new Vector2(horizontalInput * speed, playerRb.linearVelocity.y);
    }

    void Jump()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        //{
        //    playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        //}
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }

    public void ChangeSprite(TimeLine timeLine)
    {
        switch (timeLine)
        {
            case TimeLine.PAST:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = playerPast;
                break;
            case TimeLine.PRESENT:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = playerPresent;
                break;
            case TimeLine.FUTURE:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = playerFuture;
                break;
        }
    }
}
