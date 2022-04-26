using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialDestroyer : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidPrefab;
    [SerializeField]
    private GameObject shipPrefab;
   
    List <GameObject> asteridList;
    private GameObject targetAsteroid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateAsteroid();
        }
        if (Input.GetMouseButtonDown(1))
        {
            DestroyTarget();
        }
    }
    /// <summary>
    /// Creates the asterid game object at mouse position.
    /// </summary>
    void CreateAsteroid()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = -Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        GameObject asteroids = Instantiate(asteroidPrefab, pos, Quaternion.identity);
        asteridList.Add(asteroids);
    }
    /// <summary>
    /// Destroys the target object.
    /// </summary>
    public void DestroyTarget()
    {
        targetAsteroid = NearistAsteroid();
        if (targetAsteroid!=null)
        {
            targetAsteroid.GetComponent<Destroyer>().DestroyAsteroid(1);
            asteridList.Remove(targetAsteroid);
        }
    }
    /// <summary>
    /// Returns the nearest asteroid object.
    /// </summary>
    /// <returns></returns>
    GameObject NearistAsteroid()
    {
        GameObject nearistAsteroid;
        float nearistDistance;
        if (asteridList.Count==0)
        {
            return null;
        }
        else
        {
            nearistAsteroid = asteridList[0];
            nearistDistance = CalculateDistance(nearistAsteroid);
        }
        foreach (GameObject asteroid in asteridList)
        {
            float distance = CalculateDistance(asteroid);
            if (distance<nearistDistance)
            {
                nearistDistance = distance;
                nearistAsteroid = asteroid;
            }

        }
        return nearistAsteroid;
    }
    /// <summary>
    /// Returns the distance between the asteroid and the spaceship.
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    float CalculateDistance(GameObject target)
    {
        return Vector3.Distance(shipPrefab.transform.position, target.transform.position);
    }
}
