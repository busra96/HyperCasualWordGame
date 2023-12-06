using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header(" Elements ")] 
    [SerializeField] private WordContainer[] wordContainers;

    [Header(" Settings ")] 
    private int currentWordContainerIndex;
    private bool canAddLetter = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Initialize();

        KeyboardKey.onKeyPressed += KeyPressedCallback;
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
            //CheckWord();
            // currentWordContainerIndex++;
        }
    }

    public void CheckWord()
    {
        string wordToCheck = wordContainers[currentWordContainerIndex].GetWord();
        string secretWord = WordManager.instance.GetSecretWord();

        if (wordToCheck == secretWord)
            Debug.Log("Level Complete");
        else
        {
            Debug.Log("Wrong Word");
            canAddLetter = true;
            currentWordContainerIndex++;
        }
    }


    public void BackspacePressedCallback()
    {
        wordContainers[currentWordContainerIndex].RemoveLetter();
        canAddLetter = true;
    }
    
}
