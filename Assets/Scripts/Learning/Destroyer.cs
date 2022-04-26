using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    GameObject explosionObject;

    MyTimer destroyTimer;
    // Start is called before the first frame update
    void Start()
    {
        destroyTimer = gameObject.AddComponent<MyTimer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyTimer.Stop)
        {
            Instantiate(explosionObject,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
    public void DestroyAsteroid(int time)
    {
        destroyTimer.TotalTime = time;
        destroyTimer.Begin();
    }
}
