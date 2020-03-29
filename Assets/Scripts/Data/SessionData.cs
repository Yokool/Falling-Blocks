using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents the data extracted from the game when dying.
/// </summary>
public class SessionData
{

    public SessionData(Score sessionScore)
    {
        this.score = sessionScore.score;
    }

    /// <summary>
    /// The amount of score the player has scored in this session (1 game).
    /// </summary>
    public float score;

}
