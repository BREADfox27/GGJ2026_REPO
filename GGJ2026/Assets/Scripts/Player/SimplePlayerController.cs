using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(horizontal, 0f, 0f);

        transform.Translate(move * speed * Time.deltaTime);
    }

    public void TimeTravel(Vector2 destination) {
        this.gameObject.transform.position = new Vector2(destination.x, destination.y);
    }
}
