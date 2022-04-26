using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    [SerializeField] GameObject spaceCraftPrefab;

    [SerializeField] List<GameObject> asteroidPrefabs = new List<GameObject>();
    List<GameObject> asteroids = new List<GameObject>();
    UIControl uicontrol;
    GameObject spaceCraft;
    int level=1;
    // Start is called before the first frame update
    void Start()
    {
        uicontrol = GetComponent<UIControl>();
    }

    public void GameBegin()
    {
        uicontrol.StartedGame();
        spaceCraft = Instantiate(spaceCraftPrefab);
        spaceCraft.transform.position = new Vector3(0, CalculateScreen.ScreenDown + 1.5f, 0);
        CreateAstroid(5);
    }


    void CreateAstroid(int quantity)
    {
        Vector3 pos = new Vector3();
        for (int i = 0; i < quantity; i++)
        {
            pos.z = -Camera.main.transform.position.z;
            pos = Camera.main.ScreenToWorldPoint(pos);
            pos.x = Random.Range(CalculateScreen.ScreenLeft,CalculateScreen.ScreenRight);
            pos.y = CalculateScreen.ScreenUp - 1f;

            GameObject asteroid = Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Count)],pos,Quaternion.identity);
            asteroids.Add(asteroid);
        }
    }
    public void DestroyedAsteroid(GameObject asteroid)
    {
        uicontrol.DestroyedAsteroid(asteroid);
        asteroids.Remove(asteroid);
        if (asteroids.Count<=1)
        {
            level++;
            CreateAstroid(level * level);
        }
    }
    public void GameOver()
    {
       uicontrol.GameOver();
        foreach (GameObject asteroid in asteroids)
        {
            Destroy(asteroid);
            //asteroid.GetComponent<Asteroid>().DestroyAsteroid();
        }
        asteroids.Clear();
        level = 1;
    }
}
