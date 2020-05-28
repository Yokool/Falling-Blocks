using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameUI : MonoBehaviour
{

    private static IngameUI instance;
    
    [SerializeField]
    private GameObject gameCanvas;
    [SerializeField]
    private GameObject gameOverCanvas;

    private void Start()
    {
        instance = this;
    }

    public void HideGameUI()
    {
        gameCanvas.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        gameOverCanvas.SetActive(true);
    }


    public static IngameUI INSTANCE
    {
        get
        {
            return instance;
        }
        private set
        {
            if (instance != null)
            {
                Debug.LogError("Tried to create a new IngameUI while one already exists.");
                return;
            }
            instance = value;
        }
    }

    public GameObject GameCanvas
    {
        get
        {
            return gameCanvas;
        }
        set
        {
            gameCanvas = value;
        }
    }

    public GameObject GameOverCanvas
    {
        get
        {
            return gameOverCanvas;
        }
        set
        {
            gameOverCanvas = value;
        }
    }

}
