using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Score score;

    public GameObject Player
    {
        get
        {
            return player;
        }
        set
        {
            player = value;
        }
    }

    public Score Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public static LocalPlayer INSTANCE { get; private set; }

    void Start()
    {
        INSTANCE = this;
    }

}
