using Unity.VisualScripting;
using UnityEngine;

public class TimeMask : MonoBehaviour
{
    [SerializeField] TimeLine timelineContext;
    [SerializeField] TimeMask destination;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector2 GetDestinationCoordinates()
    {
        return new Vector2(destination.transform.position.x, destination.transform.position.y);
    }

    public TimeLine GetDestinationTimeLine()
    {
        return destination.timelineContext;
    }

    public TimeLine getTimeLine()
    {
        return timelineContext;
    }
}
