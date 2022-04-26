using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCraftConrol : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject explosionObject;
    const float speed = 5;
    GameControler gameControler;
    // Start is called before the first frame update
    void Start()
    {
        gameControler = Camera.main.GetComponent<GameControler>();
    }

    // Update is called once per frame
    void Update()
    {
        ShipMove();

        if (Input.GetButtonDown("Jump"))
        {
            CreateBullet();
        }
    }
    /// <summary>
    /// Allows horizontal and vertical axis movement of the object using the keyboard and joystick.
    /// </summary>
    private void ShipMove()
    {
        Vector3 pos = transform.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0)
        {
            pos.x += horizontalInput * speed * Time.deltaTime;
        }
        if (verticalInput != 0)
        {
            pos.y += verticalInput * speed * Time.deltaTime;
        }
        transform.position = pos;
    }
    
    private void CreateBullet()
    {
        Vector3 bulletPos = transform.position;
        bulletPos.y += 1;
        Instantiate(bulletPrefab, bulletPos, Quaternion.identity);
        GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioControler>().Fire();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Asteroid")
        {
           
            Instantiate(explosionObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
            gameControler.GameOver();
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioControler>().ExplosionShip();

        }
    }
}   
