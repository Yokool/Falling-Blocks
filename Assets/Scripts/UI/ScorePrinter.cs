using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrinter : MonoBehaviour
{

    public Score tiedScoreScript;

    public Text scoreValueText;

    public Text scoreMultiplierValueText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        scoreValueText.text = Convert.ToString(tiedScoreScript.score);
        scoreMultiplierValueText.text = Convert.ToString(tiedScoreScript.scoreMultiplier);

    }
}
