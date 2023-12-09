using System;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [Header(" Elements ")] 
    [SerializeField] private WordContainer[] wordContainers;
    [SerializeField] private Button tryButton;
    [SerializeField] private KeyboardColorizer keyboardColorizer;
    

    [Header(" Settings ")] 
    private int currentWordContainerIndex;
    private bool canAddLetter = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Initialize();

        KeyboardKey.onKeyPressed += KeyPressedCallback;
    }

    private void OnDestroy()
    {
        KeyboardKey.onKeyPressed -= KeyPressedCallback;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Initialize()
    {
        for (int i = 0; i < wordContainers.Length; i++)
        {
            wordContainers[i].Initialize();
        }
        
    }
    
    private void KeyPressedCallback(char letter)
    {
        if(!canAddLetter)
            return;
        
        wordContainers[currentWordContainerIndex].Add(letter);
        
        if (wordContainers[currentWordContainerIndex].IsComplete())
        {
            canAddLetter = false;
            EnableTryButton();
            //CheckWord();
            // currentWordContainerIndex++;
        }
    }

    public void CheckWord()
    {
        string wordToCheck = wordContainers[currentWordContainerIndex].GetWord();
        string secretWord = WordManager.instance.GetSecretWord();

        wordContainers[currentWordContainerIndex].Colorize(secretWord);
        keyboardColorizer.Colorize(secretWord, wordToCheck);

        if (wordToCheck == secretWord)
        {
            Debug.Log("Level Complete");
            SetLevelComplete();
        }
        else
        {
            Debug.Log("Wrong Word");
            canAddLetter = true;
            DisableTryButton();
            currentWordContainerIndex++;
        }
    }

    private void SetLevelComplete()
    {
        GameManager.instance.SetGameState(GameState.LevelComplete);
    }


    public void BackspacePressedCallback()
    {
        bool removedLetter =  wordContainers[currentWordContainerIndex].RemoveLetter();
        
        if(removedLetter)
            DisableTryButton();
        
        canAddLetter = true;
    }

    private void EnableTryButton()
    {
        tryButton.interactable = true;
    }

    private void DisableTryButton()
    {
        tryButton.interactable = false;
    }
    
}
