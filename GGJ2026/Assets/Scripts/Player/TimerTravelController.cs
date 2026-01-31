using UnityEngine;

public class TimerTravelController : MonoBehaviour
{
    private TimeMask interactedMask = null;
    public bool newTimeTravelMechanic = true;

    public bool CanTravelPresent = true;
    public bool CanTravelPast = false;
    public bool CanTravelFuture = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (newTimeTravelMechanic) {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKeyDown(KeyCode.J) && CanTravelPast)
                {
                    LevelManager.Instance.TimeTravel(TimeLine.PAST);
                }
                else if (Input.GetKeyDown(KeyCode.K) && CanTravelPresent)
                {
                    LevelManager.Instance.TimeTravel(TimeLine.PRESENT);
                }
                else if (Input.GetKeyDown(KeyCode.L) && CanTravelFuture)
                {
                    LevelManager.Instance.TimeTravel(TimeLine.FUTURE);
                }
            }
        } else {
            if (interactedMask && Input.GetKeyDown(KeyCode.E))
            {
                //Interact();
            }
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

    //void Interact() {
    //    Vector2 destination = interactedMask.GetDestinationCoordinates();
    //    TimeLine destinationTimeLine = interactedMask.GetDestinationTimeLine();
    //    TimeLine currentTimeLine = LevelManager.Instance.GetCurrentTimeLine();

    //    PlayerController player = LevelManager.Instance.GetPlayer(); 

    //    if (destinationTimeLine == currentTimeLine) return;

    //    if (player != null) 
    //    {
    //        player.TimeTravel(destination);
    //        LevelManager.Instance.TimeTravel(destinationTimeLine);

    //        interactedMask = null;
    //    }
    //}
    
}
