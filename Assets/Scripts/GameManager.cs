using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public const int ScorePerNormal = 75;
    public const int ScorePerGood = 100;
    public const int ScorePerPerfect = 125;

    public const int ScorePerHoldNormal = 150;
    public const int ScorePerHoldGood = 200;
    public const int ScorePerHoldPerfect = 250;

    public VideoPlayer player;
    public AudioSource audioSource;

    public GameObject pauseMenu;

    public bool startPlaying;

    public BeatScroller BS;

    public static GameManager instance;

    public float CurrTime;
    public float TimeForEnd;

    public int currScore;
    public int currCombo;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;

    public int totalNotes;
    public int normalNotes;
    public int goodNotes;
    public int perfectNotes;
    public int missNotes;

    public TextMeshProUGUI totalNotesTXT;
    public TextMeshProUGUI normalNotesTXT;
    public TextMeshProUGUI goodNotesTXT;
    public TextMeshProUGUI perfectNotesTXT;
    public TextMeshProUGUI missNotesTXT;
    public TextMeshProUGUI clearPercentTXT;
    public TextMeshProUGUI finalScoreTXT;

    public GameObject Results;
    public LeaderboardManager leaderboard;
    public int damn = 0;

    void Start()
    {
        instance = this;
        comboText.text = "Combo: 0";
        scoreText.text = "Score: 0";
    }

    void Update()
    {
        CurrTime = Time.timeSinceLevelLoad;
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                BS.hasStarted = true;
                player.Play();
            }
        }
        else if (CurrTime > TimeForEnd)
        {
            Results.SetActive(true);
            if (damn != 1)
            {
                StartCoroutine(ReturnScore());
                damn = 1;
            }
            totalNotesTXT.text = totalNotes.ToString();
            normalNotesTXT.text = normalNotes.ToString();
            goodNotesTXT.text = goodNotes.ToString();
            missNotesTXT.text = missNotes.ToString();
            perfectNotesTXT.text = perfectNotes.ToString();
            if (totalNotes != 0)
            {
                clearPercentTXT.text = (((float)totalNotes) / (totalNotes + missNotes) * 100).ToString("F1") + "%";
            }
            else
            {
                clearPercentTXT.text = "0%";
            }
            finalScoreTXT.text = currScore.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            player.Pause();
            audioSource.Pause();
            pauseMenu.SetActive(true);
        }
    }

    public void NoteHit()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currScore.ToString();
        }

        totalNotes++;

        currCombo++;

        if (comboText != null)
        {
            comboText.text = "Combo: " + currCombo.ToString();
        }

            Destroy(GameObject.Find("Miss(Clone)"));
            Destroy(GameObject.Find("Perfect(Clone)"));
            Destroy(GameObject.Find("Normal(Clone)"));
            Destroy(GameObject.Find("Good(Clone)"));
    }

    public void NormalHit()
    {
        Hit(ScorePerNormal);
        normalNotes++;
    }

    public void GoodHit()
    {
        Hit(ScorePerGood);
        goodNotes++;
    }

    public void PerfectHit()
    {
        Hit(ScorePerPerfect);
        perfectNotes++;
    }

    public void NormalHoldHit()
    {
        Hit(ScorePerHoldNormal);
        normalNotes++;
    }

    public void GoodHoldHit()
    {
        Hit(ScorePerHoldGood);
        goodNotes++;
    }

    public void PerfectHoldHit()
    {
        Hit(ScorePerHoldPerfect);
        perfectNotes++;
    }

    public void NoteMiss()
    {
        Destroy(GameObject.Find("Miss(Clone)"));
        Destroy(GameObject.Find("Perfect(Clone)"));
        Destroy(GameObject.Find("Normal(Clone)"));
        Destroy(GameObject.Find("Good(Clone)"));
        currCombo = 0;
        comboText.text = "Combo: 0";
        missNotes++;
    }

    private void Hit(int Score)
    {
        currScore += Score;
        NoteHit();
    }

    private IEnumerator ReturnScore()
    {
       yield return leaderboard.SubmitScoreRoutine(currScore);
    }
}
