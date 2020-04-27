using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    
    public static PlayManager INSTANCE { get; private set; }

    public PlayManager()
    {
        INSTANCE = this;
    }

    public void NewGame()
    {
        SceneManager.LoadScene((int)SceneEnum.GAME_SCENE, LoadSceneMode.Single);
        MusicManager.INSTANCE.PlayMusic(SoundDatabase.Game_Theme);
    }


}
