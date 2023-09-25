using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioManager;

    [SerializeField] private AudioClip IntroMusic;
    [SerializeField] private AudioClip LevelSound;
    
    [SerializeField] private float introLength = 15;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GetComponent<AudioSource>();
        audioManager.clip = IntroMusic;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > introLength && audioManager.clip == IntroMusic)
        {
            audioManager.clip = LevelSound;
            audioManager.Play();
        }   
    }
}
