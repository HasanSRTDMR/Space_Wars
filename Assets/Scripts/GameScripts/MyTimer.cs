using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTimer : MonoBehaviour

{
    /// <summary>
    /// Sets the total duration of the countdown timer
    /// </summary>
    private float _totalTime;
    public float TotalTime
    {
        get
        {
            return _totalTime;
        }

        set
        {
            if (!running)
            {
                _totalTime = value;
            }
            else
            {
                _totalTime = 0;
            }
        }
       
    }
  
    bool running=false;
    bool started=false;
    float elapsedTime;

    public bool Stop 
    {
        get { return started && !running; }        
    }
 
    public void Begin()
    {
        if (TotalTime>0)
        {
            started = true;
            running = true;
            elapsedTime = 0;
        }
    }
    void Update()
    {
        if (running)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= TotalTime)
            {
                running= false;
            }
        }
    }

}
