using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{    
    public GameObject creditsMenu;
    public GameObject controlsMenu;
    public GameObject masksMenu;
    
    void Start()
    {
        creditsMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
        masksMenu.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            controlsMenu.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            masksMenu.gameObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            masksMenu.gameObject.SetActive(false);
        }
    }
    
    public void Play()
    {
        SceneManager.LoadScene("Mansion_Beta2");
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

    public void ExitMenu()
    {
        creditsMenu.gameObject.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
        masksMenu.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("You closed the game.");
    }
}
