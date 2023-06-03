using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public LeaderboardManager leaderboard;

    void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    IEnumerator SetupRoutine()
    {
        yield return leaderboard.HighscoreRoutine();
    }
}
