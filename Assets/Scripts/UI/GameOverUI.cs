using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    public Text youScoreValueText;

    public Button goToMainMenuButton;

    public Score scoreScript;

    private void Start()
    {
        goToMainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    public void GameEnded()
    {

        youScoreValueText.text = Convert.ToString(scoreScript.score);

    }

    private void GoToMainMenu()
    {

        SceneManager.LoadScene((int)SceneEnum.MAIN_MENU, LoadSceneMode.Single);

        SessionData sessionData = new SessionData(scoreScript);
        
        SaveSystem.dataLoaded.AddSessionData(sessionData);
        SaveSystem.SavePersistentData();


    }
}
