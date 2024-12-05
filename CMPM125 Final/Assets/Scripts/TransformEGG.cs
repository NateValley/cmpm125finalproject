using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TransformEGG : MonoBehaviour
{   
    public static float eggsZ = 0;

    [SerializeField] GameObject Egg;
    Slider EggTracker;
    Vector3 ballpos;
    Transform ball;
    void Start()
    {   
        EggTracker = GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>();
        EggTracker.value = 0;
    }
    void Update()
    {   
        ball = Egg.GetComponent<Transform>();
        ballpos = ball.transform.position;
        if(ballpos.z > -2.77){
            //Debug.Log(ballpos.z + 2.76);
            eggsZ = ballpos.z;
            EggTracker.value = (float)(ballpos.z + 2.76);
        }
    }
}
