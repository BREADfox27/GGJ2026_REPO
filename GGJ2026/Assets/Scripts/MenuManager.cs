using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject creditsMenu;
    public GameObject controlsMenu;
    
    void Start()
    {
        creditsMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
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

    public void Controls()
    {
        controlsMenu.gameObject.SetActive(true);
    }

    public void ExitCreditsAndControls()
    {
        creditsMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("You closed the game.");
    }
}
