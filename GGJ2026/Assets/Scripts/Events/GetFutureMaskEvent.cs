using UnityEngine;

public class GetFutureMaskEvent : MonoBehaviour
{
    private bool playerInside = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                LevelManager.Instance.GetPlayer().GetComponent<TimerTravelController>().CanTravelFuture = true;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
