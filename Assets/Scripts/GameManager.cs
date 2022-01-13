using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    float fps;
    float deltaTime;

    bool playingMinigame;

    [SerializeField]
    Text timerText;

    [SerializeField]
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
        }
    }

    public void FPScounter(bool toggle)
    {
        FPScounterText.enabled = toggle;
    }

    void TimerFunc()
    {
        if (playingMinigame)
        {
            timerSec = 60f;
            playingMinigame = false;
        }
        else if (!playingMinigame)
        {
            playingMinigame = true;
        }
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

        TimerFunc();

        alienMGBehaviorScript.StartAlienMG();
    }
}
