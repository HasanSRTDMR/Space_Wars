using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    private List<GameObject> stars = new List<GameObject>();

    /// <summary>
    /// It returns target star
    /// </summary>
    public GameObject TargetStar
    {
        get
        {
            if (stars.Count>0)
            {
                return stars[0];
            }
            else
            {
                return null;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        CreateStar();
    }



    /// <summary>
    /// When the right mouse button is pressed, it also generates a star game object at the position.
    /// </summary>
    void CreateStar()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            Vector3 posGameWorld = Camera.main.ScreenToWorldPoint(pos);
            stars.Add(Instantiate(starPrefab, posGameWorld, Quaternion.identity));
        }
    }
    /// <summary>
    /// The star, which is sent as a parameter, destroys the game object.
    /// </summary>
    /// <param name="destroyStar"></param>
    public void DestroyStar(GameObject destroyStar)
    {
        stars.Remove(destroyStar);
        Destroy(destroyStar);
    }
}
