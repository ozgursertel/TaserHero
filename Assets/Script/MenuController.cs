using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static MenuController Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    [Header("Screens")]
    /*public GameObject startScreen;
    public GameObject inGameScreen;
    public GameObject levelCompaltedScreen;
    public GameObject deathPanel;
    public GameObject continuePanel;*/
    public GameObject[] screens;
    [Header("Start Screen UI")]
    public TextMeshProUGUI s_levelText;
    [Header("InGame Screen UI")]
    public TextMeshProUGUI i_levelText;

    public void OpenScreen(string name)
    {
        foreach (GameObject screen in screens)
        {
            if (screen.name == name)
            {
                screen.SetActive(true);
            }
            else
            {
                screen.SetActive(false);
            }
        }
    }


    public void StartScreenInitilaze(int levelIndex)
    {
        s_levelText.text = levelIndex.ToString();
    }

    public void InGameScreenInitilaze(int levelIndex)
    {
        i_levelText.text = levelIndex.ToString();
    }

    public void PlayerWinScreenInitilaze(int levelIndex)
    {

    }

    public void OpenStartScreen()
    {
        OpenScreen("StartScreen");
    }

    public void OpenCreditsScreen()
    {
        OpenScreen("CreditsScreen");

    }
}