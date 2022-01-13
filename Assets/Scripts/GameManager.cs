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
}
