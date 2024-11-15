using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OnGameOver : MonoBehaviour
{
    public GameObject egg;//assign egg to this
    public float ResetAtY;//desired Y pos to reset game
    void Update(){
        if(egg.transform.position.y < ResetAtY){
            SceneManager.LoadScene("Main");
        }
    }
}
