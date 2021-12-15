using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class MainMenuController : MonoBehaviour
{
    int selectedCanvas;
    bool mainMenuOn;

    [SerializeField]
    GameObject[] canvasses;

    [SerializeField]
    Animator CanvassesAnimator;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void OnPlayBttnClicked()
    {
        //Play animation
        CanvassesAnimator.SetBool("EnableAnimation", true);
        //start the simulation
        //disable canvas
        StartCoroutine(AnimaionFinished());
    }

    IEnumerator AnimaionFinished()
    {
        yield return new WaitForSeconds(4);

        for (int i = 0; i < canvasses.Length; i++)
        {
            canvasses[i].SetActive(false);
        }
    }

    public void OnSettingsBttnClicked()
    {
        //Show settings
        mainMenuOn = false;
        SwitchMainMenu();

        selectedCanvas = 2;
        SwitchCanvas();
    }

    public void OnReviewBttnClicked()
    {
        //Show review
        mainMenuOn = false;
        SwitchMainMenu();

        selectedCanvas = 3;
        SwitchCanvas();
    }

    public void OnCreditsBttnClicked()
    {
        //Show Credits
        mainMenuOn = false;
        SwitchMainMenu();

        selectedCanvas = 4;
        SwitchCanvas();
    }

    public void OnBackBttnClicked()
    {
        //headback to main menu
        canvasses[selectedCanvas].SetActive(false);

        mainMenuOn = true;
        SwitchMainMenu();
    }

    public void ButtonFPS(bool toggle)//Show fps counter
    {
        gameManager.FPScounter(toggle);
    }

    void SwitchCanvas()
    {
        canvasses[selectedCanvas].SetActive(true);
    }

    void SwitchMainMenu()
    {
        selectedCanvas = 1;
        canvasses[selectedCanvas].SetActive(mainMenuOn);
    }
}
