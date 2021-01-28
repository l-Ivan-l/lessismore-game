using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameController : MonoBehaviour
{
    public bool gameOver = false;
    private bool onTitleScreen = true;
    public GameObject robot;
    public Volume volume;
    private ColorAdjustments gameColor;

    [Space]
    [Header("UI Dependencies")]
    public Animator canvasAnim;
    public Animator fadeAnim;
    public GameObject creditsPanel;
    public GameObject buttonsPanel;

    private InputMaster inputMaster;

    private void Awake()
    {
        inputMaster = new InputMaster();
        inputMaster.UIActions.CloseReturn.performed += _ => CloseCredits();
    }

    private void Start()
    {
        volume.profile.TryGet(out gameColor);
    }

    private void OnEnable()
    {
        inputMaster.Enable();
    }

    private void OnDisable()
    {
        inputMaster.Disable();
    }

    public void GameOver()
    {
        if(!gameOver)
        {
            gameOver = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Victory()
    {
        if(!gameOver)
        {
            gameOver = true;
            Debug.Log("You escaped from the cave!");
        }
    }

    public void ChangeGameHUE(float _newColor)
    {
        gameColor.hueShift.Override(_newColor);
    }

    #region UI Management
    public void PlayGame()
    {
        canvasAnim.enabled = true;
        robot.SetActive(true);
        onTitleScreen = false;
    }

    public void OpenCredits()
    {
        buttonsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        if(onTitleScreen)
        {
            creditsPanel.SetActive(false);
            buttonsPanel.SetActive(true);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion
}
