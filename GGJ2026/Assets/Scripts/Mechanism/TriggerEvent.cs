using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] private Activatable activatable;
    [SerializeField] private Activator activator;

    [SerializeField] private GameObject[] objectToShow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (activatable == null) return;

        Activator otherActivator = other.GetComponent<Activator>();
        if (otherActivator == null && other.attachedRigidbody != null)
        {
             otherActivator = other.attachedRigidbody.GetComponent<Activator>();
        }

        if (otherActivator != null)
        {
            //if (activatable.GetEventID() == otherActivator.GetEventID())
            //{
            //    foreach (GameObject obj in objectToShow)
            //    {
            //         if (obj != null) obj.SetActive(true);
            //    }
            //}
        }
    }
}
