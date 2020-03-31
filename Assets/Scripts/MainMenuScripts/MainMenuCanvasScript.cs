using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCanvasScript : MonoBehaviour
{

    public Button playButton;
    public Button exitButton;

    public Button shopButton;
    public Button optionsButton;

    public Canvas optionsCanvas;
    public Canvas shopCanvas;

    void Start()
    {

        playButton.onClick.AddListener(OnPlayPress);
        exitButton.onClick.AddListener(ExitGame);

        shopButton.onClick.AddListener(GoToShop);
        optionsButton.onClick.AddListener(GoToOptions);

    }

    private void HideMainMenu()
    {
        gameObject.SetActive(false);
    }

    private void OnPlayPress()
    {
        HideMainMenu();

    }

    private void ExitGame()
    {
        HideMainMenu();

        SaveSystem.SavePersistentData(); // Just to be sure save the data again.
        Application.Quit();
    }

    private void GoToShop()
    {
        HideMainMenu();
        shopButton.gameObject.SetActive(true);
    }

    private void GoToOptions()
    {
        HideMainMenu();
        optionsButton.gameObject.SetActive(true);
    }
}
