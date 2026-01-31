using UnityEngine;

public class TimeSwitch : MonoBehaviour
{
    // When condition is accomplished, active invisible objects
    [SerializeField] private GameObject[] objectsToActivate;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }
    }
}
