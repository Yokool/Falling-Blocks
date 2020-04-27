using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Persistent data of the game, like the score etc.
/// 
/// The data is serialized.
/// </summary>
[System.Serializable]
public class PersistentSavedData
{
    /// <summary>
    /// The total score saved.
    /// </summary>
    [SerializeField]
    private float totalScore;

    public float TotalScore{

        get
        {
            return totalScore;
        }

        set
        {
            totalScore = value;
        }

    }

    /// <summary>
    /// Adds data from a session (single game) to the persistent data, you must
    /// serialize manually.
    /// </summary>
    /// <param name="sessionData"></param>
    public void AddSessionData(SessionData sessionData)
    {
        totalScore += sessionData.score; // Add the score we acquired to our total.
    }

}
