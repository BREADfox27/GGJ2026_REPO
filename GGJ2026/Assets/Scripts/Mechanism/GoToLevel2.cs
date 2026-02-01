using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private ItemType unlockWith = ItemType.KEY_TO_LEVEL2;
    private bool playerInside = false;

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
                if (LevelManager.Instance.GetPlayer().GetComponent<ItemCollectionController>().CheckHoldingItemExists(unlockWith))
                {
                    // AudioManager.Instance.PlaySFX(2);
                    SceneManager.LoadScene("Mansion_Level2");
                }
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
