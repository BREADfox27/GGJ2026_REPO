using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject creditsMenu;
    
    void Start()
    {
        creditsMenu.gameObject.SetActive(false);
    }
    
    public void Play()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Credits()
    {
        creditsMenu.gameObject.SetActive(true);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitCredits()
    {
        creditsMenu.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("You closed the game.");
    }
}
