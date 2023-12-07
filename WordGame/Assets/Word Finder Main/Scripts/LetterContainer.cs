using TMPro;
using UnityEngine;

public class LetterContainer : MonoBehaviour
{
    [Header(" Elements ")] 
    [SerializeField] private SpriteRenderer letterContainer;
    [SerializeField] private TextMeshPro letter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        letter.text = "";
        letterContainer.color = Color.white;
    }

    public void SetLetter(char letter)
    {
        this.letter.text = letter.ToString();
    }

    public void SetValid()
    {
        letterContainer.color = Color.green;
    }

    public void SetPotential()
    {
        letterContainer.color = Color.yellow;
    }

    public void SetInvalid()
    {
        letterContainer.color = Color.grey;
    }

    public char GetLetter()
    {
        return letter.text[0];
    }
}