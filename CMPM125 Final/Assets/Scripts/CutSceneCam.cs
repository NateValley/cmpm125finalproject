using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CutSceneCam : MonoBehaviour
{
    private Animator anim;
    public GameObject endTransform;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    public void SetEndGamePosition(){
        transform.SetPositionAndRotation(endTransform.transform.position, endTransform.transform.rotation);
    }

    // public void PlayEndLevel(){
    //     anim.Play("Lv1EndCutScene");
    // }
}
