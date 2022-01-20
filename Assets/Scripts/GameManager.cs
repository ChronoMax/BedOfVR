using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool playingMinigame = false, alienMGbool = false, boxingMGbool = false;
    [Header("General")]
    [SerializeField] Text FPScounterText;

    [Header("AlienAttackMG")]
    [SerializeField] List<string> textforPlayBtn;
    [SerializeField] Text alienTimerText;
    [SerializeField] Text alienScoreText;
    [SerializeField] AlienMGBehavior alienMGBehaviorScript;
    [SerializeField] Text playButtonText;

    [Header("BoxingMG")]
    [SerializeField] List<string> textForBoxingPlayBtn;
    [SerializeField] Text boxingTimerText;
    [SerializeField] Text boxingScoreText;
    [SerializeField] BoxingMGBehavior boxingMGBehavior;
    [SerializeField] Text boxingPlayBtnText;

    float fps;
    float deltaTime;
    float timerSec;
    int tempScore, alienScore, intFps, boxingScore;

    bool toggleCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        playButtonText.text = textforPlayBtn[0];
        boxingPlayBtnText.text = textForBoxingPlayBtn[0];

        FPScounter(toggleCheck);

        SettingHighScoreAlien();
        SetBoxingHighscore();
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

            if (alienMGbool)
            {
                alienTimerText.text = "Time: 0:" + (int)timerSec;
                alienScoreText.text = "Score: " + tempScore;

                if (timerSec <= 0)
                {
                    StartAlienMG();
                }
            }
            else if (boxingMGbool)
            {
                boxingTimerText.text = "Time: 0:" + (int)timerSec;
                boxingScoreText.text = "Score: " + tempScore;

                if (timerSec <= 0)
                {
                    StartBoxingMG();
                }
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
            timerSec = 10f;
        }
    }

    void SettingHighScoreAlien()
    {
        alienScoreText.text = "Highscore: " + alienScore;
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
            alienMGbool = false;
        }
        else if(!playingMinigame)
        {
            SettingHighScoreAlien();
            playingMinigame = true;
            alienMGbool = true;
        }

        TimerFunc();

        alienMGBehaviorScript.StartAlienMG();
    }

    public void StartBoxingMG()
    {
        if (boxingPlayBtnText.text == textForBoxingPlayBtn[0])
        {
            boxingPlayBtnText.text = textForBoxingPlayBtn[1];
        }
        else
        {
            boxingPlayBtnText.text = textForBoxingPlayBtn[0];
        }

        if (playingMinigame)
        {
            if (tempScore > boxingScore)
            {
                boxingScore = tempScore;
            }

            SetBoxingHighscore();
            tempScore = 0;
            playingMinigame = false;
            boxingMGbool = false;
        }
        else if (!playingMinigame)
        {
            SetBoxingHighscore();
            playingMinigame = true;
            boxingMGbool = true;
        }

        TimerFunc();
    }

    void SetBoxingHighscore()
    {
        boxingScoreText.text = "Highscore: " + boxingScore;
    }
}
