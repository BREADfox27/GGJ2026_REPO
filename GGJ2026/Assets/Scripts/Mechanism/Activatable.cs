using UnityEngine;

public class Activatable : MonoBehaviour
{
    [SerializeField] private ItemType itemToActivate;

    [SerializeField] private GameObject[] objectToShow;

    private bool playerInside = false;
    private bool activated = false;


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
                ItemType playerItem = LevelManager.Instance.GetPlayer().GetComponent<ItemCollectionController>().GetHoldingItem();

                if (playerItem == itemToActivate)
                {
                    LevelManager.Instance.GetPlayer().GetComponent<ItemCollectionController>().ConsumeHoldingItem();
                    foreach (GameObject obj in objectToShow)
                    {
                        obj.SetActive(true);
                    }

                    activated = true;
                }
            }
        }
    }

    public ItemType ItemToActivate()
    {
        return itemToActivate;
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
