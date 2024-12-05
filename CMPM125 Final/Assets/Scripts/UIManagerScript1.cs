using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] Canvas GameHUD;
    [SerializeField] Canvas WinMenu;
    [SerializeField] Canvas WinMenu2;

    [SerializeField] Canvas MainMenu;

    [SerializeField] Canvas CreditsMenu;

    [SerializeField] Slider BallSlider;
    
    enum MenuState {
        HUD,
        Win,

        Main,

        Credits,

        Win2,
    }

    MenuState CurrentMenu;
    void Awake(){
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        ChangeToMain();
    }
    void Update(){
        if(TransformEGG.eggsZ > 147 && CurrentMenu == MenuState.HUD){
            CurrentMenu = MenuState.Win;
            MenuCheck();
        }
    }
    
    void MenuCheck()
    {
        if (CurrentMenu == MenuState.HUD)
        {
            GameHUD.enabled = true;
            WinMenu.enabled = WinMenu2.enabled =MainMenu.enabled = CreditsMenu.enabled = false;

            BallSlider.gameObject.SetActive(true);

        }
        else if (CurrentMenu == MenuState.Win)
        {
            GameHUD.enabled = WinMenu2.enabled = MainMenu.enabled = CreditsMenu.enabled = false;
            WinMenu.enabled = true;

            BallSlider.gameObject.SetActive(false);

        }
        else if (CurrentMenu == MenuState.Win2)
        {
            GameHUD.enabled = WinMenu.enabled = MainMenu.enabled = CreditsMenu.enabled = false;
            WinMenu2.enabled = true;

            BallSlider.gameObject.SetActive(false);

        }
        else if (CurrentMenu == MenuState.Main)
        {
            GameHUD.enabled = WinMenu.enabled = WinMenu2.enabled = CreditsMenu.enabled = false;
            MainMenu.enabled = true;

            BallSlider.gameObject.SetActive(false);

        }
        else if (CurrentMenu == MenuState.Credits)
        {
            GameHUD.enabled = WinMenu.enabled = WinMenu2.enabled = MainMenu.enabled = false;
            CreditsMenu.enabled = true;

            BallSlider.gameObject.SetActive(false);

        }
    }
    //functions for changing menu----------------------------------

    public void ChangeToHUD()
    {
        CurrentMenu = MenuState.HUD;
        MenuCheck();
    }

    public void ChangeToMain()
    {
        CurrentMenu = MenuState.Main;
        MenuCheck();
    }

    public void ChangeToWin()
    {
        CurrentMenu = MenuState.Win;
        MenuCheck();
    }
    public void ChangeToWin2()
    {
        CurrentMenu = MenuState.Win2;
        MenuCheck();
    }
    public void ChangeToCredits()
    {
        CurrentMenu = MenuState.Credits;
        MenuCheck();
    }
    
    public bool checkHunterWin(){//Check if the hunter win menu enabled, to be used with counter script
        return WinMenu.enabled;
    }
    public void playmenu(){
        SceneManager.LoadScene("Main");
    }

    // public void StartGame()
    // {
    //     SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    // }
}