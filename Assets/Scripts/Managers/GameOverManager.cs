using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{

    private bool gameEnded;
    public bool GameEnded
    {
        get
        {
            return gameEnded;
        }
        set
        {
            gameEnded = value;
        }
    }

    private static GameOverManager instance;
    public static GameOverManager INSTANCE
    {
        get
        {
            return instance;
        }

        private set
        {
            if(instance != null)
            {
                Debug.LogError("Tried to create a new GameOverManager while one already exists.");
                return;
            }

            instance = value;
        }
    }

    void Start()
    {
        instance = this;
    }

    public void EndGame()
    {
        gameEnded = true;

        IngameUI ingameUI = IngameUI.INSTANCE;
        ingameUI.HideGameUI();
        ingameUI.ShowGameOverUI();

        SaveSession();

        ingameUI.GameOverCanvas.GetComponent<GameOverUI>().UpdateTextValues();

        AudioManager.INSTANCE.PlaySound(SoundDatabase.GameOver_Tune);
        MusicManager.INSTANCE.PlayMusic(null);
    }

    private void SaveSession()
    {
        // Wrap the data created from the session
        SessionData sessionData = new SessionData(LocalPlayer.INSTANCE.Score);
        
        // and send it to be serialized
        PersistentDataSaveSystem.dataLoaded.AddSessionData(sessionData);
        PersistentDataSaveSystem.SavePersistentData();
    }

}
