using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    float timeleft = 0f;
    public TMP_Text timerOut;

    
    void Update()
    {
        timeleft += Time.deltaTime;
        timerOut.text = ($"Time: {Math.Round(timeleft,2)}"); 

        /*if(timeleft<=0)
        {
            print("end game");
        } */


    }
}
