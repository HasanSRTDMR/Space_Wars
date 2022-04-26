using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] GameObject GameNameText;
    [SerializeField] GameObject GameOverText;
    [SerializeField] GameObject Play;
    [SerializeField] Text skorText;
    int point;
    // Start is called before the first frame update
    void Start()
    {
        GameOverText.SetActive(false);
        skorText.gameObject.SetActive(false);

    }
    public void StartedGame()
    {
        Play.SetActive(false);
        GameOverText.SetActive(false);
        GameNameText.SetActive(false);
        skorText.gameObject.SetActive(true);
        UpdateScore();
    }
    void UpdateScore()
    {
        skorText.text = "SKOR: " + point;
    }
    public void GameOver()
    {
        point = 0;
        Play.SetActive(true);
        GameOverText.SetActive(true);
        GameNameText.SetActive(false);
        skorText.gameObject.SetActive(true);
    }


   public void DestroyedAsteroid(GameObject asteroid)
    {
        switch (asteroid.name[8])
        {
            case '1':
                point += 1;
            break;
            case '2':
                point += 5;
                break;
            case '3':
                point += 10;
                break;

        }
        UpdateScore();
    }
}
