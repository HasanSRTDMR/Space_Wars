using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    MyTimer timer;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        timer = gameObject.AddComponent<MyTimer>();
        timer.TotalTime = 3;
        timer.Begin();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Stop)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Asteroid")
        {
            Destroy(gameObject);
        }
    }
}
