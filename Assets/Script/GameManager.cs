using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted;
    public bool isGameEnded;

    private int _levelIndex;

    private ParticleSystem[] confettiParticles;

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
        confettiParticles = GameObject.Find("Finish_Platform").GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem particle in confettiParticles)
        {
            particle.Stop();
        }
    }

    public void StartGame()
    {

        StartCoroutine(startGame());
    }

    private IEnumerator startGame()
    {
        CanvasAnimator.instance.sliderPlayStageAnimator.SetTrigger("StartGame");
        yield return new WaitForSeconds(0.75f);
        isGameStarted = true;
        MenuController.Instance.InGameScreenInitilaze(_levelIndex);
        MenuController.Instance.OpenScreen("InGameScreen");
    }

    public void LevelComplated()
    {
        if (!isGameEnded)
        {
            isGameEnded = true;
            foreach (ParticleSystem particle in confettiParticles)
            {
                particle.Play();
            }

            StartCoroutine(LevelComplated_IE());
        }
        
    }

    IEnumerator LevelComplated_IE()
    {
        yield return new WaitForSeconds(1f);
        MenuController.Instance.PlayerWinScreenInitilaze(_levelIndex);
        MenuController.Instance.OpenScreen("LevelComplated");
    }

    public void LevelFailed()
    {
        if (!isGameEnded)
        {
            isGameEnded = true;
            MenuController.Instance.OpenScreen("LevelFailed");
        }
       
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
