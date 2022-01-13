using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    float fps;
    float deltaTime;

    public bool playingMinigame = false;

    [SerializeField]
    Text timerText, scoreText, alienScoreText, boxingScoreText;

    int tempScore, alienScore, boxingScore;
    float timerSec;

    [SerializeField]
    AlienMGBehavior alienMGBehaviorScript;
    [SerializeField]
    Text playButtonText;

    [SerializeField]
    List<string> textforPlayBtn;

    [SerializeField]
    int intFps;

    [SerializeField]
    Text FPScounterText;

    bool toggleCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        playButtonText.text = textforPlayBtn[0];

        FPScounter(toggleCheck);

        SettingHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        deltaTime /= 2.0f;
        fps = 1.0f / deltaTime;
        intFps = (int)fps;

        FPScounterText.text = "FPS: "+intFps;

        if (playingMinigame)
        {
            timerSec -= Time.deltaTime;
            timerText.text = "Time: 0:" + (int)timerSec;

            if (timerSec <= 0)
            {
                StartAlienMG();
            }
            scoreText.text = "Score: " + tempScore;
        }
    }

    public void FPScounter(bool toggle)
    {
        FPScounterText.enabled = toggle;
    }

    public void addPoint()
    {
        tempScore++;
    }

    void TimerFunc()
    {
        if (playingMinigame)
        {
            timerSec = 60f;
        }
    }

    void SettingHighScore()
    {
        scoreText.text = "Highscore: " + alienScore;
    }

    public void StartAlienMG()
    {
        if (playButtonText.text == textforPlayBtn[0])
        {
            playButtonText.text = textforPlayBtn[1];
        }
        else if (playButtonText.text == textforPlayBtn[1])
        {
            playButtonText.text = textforPlayBtn[0];
        }

        if (playingMinigame)
        {
            alienScore = tempScore;
            if (tempScore >= alienScore)
            {
                SettingHighScore();
            }

            playingMinigame = false;
        }
        else if(!playingMinigame)
        {
            playingMinigame = true;
        }

        TimerFunc();

        alienMGBehaviorScript.StartAlienMG();
    }
}
