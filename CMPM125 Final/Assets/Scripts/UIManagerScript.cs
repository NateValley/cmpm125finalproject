using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] Canvas MainMenu;
    [SerializeField] Canvas OptionsMenu;
    [SerializeField] Canvas CreditsMenu;

    [SerializeField] Button PlayButton;
    [SerializeField] Button OptionsButton;
    [SerializeField] Button CreditsButton;
    [SerializeField] Button BackButton;
    
    enum MenuState {
        Main,
        Options,
        Credits
    }

    MenuState CurrentMenu;

    void Start()
    {
        ChangeToMain();
    }
    
    void MenuCheck()
    {
        if (CurrentMenu == MenuState.Main)
        {

            MainMenu.enabled = true;
            OptionsMenu.enabled = false;
            CreditsMenu.enabled = false;

            PlayButton.gameObject.SetActive(true);
            OptionsButton.gameObject.SetActive(true);
            CreditsButton.gameObject.SetActive(true);
            BackButton.gameObject.SetActive(false);

        } else if (CurrentMenu == MenuState.Options)
        {
            MainMenu.enabled = false;
            OptionsMenu.enabled = true;
            CreditsMenu.enabled = false;

            PlayButton.gameObject.SetActive(false);
            OptionsButton.gameObject.SetActive(false);
            CreditsButton.gameObject.SetActive(false);
            BackButton.gameObject.SetActive(true);

        } else if (CurrentMenu == MenuState.Credits)
        {
            MainMenu.enabled = false;
            OptionsMenu.enabled = false;
            CreditsMenu.enabled = true;

            PlayButton.gameObject.SetActive(false);
            OptionsButton.gameObject.SetActive(false);
            CreditsButton.gameObject.SetActive(false);
            BackButton.gameObject.SetActive(true);

        }
    }
    

    public void ChangeToMain()
    {
        CurrentMenu = MenuState.Main;
        MenuCheck();
    }

    public void ChangeToOptions()
    {
        CurrentMenu = MenuState.Options;
        MenuCheck();
    }

    public void ChangeToCredits()
    {
        CurrentMenu = MenuState.Credits;
        MenuCheck();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}