using UnityEngine;

public class WordContainer : MonoBehaviour
{

    [Header(" Elements ")] 
    private LetterContainer[] letterContainers;

    private void Awake()
    {
        letterContainers = GetComponentsInChildren<LetterContainer>();
        Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void Initialize()
    {
        for (int i = 0; i < letterContainers.Length; i++)
        {
            letterContainers[i].Initialize();
        }
    }
    
    
}
