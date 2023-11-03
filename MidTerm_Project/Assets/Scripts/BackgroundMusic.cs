using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    public AudioSource src;
    public AudioClip backgroundSound;

    public static BackgroundMusic instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        src.clip = backgroundSound;
        src.volume = 0.5f;
        src.Play();
    }
}
