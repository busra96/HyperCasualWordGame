using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HintManager : MonoBehaviour
{
    [Header(" Elements ")] 
    [SerializeField] private GameObject keyboard;
    private KeyboardKey[] keys;

    private void Awake()
    {
        keys = keyboard.GetComponentsInChildren<KeyboardKey>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyboardHint()
    {
        string secretWord = WordManager.instance.GetSecretWord();

        List<KeyboardKey> untouchedKeys = new List<KeyboardKey>();

        for (int i = 0; i < keys.Length; i++)
        {
            if (keys[i].IsUntouched())
            {
                untouchedKeys.Add(keys[i]);
            }
        }
        
        //at this point, we have a list of all the untouched keys
        //Let's remove the ones that are in the secret word to avoid graying them out

        List<KeyboardKey> t_untouchedKeys = new List<KeyboardKey>(untouchedKeys);

        for (int i = 0; i < untouchedKeys.Count; i++)
        {
            if (secretWord.Contains(untouchedKeys[i].GetLetter()))
                t_untouchedKeys.Remove(untouchedKeys[i]);
        }

        //At this point, we have a list of all the untouched keys, not contained into the secret word
        
        if(t_untouchedKeys.Count <= 0)
            return;

        int randomKeyIndex = Random.Range(0, t_untouchedKeys.Count);
        t_untouchedKeys[randomKeyIndex].SetInvalid();

    }

    public void LetterHint()
    {
        WordContainer currentWordContainer = InputManager.instance.GetCurrentWordContainer();

        string secretWord = WordManager.instance.GetSecretWord();

        int randomIndex = Random.Range(0, secretWord.Length);

        currentWordContainer.AddAsHint(randomIndex, secretWord[randomIndex]);

    }
}
