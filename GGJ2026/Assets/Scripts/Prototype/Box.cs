using UnityEngine;

public class Box : MonoBehaviour
{
    public float pushDistance = 2f;
    public SimplePlayerController playerInRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange != null && Input.GetKeyDown(KeyCode.E))
        {
            float directionX = Mathf.Sign(transform.position.x - playerInRange.transform.position.x);
            transform.position += new Vector3(directionX * pushDistance, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SimplePlayerController player = collision.gameObject.GetComponent<SimplePlayerController>();
        if (player != null)
        {
            playerInRange = player;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        SimplePlayerController player = collision.gameObject.GetComponent<SimplePlayerController>();
        if (player != null && player == playerInRange)
        {
            playerInRange = null;
        }
    }
}
