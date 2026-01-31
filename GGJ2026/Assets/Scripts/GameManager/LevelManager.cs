using UnityEngine;

public class LevelManager : MonoBehaviour
{
    const int TIME_Y_OFFSET = 50;
    public static LevelManager Instance { get; private set; }

    [SerializeField] private PlayerController player;
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

    public PlayerController GetPlayer()
    {
        return player;
    }

    public void TimeTravel(TimeLine newTimeLine)
    {
        if (newTimeLine == currentTimeLine) return;

        switch (newTimeLine)
        {
            case TimeLine.PAST:
                GoToPast();
                break;
            case TimeLine.PRESENT:
                GoToPresent();
                break;
            case TimeLine.FUTURE:
                GoToFuture();
                break;
        }

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

    public void GoToPast()
    {
        if (currentTimeLine == TimeLine.PAST)
        {
            return;
        }

        if (currentTimeLine == TimeLine.PRESENT)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + TIME_Y_OFFSET);
        }
        else if (currentTimeLine == TimeLine.FUTURE)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + TIME_Y_OFFSET * 2);
        }
    }

    public void GoToPresent()
    {
        if (currentTimeLine == TimeLine.PRESENT)
        {
            return;
        }

        if (currentTimeLine == TimeLine.PAST)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - TIME_Y_OFFSET);
        }
        else if (currentTimeLine == TimeLine.FUTURE)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + TIME_Y_OFFSET);
        }

    }

    public void GoToFuture()
    {
        if (currentTimeLine == TimeLine.FUTURE)
        {
            return;
        }

        if (currentTimeLine == TimeLine.PAST)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - TIME_Y_OFFSET * 2);
        }
        else if (currentTimeLine == TimeLine.PRESENT)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - TIME_Y_OFFSET);
        }
    }

}
