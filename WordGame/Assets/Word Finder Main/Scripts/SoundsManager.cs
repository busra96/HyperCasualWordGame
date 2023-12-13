using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager instance;

    [Header(" Sounds ")] 
    [SerializeField] private AudioSource buttonSound;
    
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonSound()
    {
        buttonSound.Play();
    }

    public void EnableSounds()
    {
        buttonSound.volume = 1;
    }

    public void DisableSounds()
    {
        buttonSound.volume = 0;
    }
}
