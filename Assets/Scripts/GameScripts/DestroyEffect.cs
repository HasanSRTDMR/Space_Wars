using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    private MyTimer destroyTimer;
    // Start is called before the first frame update
    void Start()
    {
        destroyTimer = gameObject.AddComponent<MyTimer>();
        destroyTimer.TotalTime = 1;
        destroyTimer.Begin();
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyTimer.Stop)
        {
            Destroy(gameObject);
        }
    }
}
