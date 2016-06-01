using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuHandler : MonoBehaviour {

    bool hasLogged = false;
    public GameObject hsInputScreen;
    public PlayerInfo playerInfo;
    public InputField nameField;

    public void startGame()
    {
        playerInfo.start = true;
    }

    public void newGame()
    {
        SceneManager.LoadScene("map");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void logInfoPermission()
    {
        if (!hasLogged)
        {
            hsInputScreen.SetActive(true);
        }
    }

    public void close()
    {
        Application.Quit();
    }
}
