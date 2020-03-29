using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Persistent data of the game that is serialized in files.
/// </summary>
[System.Serializable]
public class PersistentSavedData
{
    /// <summary>
    /// The total score saved. Use in the shop for goodies.
    /// </summary>
    [SerializeField]
    private float totalScore;

    /// <summary>
    /// Adds data from a session (single game) to the persistent data.
    /// </summary>
    /// <param name="sessionData"></param>
    public void AddSessionData(SessionData sessionData)
    {
        totalScore += sessionData.score; // Add the score we acquired to our total.
    }

}
