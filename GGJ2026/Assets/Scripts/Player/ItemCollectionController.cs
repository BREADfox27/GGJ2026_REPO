using UnityEngine;
using System.Collections.Generic;

public class ItemCollectionController : MonoBehaviour
{
    [SerializeField] private List<ItemType> itemList = new List<ItemType>();
    [SerializeField] private TMPro.TMP_Text holdingItemText;


    private Item interactedItem = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string finalText = "Holding:  ";
        for (int i = 0; i < itemList.Count; i++)
        {
            finalText += itemList[i].ToString() + ", ";
        }

        holdingItemText.text = finalText;
        
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
            AudioManager.Instance.PlaySFX(3);
            itemList.Add(interactedItem.getItemType());
            Destroy(interactedItem.gameObject);
            interactedItem = null;
        }
    }

    public bool CheckHoldingItemExists(ItemType item)
    {
        if (itemList.Contains(item))
        {
            ConsumeHoldingItem(item);
            return true;
        }
        return false;
    }

    private void ConsumeHoldingItem(ItemType item)
    {
        itemList.Remove(item);
    }
}
