using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private DoorID doorID;
    [SerializeField] private bool isLocked = true;

    [SerializeField] private ItemType unlockWith = ItemType.UNIVERSAL_KEY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LevelManager.Instance.RegisterDoor(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocked)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
            this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    public DoorID GetID()
    {
        return doorID;
    }

    public bool IsLocked()
    {
        return isLocked;
    }

    public void Unlock()
    {
        isLocked = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isLocked)  return;

            ItemType playerItem = collision.gameObject.GetComponent<ItemCollectionController>().GetHoldingItem();
            if (playerItem == unlockWith)
            {
                Unlock();
            }
            
        }
    }
}
