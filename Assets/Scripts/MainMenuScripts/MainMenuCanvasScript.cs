using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCanvasScript : MonoBehaviour
{
    public static MainMenuCanvasScript Instance { get; private set; }

    public Button playButton;
    public Button exitButton;

    public Button shopButton;
    public Button optionsButton;

    public Canvas optionsCanvas;

    


    void Start()
    {

        playButton.onClick.AddListener(OnPlayPress);
        exitButton.onClick.AddListener(ExitGame);

        shopButton.onClick.AddListener(GoToShop);
        optionsButton.onClick.AddListener(GoToOptions);

    }

    public MainMenuCanvasScript()
    {
        Instance = this;
    }


    public void ShowMainMenu()
    {
        gameObject.SetActive(true);
    }

    public void HideMainMenu()
    {
        gameObject.SetActive(false);
    }

    private void OnPlayPress()
    {
        HideMainMenu();
        PlayManager.INSTANCE.NewGame();
    }

    private void ExitGame()
    {
        HideMainMenu();

        PersistentDataSaveSystem.SavePersistentData(); // Just to be sure save the data again.
        Application.Quit();
    }

    private void GoToShop()
    {
        HideMainMenu();
        ShopCanvasScript.INSTANCE.ShowShop();
    }

    private void GoToOptions()
    {
        HideMainMenu();
        optionsButton.gameObject.SetActive(true);
    }
}
