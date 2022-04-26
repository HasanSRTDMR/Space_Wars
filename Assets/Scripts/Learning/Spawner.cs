using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject astroidPrefab;
    MyTimer myTimer;

    // Start is called before the first frame update
    void Start()
    {
        myTimer = gameObject.AddComponent<MyTimer>();
        myTimer.TotalTime = 1;
        myTimer.Begin();
    }

    // Update is called once per frame
    void Update()
    {
        if (myTimer.Stop)
        {
            SpownAstroid();
            myTimer.Begin();
        }
    }
    void SpownAstroid()
    {
    
        Instantiate(astroidPrefab);
    }
}
