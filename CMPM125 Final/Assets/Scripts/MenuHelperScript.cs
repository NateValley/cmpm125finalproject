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
        StartCoroutine(WaitToDisplay(3.5f));
    }
    private IEnumerator WaitToDisplay(float time)
	{
        yield return new WaitForSeconds(time);
		uiMan.ChangeToWin();
    }

    public void endLv2(){
        StartCoroutine(WaitToDisplay2(5));
    }
    private IEnumerator WaitToDisplay2(float time)
	{
        yield return new WaitForSeconds(time);
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
