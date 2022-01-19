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

        SettingHighScoreAlien();
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
            scoreText.text = "Score: " + tempScore;

            if (timerSec <= 0)
            {
                StartAlienMG();
            }            
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

    void SettingHighScoreAlien()
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
            if (tempScore > alienScore)
            {
                alienScore = tempScore;
            }

            SettingHighScoreAlien();

            tempScore = 0;

            playingMinigame = false;
        }
        else if(!playingMinigame)
        {
            SettingHighScoreAlien();
            playingMinigame = true;
        }

        TimerFunc();

        alienMGBehaviorScript.StartAlienMG();
    }
}
