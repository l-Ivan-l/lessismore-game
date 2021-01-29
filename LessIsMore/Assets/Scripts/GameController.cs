using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool gameOver = false;
    private bool onTitleScreen = true;
    private bool onCreditsPanel = false;
    private bool onTutorialPanel = false;
    private bool win = false;
    public GameObject robot;
    public Volume volume;
    private ColorAdjustments gameColor;

    [Space]
    [Header("UI Dependencies")]
    public Animator canvasAnim;
    public Animator fadeAnim;
    public GameObject creditsPanel;
    public GameObject buttonsPanel;
    public GameObject tutorialPanel;
    public Button playBtn;
    public Button creditsBtn;
    public Button tutorialBtn;

    private InputMaster inputMaster;

    [Space]
    public Animator lightAnim;

    [SerializeField]
    private SoundManager soundManager;

    private void Awake()
    {
        inputMaster = new InputMaster();
        inputMaster.UIActions.CloseReturn.performed += _ => CloseCredits();
        inputMaster.UIActions.CloseReturn.performed += _ => CloseTutorial();
        inputMaster.UIActions.CloseReturn.performed += _ => QuitGameAfterWin();
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
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        //Change to black palette and turn off lights
        gameColor.saturation.Override(-100f);
        lightAnim.enabled = true;
        yield return new WaitForSeconds(1f);
        //Activate fade out
        fadeAnim.SetTrigger("GameOver");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator WinGame()
    {
        yield return new WaitForSeconds(1f);
        //Activate win panel
        canvasAnim.SetTrigger("Win");
        win = true;
    }

    public void Victory()
    {
        if(!gameOver)
        {
            gameOver = true;
            //Debug.Log("You escaped from the cave!");
            StartCoroutine(WinGame());
        }
    }

    public void ChangeGameHUE(float _newColor)
    {
        soundManager.PlayColorChangeSound(1f);
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
        onCreditsPanel = true;
    }

    public void CloseCredits()
    {
        if(onTitleScreen && onCreditsPanel)
        {
            creditsPanel.SetActive(false);
            buttonsPanel.SetActive(true);
            playBtn.Select();
            onCreditsPanel = false;
            //creditsBtn.GetComponent<Animator>().SetTrigger(creditsBtn.animationTriggers.normalTrigger);
        }
    }

    public void OpenTutorial()
    {
        buttonsPanel.SetActive(false);
        tutorialPanel.SetActive(true);
        onTutorialPanel = true;
    }

    public void CloseTutorial()
    {
        if (onTitleScreen && onTutorialPanel)
        {
            tutorialPanel.SetActive(false);
            buttonsPanel.SetActive(true);
            playBtn.Select();
            onTutorialPanel = false;
            //tutorialBtn.GetComponent<Animator>().SetTrigger(creditsBtn.animationTriggers.normalTrigger);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void QuitGameAfterWin()
    {
        if(win)
        {
            Application.Quit();
        }
    }
    #endregion
}
