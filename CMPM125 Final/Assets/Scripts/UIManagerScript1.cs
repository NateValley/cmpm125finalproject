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

    [SerializeField] Slider BallSlider;
    
    enum MenuState {
        HUD,
        Win,
    }

    MenuState CurrentMenu;
    void Awake(){
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        ChangeToHUD();
    }
    
    void MenuCheck()
    {
        if (CurrentMenu == MenuState.HUD)
        {
            GameHUD.enabled = true;
            WinMenu.enabled = false;

            BallSlider.gameObject.SetActive(true);

        }
        else if (CurrentMenu == MenuState.Win)
        {
            GameHUD.enabled = false;
            WinMenu.enabled = true;

            BallSlider.gameObject.SetActive(false);

        }
    }
    

    public void ChangeToHUD()
    {
        CurrentMenu = MenuState.HUD;
        MenuCheck();
    }

    public void ChangeToWin()
    {
        CurrentMenu = MenuState.Win;
        MenuCheck();
    }
    public bool checkHunterWin(){//Check if the hunter win menu enabled, to be used with counter script
        return WinMenu.enabled;
    }

    // public void StartGame()
    // {
    //     SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    // }
}