using UnityEngine;

public class ShowCurrentTimeLine : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text timeLineText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //timeLineText.text = "Current in: " + LevelManager.Instance.GetCurrentTimeLineString();
        timeLineText.text = LevelManager.Instance.DoorStatusReport();
    }
}
