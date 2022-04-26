using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    private float coliderHalfWitdh;
    private float coliderHalfHeight;
    // Start is called before the first frame update
    void Start()
    {
        // Oyun objesi rastgele hareket eder
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5,5), Random.Range(-5, 5)),ForceMode2D.Impulse);
        BoxCollider2D colider = GetComponent<BoxCollider2D>();
        coliderHalfHeight = colider.size.y / 2;
        coliderHalfWitdh = colider.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Input.mousePosition;
        position.z = -Camera.main.transform.position.z;
        position = Camera.main.ScreenToWorldPoint(position);
        transform.position = position;
        StayScreen();
    }
    /// <summary>
    /// Allows the object to remain in the game
    /// </summary>
    void StayScreen()
    {
        Vector3 position = transform.position;
        if (position.x - coliderHalfWitdh < CalculateScreen.ScreenLeft)
        {
            position.x = CalculateScreen.ScreenLeft+ coliderHalfWitdh;
        }
        else if (position.x + coliderHalfWitdh > CalculateScreen.ScreenRight)
        {
            position.x = CalculateScreen.ScreenRight - coliderHalfWitdh;
        }
        if (position.y - coliderHalfHeight < CalculateScreen.ScreenDown)
        {
            position.y = CalculateScreen.ScreenDown + coliderHalfHeight;
        }
        else if (position.y + coliderHalfHeight > CalculateScreen.ScreenUp)
        {
            position.y = CalculateScreen.ScreenUp - coliderHalfHeight;
        }
        transform.position = position;
    }
}
