using UnityEngine;

public class Tree : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            if (coll.gameObject.GetComponent<ItemCollectionController>().CheckHoldingItemExists(ItemType.AXE))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
