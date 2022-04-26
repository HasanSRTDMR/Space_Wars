using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    const float speed = 10;
    bool collectoring = false;
    private GameObject target;

    private Rigidbody2D rb;
    private Collector collector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collector = Camera.main.GetComponent<Collector>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (!collectoring)
        {
            GoAndCollect();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject==target)
        {
            collector.DestroyStar(target);
            rb.velocity = Vector2.zero;
            GoAndCollect();
        }
    }



    /// <summary>
    /// Goes to the position of the target object and collects
    /// </summary>
    void GoAndCollect()
    {
        target = collector.TargetStar;
        if (target!=null)
        {
            Vector2 targetPlace = new Vector2(target.transform.position.x-transform.position.x,target.transform.position.y-transform.position.y);
            targetPlace.Normalize();
            rb.AddForce(targetPlace*speed,ForceMode2D.Impulse);
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
}
