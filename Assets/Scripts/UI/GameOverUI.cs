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

    private void Start()
    {
        goToMainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    public void UpdateTextValues()
    {
        youScoreValueText.text = Convert.ToString(LocalPlayer.INSTANCE.Score.score);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene((int)SceneEnum.MAIN_MENU, LoadSceneMode.Single);
    }
}
