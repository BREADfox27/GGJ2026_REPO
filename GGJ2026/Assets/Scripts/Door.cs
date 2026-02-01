using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private DoorID doorID;
    [SerializeField] private bool isLocked = true;

    [SerializeField] private ItemType unlockWith = ItemType.UNIVERSAL_KEY;

    [SerializeField] private bool openFromLeft = false;
    [SerializeField] private bool openFromRight = false;


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

            Vector3 relativePos = transform.InverseTransformPoint(collision.transform.position);

            if (relativePos.x < 0 && !openFromLeft) return;
            if (relativePos.x > 0 && !openFromRight) return;

            ItemType playerItem = collision.gameObject.GetComponent<ItemCollectionController>().GetHoldingItem();
            if (playerItem == unlockWith)
            {
                Unlock();
                collision.gameObject.GetComponent<ItemCollectionController>().ConsumeHoldingItem();
                AudioManager.Instance.PlaySFX(2);
            }
            
        }
    }
}
