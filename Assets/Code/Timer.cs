using System;
using TMPro;
using UnityEngine;

namespace Code
{
    public class Timer : MonoBehaviour
    {
        public TMP_Text timerOut;
        private float timeleft;


        private void Update()
        {
            timeleft += Time.deltaTime;
            timerOut.text = $"Time: {Math.Round(timeleft, 2)}";

            /*if(timeleft<=0)
        {
            print("end game");
        } */
        }
    }
}