using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTest : MonoBehaviour
{
    MyTimer myTimer;
    float startTime;



    // Start is called before the first frame update
    void Start()
    {
        myTimer = gameObject.AddComponent<MyTimer>();
        myTimer.TotalTime = 3;
        myTimer.Begin();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (myTimer.Stop)
        {
            float elapsedTime = Time.time-startTime;
            Debug.Log(elapsedTime);

            startTime = Time.time;
            myTimer.Begin();
        }
    }
}
