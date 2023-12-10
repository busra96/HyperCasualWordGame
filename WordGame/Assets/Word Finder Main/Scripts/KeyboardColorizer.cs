using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardColorizer : MonoBehaviour
{
    [Header(" Elements ")]
    private KeyboardKey[] keys;

    private void Awake()
    {
        keys = GetComponentsInChildren<KeyboardKey>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }
    
    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }
    
    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Game:
               
                Initialize();
                
                break;
            
            case GameState.LevelComplete:
                break;
        }
    }

    private void Initialize()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].Initialize();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Colorize(string secretWord, string wordToCheck)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            char keyLetter = keys[i].GetLetter();

            for (int j = 0; j < wordToCheck.Length; j++)
            {
                if(keyLetter != wordToCheck[j])
                    continue;
                
                //the key letter we've pressed is equals to the curret wordToCheck letter

                if (keyLetter == secretWord[j])
                {
                    //Valid
                    keys[i].SetValid();
                }
                else if (secretWord.Contains(keyLetter))
                {
                    //Potential
                    keys[i].SetPotential();
                }
                else
                {
                    //Invalid
                    keys[i].SetInvalid();
                }
            }
        }
    }
}
