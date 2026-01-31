using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private SimplePlayerController player;
    [SerializeField] TimeLine currentTimeLine = TimeLine.PRESENT;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public SimplePlayerController GetPlayer()
    {
        return player;
    }

    public void TimeTravel(TimeLine newTimeLine)
    {
        currentTimeLine = newTimeLine;
    }

    public TimeLine GetCurrentTimeLine()
    {
        return currentTimeLine;
    }

    public string GetCurrentTimeLineString()
    {
        return currentTimeLine.ToString();
    }
}
