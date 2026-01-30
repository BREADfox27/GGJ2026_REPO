using UnityEngine;

public class ItemCollectionController : MonoBehaviour
{
    [SerializeField] private ItemType holdingItem = ItemType.NONE;
    [SerializeField] private TMPro.TMP_Text holdingItemText;


    private Item interactedItem = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactedItem)
        {
            Interact();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            interactedItem = other.GetComponent<Item>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            interactedItem = null;
        }
    }

    public void Interact()
    {
        if (interactedItem != null)
        {
            holdingItem = interactedItem.getItemType();
            Destroy(interactedItem.gameObject);
            interactedItem = null;

            holdingItemText.text = "Holding: " + holdingItem.ToString();
        }
    }

    public ItemType GetHoldingItem()
    {
        return holdingItem;
    }
}
