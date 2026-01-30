using UnityEngine;

public class TimerTravelController : MonoBehaviour
{
    private TimeMask interactedMask = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactedMask && Input.GetKeyDown(KeyCode.E)) {
            Interact();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.CompareTag("TimeMask"))
        {
            interactedMask = other.GetComponent<TimeMask>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TimeMask"))
        {
            interactedMask = null;
        }
    }

    void Interact() {
        Vector2 destination = interactedMask.GetDestinationCoordinates();
        TimeLine destinationTimeLine = interactedMask.GetDestinationTimeLine();
        TimeLine currentTimeLine = LevelManager.Instance.GetCurrentTimeLine();

        SimplePlayerController player = LevelManager.Instance.GetPlayer(); 

        if (destinationTimeLine == currentTimeLine) return;

        if (player != null) 
        {
            player.TimeTravel(destination);
            LevelManager.Instance.TimeTravel(destinationTimeLine);

            interactedMask = null;
        }
    }
    
}
