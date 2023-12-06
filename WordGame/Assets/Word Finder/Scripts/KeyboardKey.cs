using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardKey : MonoBehaviour
{

    [Header(" Elements ")]
    [SerializeField]
    private TextMeshProUGUI letterText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Test);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Test()
    {
        Debug.Log(letterText.text);
    }
}
