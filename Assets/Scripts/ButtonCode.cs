using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonCode : MonoBehaviour
{
    public GameObject quitButton, scoreBoard, startButton, controls, backButton, cntrButton, logo, creds, credsButton, credsBack;
    public Movimento player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Iniciar()
    {
        SceneManager.LoadSceneAsync("Jogo");
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void ShowCntrls()
    {
        logo.SetActive(false);
        startButton.SetActive(false);
        scoreBoard.SetActive(false);
        quitButton.SetActive(false);
        controls.SetActive(true);
        backButton.SetActive(true);
        cntrButton.SetActive(false);
        creds.SetActive(false);
        credsButton.SetActive(false);
        credsBack.SetActive(false);
    }

    public void hideCntrls()
    {
        logo.SetActive(true);
        cntrButton.SetActive(true);
        startButton.SetActive(true);
        scoreBoard.SetActive(true);
        quitButton.SetActive(true);
        controls.SetActive(false);
        backButton.SetActive(false);
        creds.SetActive(false);
        credsButton.SetActive(true);
        credsBack.SetActive(false);
    }

    public void menuBack()
    {

        player.pauseScreen.SetActive(false);
        player.paused = false;
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Menu");
    }

    public void menuCreds()
    {
        logo.SetActive(false);
        cntrButton.SetActive(false);
        startButton.SetActive(false);
        scoreBoard.SetActive(false);
        quitButton.SetActive(false);
        controls.SetActive(false);
        backButton.SetActive(false);
        creds.SetActive(true);
        credsButton.SetActive(false);
        credsBack.SetActive(true);
    }
    public void menuCredsBack()
    {
        logo.SetActive(true);
        cntrButton.SetActive(true);
        startButton.SetActive(true);
        scoreBoard.SetActive(true);
        quitButton.SetActive(true);
        controls.SetActive(false);
        backButton.SetActive(false);
        creds.SetActive(false);
        credsButton.SetActive(true);
        credsBack.SetActive(false);
    }

}
