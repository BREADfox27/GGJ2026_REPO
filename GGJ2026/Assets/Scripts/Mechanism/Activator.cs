using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private EventID eventID;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public EventID GetEventID()
    {
        return eventID;
    }
}
