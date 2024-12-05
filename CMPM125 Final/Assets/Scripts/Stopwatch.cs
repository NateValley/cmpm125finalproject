using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text title;
    public float currTime = 0;
    private bool active = true;

    private IEnumerator IncrementTime(float time)
	{
		// Loop indefinitely until stopped
		while (active)
		{
            currTime += time;
            title.text = currTime.ToString("F2")+"s";
        	yield return new WaitForSeconds(time);
        }
    }

    public void SetInactive(){
        active = false;
    }
    
    public void SetActive(){
        active = true;
		StartCoroutine(IncrementTime(.01f));
    }
}
