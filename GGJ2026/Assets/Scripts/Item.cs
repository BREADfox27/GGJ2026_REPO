using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType type = ItemType.NONE;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public ItemType getItemType()
    {
        return type;
    }
}
