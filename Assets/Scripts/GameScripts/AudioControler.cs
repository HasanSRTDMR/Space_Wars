using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour
{
    [SerializeField] AudioClip explosionAsteroid;
    [SerializeField] AudioClip explosionShip;
    [SerializeField] AudioClip fire;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void ExplosionAsteroid()
    {
        audio.PlayOneShot(explosionAsteroid);
    }
    public void ExplosionShip()
    {
        audio.PlayOneShot(explosionShip);
    }
    public void Fire()
    {
        audio.PlayOneShot(fire);
    }
  
}
