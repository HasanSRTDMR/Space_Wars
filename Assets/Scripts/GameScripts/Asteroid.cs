using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] GameObject explosionObject;
    GameControler gameControler;

   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameControler = Camera.main.GetComponent<GameControler>();
        int rnd = Random.Range(0, 2);
        Vector2 vector = rnd == 0 ? new Vector2(Random.Range(-2.5f, -1f), Random.Range(-2.5f, -1f)) : new Vector2(Random.Range(1f,2.5f), Random.Range(-2.5f, -1f));
        rb.AddForce(vector, ForceMode2D.Impulse);
        float torque = rnd == 0 ? -2f : 2f;
        rb.AddTorque(torque);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Bullet")
        {
            Instantiate(explosionObject,transform.position,Quaternion.identity);
            DestroyAsteroid();
        }
    }
    public void DestroyAsteroid()
    {
        Destroy(gameObject);
        gameControler.DestroyedAsteroid(gameObject);
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioControler>().ExplosionAsteroid();
    }
}
