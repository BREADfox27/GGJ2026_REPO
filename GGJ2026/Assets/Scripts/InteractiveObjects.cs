using UnityEngine;

public class InteractiveObjects : MonoBehaviour
{
    public GameObject text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.gameObject.SetActive(false);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        text.gameObject.SetActive(true);
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        text.gameObject.SetActive(false);
    //    }
    //}
}
