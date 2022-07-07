using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted;
    public bool isGameEnded;

    private int _levelIndex;

    public static GameManager Instance;
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

    private void Start()
    {
        _levelIndex = PlayerPrefs.GetInt("LevelIndex", 1);
        isGameEnded = false;
        MenuController.Instance.OpenScreen("StartScreen");
        MenuController.Instance.StartScreenInitilaze(_levelIndex);
    }

    public void StartGame()
    {
        isGameStarted = true;
        MenuController.Instance.InGameScreenInitilaze(_levelIndex);
        MenuController.Instance.OpenScreen("InGameScreen");

    }

    public void LevelComplated()
    {
        isGameEnded = true;
        MenuController.Instance.PlayerWinScreenInitilaze(_levelIndex);
        MenuController.Instance.OpenScreen("LevelComplated");
    }

    public void LevelFailed()
    {
        isGameEnded = true;
        MenuController.Instance.OpenScreen("LevelFailed");
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("LevelIndex", _levelIndex + 1);
        //Add Cash To ShopManager
        LevelController.Instance.LoadNextLevel();
    }

    public void ReloadLevel()
    {
        LevelController.Instance.ReloadLevel();
    }

    public void ResetGame()
    {
        ReloadLevel();
    }


}
