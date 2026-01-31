using UnityEngine;

public class Activatable : MonoBehaviour
{
    [SerializeField] private EventID eventID;
    [SerializeField] private GameObject[] objectToShow;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        Activator otherActivator = other.GetComponent<Activator>();
        if (otherActivator == null && other.attachedRigidbody != null)
        {
            otherActivator = other.attachedRigidbody.GetComponent<Activator>();
        }

        if (otherActivator != null)
        {
            if (eventID == otherActivator.GetEventID())
            {
                foreach (GameObject obj in objectToShow)
                {
                    if (obj != null) obj.SetActive(true);
                }
            }
        }
    }
}
