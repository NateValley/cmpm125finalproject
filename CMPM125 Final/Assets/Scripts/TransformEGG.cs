using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TransformEGG : MonoBehaviour
{
    [SerializeField] Slider EggTracker;
    [SerializeField] GameObject Egg;
    Vector3 ballpos;
    Transform ball;
    void Start()
    {
        ball = Egg.GetComponent<Transform>();
        EggTracker.value = 0;
    }
    void Update()
    {   
        //Transform ball = Egg.GetComponent<Transform>();
        ballpos = ball.transform.position;
         if(ballpos.z > -2.77){
            //Debug.Log(ballpos.z + 2.76);
            EggTracker.value = (float)(ballpos.z + 2.76);
        }
    }
}
