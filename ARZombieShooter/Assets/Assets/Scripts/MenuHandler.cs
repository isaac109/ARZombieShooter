using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MenuHandler : MonoBehaviour {

    bool hasLogged = false;
    public GameObject hsInputScreen;
    public PlayerInfo playerInfo;
    public InputField nameField;
    public HighScoreManager hsManager;
    public GameObject scoreHolder;

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

    public void logInfo()
    {
        if (nameField.text != "")
        {
            hsManager.InsertScore(nameField.text, (int)playerInfo.score, (int)playerInfo.shotsFired, (int)playerInfo.kills, (int)playerInfo.lvl);
            hasLogged = true;
            hsInputScreen.SetActive(false);
        }

    }

    public void showHighScores()
    {
        List<ScoreCard> scores = hsManager.GetScores();
        int counter = 0;
        hsInputScreen.SetActive(true);
        for (int j = 1; j > -2; j--)
        {
            for (int i = -1; i < 2; i++)
            {
                GameObject temp = Instantiate(scoreHolder.gameObject) as GameObject;
                temp.transform.parent = hsInputScreen.transform;
                temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(i * 110, j * 110, 0);
                if (scores.Count >= counter + 1)
                {
                    temp.transform.FindChild("NameText").GetComponent<Text>().text =
                        scores[counter].name;
                    temp.transform.FindChild("ScoreText").GetComponent<Text>().text =
                        scores[counter].score.ToString();
                }
                else
                {
                    temp.transform.FindChild("Name").GetComponent<Text>().text =
                        "";
                    temp.transform.FindChild("Score").GetComponent<Text>().text =
                        "";
                    temp.transform.FindChild("NameText").GetComponent<Text>().text =
                        "";
                    temp.transform.FindChild("ScoreText").GetComponent<Text>().text =
                        "";
                }
                counter++;
            }
        }
    }
    public void closeHighScores()
    {
        foreach (Transform item in hsInputScreen.transform)
        {
            if (item.name == "Score(Clone)")
            {
                Destroy(item.gameObject);
            }
        }
        hsInputScreen.SetActive(false);
    }

    public void close()
    {
        Application.Quit();
    }
}
