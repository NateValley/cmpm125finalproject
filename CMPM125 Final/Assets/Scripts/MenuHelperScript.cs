using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MenuHelperScript : MonoBehaviour
{
    private UIManagerScript uiMan; 
    // Start is called before the first frame update
    void Start()
    {
        uiMan = FindAnyObjectByType<UIManagerScript>();
    }

    // ---- Menu Change ----

    public void endLv1(){
        uiMan.ChangeToWin();
    }

    public void endLv2(){
        uiMan.ChangeToWin2();
    }

    public void menuHUD(){
        uiMan.ChangeToHUD();
    }


    // ---- Stopwatch ----
    public void StartTimer(){
        uiMan.timerOn();
    }

    public void StopTimer(){
        uiMan.timerOff();
    }

}
