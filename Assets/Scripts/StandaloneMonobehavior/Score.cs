using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float score;

    public float scoreMultiplier = 1;

    public float timeToIncrement;

    private float timeCounter = 0;

    void Start()
    {
        scoreMultiplier = ShopSaveSystem.SerializedScore.scoreMultiplier;
    }

    void Update()
    {

        timeCounter += Time.deltaTime;


        if(timeCounter >= timeToIncrement)
        {
            score += 1 * scoreMultiplier;
            timeCounter = 0;
        }


    }
}
