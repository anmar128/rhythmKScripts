using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameCamController : MonoBehaviour {

    // GameObject and Vector3 variables to be used
    // for gameview initialization
    public GameObject lowestBar;
    public GameObject lowBar;
    public GameObject midBar;
    public GameObject highBar;
    public GameObject highestBar;
    private Vector3 lowestBarValues = new Vector3(0.0f, -2.6f, 0.0f);
    private Vector3 lowBarValues = new Vector3(0.0f, -1.3f, 0.0f);
    private Vector3 midBarValues = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 highBarValues = new Vector3(0.0f, 1.35f, 0.0f);
    private Vector3 highestBarValues = new Vector3(0.0f, 2.7f, 0.0f);

    // Ints and floats for in-game and time control
    private float spawnValue = 7.6f;    // Spawn x-distance ~ 6.6f, orthographic
    private float startTime;            // Timer
    private float nextTime = 0.05f;     // Delay-ish ~ 0.025f, orthographic
    private float lastTime;             // HEARTS BEATING -- it is a state of mind
    private int score;
    private int playMode;               // Not playing ~ 0, playing ~ 1
    public int scoreValue;
    public GUIText scoreText;
    public GUIText hintText;

    private AudioSource audioSource;
    private GestureListener gestureListener;
    
    void Start()
    {

        startTime = Time.time;
        lastTime = startTime;
        audioSource = GetComponent<AudioSource>();
        // Get the gestures listener
        gestureListener = Camera.main.GetComponent<GestureListener>();

    }

    void Update()
    {
        string mov;
        
        if (playMode == 0)
        {
            hintText.text = "Swipe left to begin";
        }
        else
        {
            hintText.text = "Swipe up, down or right to play";
        }

        // Input to start new game
        if (playMode == 0 && (Input.GetKeyDown(KeyCode.P) || gestureListener.IsSwipeLeft()))
        {
            startTime = Time.time;
            score = 0;
            playMode = 1;
            mov = "nope";
            UpdateScore(mov);
            audioSource.Play();
            SpawnTutorial();
        }
        
        // Real-time gameplay
        if (playMode == 1)
        {
            if (Input.GetKeyDown(KeyCode.W) || (gestureListener.IsSwipeUp()))
            {
                mov = "up";
                UpdateScore(mov);
            }
            if (Input.GetKeyDown(KeyCode.S) || (gestureListener.IsSwipeDown()))
            {
                mov = "down";
                UpdateScore(mov);
            }
            if (Input.GetKeyDown(KeyCode.Space) || gestureListener.IsSwipeRight() || gestureListener.IsStop() || gestureListener.IsTPose())
            {
                mov = "mid";
                UpdateScore(mov);
            }
            SpawnTutorial();
        }

    }

    // Spawns the timed sequence for tutorial
    // Currently spawns two lowest-bars at the beginning, two low-bars 2 secs later etc
    public void SpawnTutorial()
    {

        if (Time.time < startTime + nextTime)
        {
            StartCoroutine(SpawnStuff(lowestBar, lowestBarValues));
        }
        if (Time.time > startTime + 1.0f && Time.time < startTime + 1.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(lowBar, lowBarValues));
        }
        if (Time.time > startTime + 2.0f && Time.time < startTime + 2.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(midBar, midBarValues));
        }
        if (Time.time > startTime + 3.0f && Time.time < startTime + 3.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(highBar, highBarValues));
        }
        if (Time.time > startTime + 4.0f && Time.time < startTime + 4.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(midBar, midBarValues));
        }
        if (Time.time > startTime + 5.0f && Time.time < startTime + 5.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(lowBar, lowBarValues));
        }
        if (Time.time > startTime + 6.0f && Time.time < startTime + 6.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(lowestBar, lowestBarValues));
        }
        if (Time.time > startTime + 7.0f && Time.time < startTime + 7.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(lowBar, lowBarValues));
        }
        if (Time.time > startTime + 8.0f && Time.time < startTime + 8.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(midBar, midBarValues));
        }
        if (Time.time > startTime + 9.0f && Time.time < startTime + 9.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(highBar, highBarValues));
        }
        if (Time.time > startTime + 10.0f && Time.time < startTime + 10.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(midBar, midBarValues));
        }
        if (Time.time > startTime + 11.0f && Time.time < startTime + 11.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(lowBar, lowBarValues));
        }
        if (Time.time > startTime + 25.0f + nextTime)
        {
            playMode = 0;
        }

    }

    // Updates score by comparing player moves with the correct sequence
    public void UpdateScore(string move)
    {

        // Reset ScoreText
        if (move == "nope")
        {
            UpdateScoreText();
        }
        // Detect move #1
        if ((Time.time > startTime + 7.5f && Time.time < startTime + 9.0f + nextTime) && move == "down")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #2
        if ((Time.time > startTime + 8.5f && Time.time < startTime + 10.0f + nextTime) && move == "down")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #3
        if ((Time.time > startTime + 9.5f && Time.time < startTime + 11.0f + nextTime) && move == "mid")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #4
        if ((Time.time > startTime + 10.5f && Time.time < startTime + 12.0f + nextTime) && move == "up")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #5
        if ((Time.time > startTime + 11.5f && Time.time < startTime + 13.0f + nextTime) && move == "mid")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #6
        if ((Time.time > startTime + 12.5f && Time.time < startTime + 14.0f + nextTime) && move == "down")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #7
        if ((Time.time > startTime + 13.5f && Time.time < startTime + 15.0f + nextTime) && move == "down")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #8
        if ((Time.time > startTime + 14.5f && Time.time < startTime + 16.0f + nextTime) && move == "down")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #9
        if ((Time.time > startTime + 15.5f && Time.time < startTime + 17.0f + nextTime) && move == "mid")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #10
        if ((Time.time > startTime + 16.5f && Time.time < startTime + 18.0f + nextTime) && move == "up")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #11
        if ((Time.time > startTime + 17.5f && Time.time < startTime + 19.0f + nextTime) && move == "mid")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #12
        if ((Time.time > startTime + 18.5f && Time.time < startTime + 20.0f + nextTime) && move == "down")
        {
            score += scoreValue;
            UpdateScoreText();
        }

    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // Instantiates bars -- called by Update
    IEnumerator SpawnStuff(GameObject bar, Vector3 barValues)
    {

        Vector3 spawnPosition = new Vector3(spawnValue, barValues.y, barValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(bar, spawnPosition, spawnRotation);
        yield return new WaitForSeconds(1);

    }

}
