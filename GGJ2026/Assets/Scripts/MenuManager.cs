using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Play()
    {
        SceneManager.LoadScene("GamePlay");
    }

    // Update is called once per frame
    public void Exit()
    {
        Application.Quit();
        Debug.Log("You closed the game.");
    }
}
