using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    float fps;
    float deltaTime;

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
    }

    public void FPScounter(bool toggle)
    {
        FPScounterText.enabled = toggle;
    }

    public void StartAlienMG()
    {
        for (int i = 0; i < textforPlayBtn.Count; i++)
        {
            if (playButtonText.text == textforPlayBtn[0])
            {
                playButtonText.text = textforPlayBtn[1];
            }
            else if (playButtonText.text == textforPlayBtn[1])
            {
                playButtonText.text = textforPlayBtn[0];
            }
        }

        alienMGBehaviorScript.StartAlienMG();
    }
}
