using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    // GameObject and Vector3 variables to be used
    // for gameview initialization
    public GameObject lowestBar;
    public GameObject lowBar;
    public GameObject midBar;
    public GameObject highBar;
    public GameObject highestBar;
    private Vector3 lowestBarValues = new Vector3(0.0f, -2.66f, 0.0f);
    private Vector3 lowBarValues = new Vector3(0.0f, -1.33f, 0.0f);
    private Vector3 midBarValues = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 highBarValues = new Vector3(0.0f, 1.38f, 0.0f);
    private Vector3 highestBarValues = new Vector3(0.0f, 2.75f, 0.0f);

    // Ints and floats for in-game and time control
    private float spawnValue = 6.6f;    // The x-distance for instantiating bars ~ 6.6f
    private float startTime;            // Timer
    private float nextTime = 0.035f;    // Delay-ish ~ 0.025f
//    private float lastTime;             //Hearts beating -- it is a state of mind
    private int score;
    private int playMode;               // Not playing ~ 0, playing ~ 1
    private int caliMode;               // Not calibrated ~ 0, calibrating ~ 1, calibrated ~ 2
    public int scoreValue;              // Value entered by user -- works ~ 10
    public GUIText scoreText;

    void Start () {
        
        startTime = Time.time;
        //lastTime = startTime;

    }
	
	void Update () {

        string mov;

        // Input to calibrate
        if (playMode == 0 && Input.GetKeyDown(KeyCode.C))
        {
            caliMode = 1;
            print("Calibrate");
            // addstuff
        }
        // Input to start new game
        if (playMode == 0 && Input.GetKeyDown(KeyCode.P))
        {
            startTime = Time.time;
            score = 0;
            playMode = 1;
            mov = "nope";
            UpdateScore(mov);
            SpawnTutorial();
        }
        // Real-time calibrating
        if (caliMode == 1)
        {
            // addstuff
            print("Calibrating...");
            caliMode = 2;
        }
        // Real-time gameplay
        if (playMode == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                mov = "up";
                UpdateScore(mov);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                mov = "down";
                UpdateScore(mov);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                mov = "mid";
                UpdateScore(mov);
            }
            SpawnTutorial();
        }

    }

    // Spawns the timed sequence for tutorial
    // Currently spawns two lowest-bars at the beginning, two low-bars 2 secs later etc
    public void SpawnTutorial() {

        if (Time.time < startTime + nextTime) {
            StartCoroutine(SpawnStuff(lowestBar, lowestBarValues));
        }
        if (Time.time > startTime + 1.0f && Time.time < startTime + 1.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(lowestBar, lowestBarValues));
        }
        if (Time.time > startTime + 2.0f && Time.time < startTime + 2.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(lowBar, lowBarValues));
        }
        if (Time.time > startTime + 3.0f && Time.time < startTime + 3.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(lowBar, lowBarValues));
        }
        if (Time.time > startTime + 4.0f && Time.time < startTime + 4.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(midBar, midBarValues));
        }
        if (Time.time > startTime + 5.0f && Time.time < startTime + 5.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(midBar, midBarValues));
        }
        if (Time.time > startTime + 6.0f && Time.time < startTime + 6.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(highBar, highBarValues));
        }
        if (Time.time > startTime + 7.0f && Time.time < startTime + 7.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(highBar, highBarValues));
        }
        if (Time.time > startTime + 8.0f && Time.time < startTime + 8.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(highestBar, highestBarValues));
        }
        if (Time.time > startTime + 9.0f && Time.time < startTime + 9.0f + nextTime)
        {
            StartCoroutine(SpawnStuff(highestBar, highestBarValues));
        }
        if (Time.time > startTime + 20.0f + nextTime)
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
        if ((Time.time > startTime + 6.5f && Time.time < startTime + 7.5f + nextTime) && move == "down")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #2
        if ((Time.time > startTime + 7.5f && Time.time < startTime + 8.5f + nextTime) && move == "down")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #3
        if ((Time.time > startTime + 8.5f && Time.time < startTime + 9.5f + nextTime) && move == "down")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #4
        if ((Time.time > startTime + 9.5f && Time.time < startTime + 10.5f + nextTime) && move == "down")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #5
        if ((Time.time > startTime + 10.5f && Time.time < startTime + 11.5f + nextTime) && move == "mid")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #6
        if ((Time.time > startTime + 11.5f && Time.time < startTime + 12.5f + nextTime) && move == "mid")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #7
        if ((Time.time > startTime + 12.5f && Time.time < startTime + 13.5f + nextTime) && move == "up")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #8
        if ((Time.time > startTime + 13.5f && Time.time < startTime + 14.5f + nextTime) && move == "up")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #9
        if ((Time.time > startTime + 14.5f && Time.time < startTime + 15.5f + nextTime) && move == "up")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        // Detect move #10
        if ((Time.time > startTime + 15.5f && Time.time < startTime + 16.5f + nextTime) && move == "up")
        {
            score += scoreValue;
            UpdateScoreText();
        }
        
    }

    public void UpdateScoreText() {
        scoreText.text = "Score: " + score;
    }

    // Instantiates bars -- called by Update
    IEnumerator SpawnStuff(GameObject bar, Vector3 barValues) {
        
        Vector3 spawnPosition = new Vector3(spawnValue, barValues.y, barValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(bar, spawnPosition, spawnRotation);
        yield return new WaitForSeconds(1);

    }

}
