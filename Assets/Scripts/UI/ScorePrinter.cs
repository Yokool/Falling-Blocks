using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrinter : MonoBehaviour
{

    public Score tiedScoreScript;

    public Text valueText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        valueText.text = Convert.ToString(tiedScoreScript.score);

    }
}
