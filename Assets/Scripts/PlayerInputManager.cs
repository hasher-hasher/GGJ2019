using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputManager : MonoBehaviour
{
    // List of available letters
    [HideInInspector]
    public List<string> listOfKeys = new List<string> {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "y", "w", "x", "z"};

    // Every x seconds the sort method will be called
    public float letterSortRate = 0;

    // Sorted letter for the first key
    [HideInInspector]
    public string firstSortedButton = "";

    // Sorted letter for the second key
    [HideInInspector]
    public string secondSortedButton = "";

    // First button Text component
    public Text firstButtonText;

    // Second button Text component
    public Text secondButtonText;

    private void Start() {
        letterSortRate = 10;

        SortLetter("first");
        SortLetter("second");
    }
    
    private void Update() {
        if (Input.GetKeyDown(firstSortedButton)) {
            SortLetter("first");
        }

        if (Input.GetKeyDown(secondSortedButton))
        {
            SortLetter("second");
        }
    }

    public void SortLetter(string firstOrSecondButton) {
        switch(firstOrSecondButton) {
            case "first":
                firstSortedButton = listOfKeys[Random.Range(0, listOfKeys.Count - 1)];
                RenderButton();
            break;
            case "second":
                secondSortedButton = listOfKeys[Random.Range(0, listOfKeys.Count - 1)];
                RenderButton();
            break;
            default:
                print("just pass");
            break;
        }
    }

    public void RenderButton() {
        firstButtonText.GetComponent<Text>().text = firstSortedButton;
        secondButtonText.GetComponent<Text>().text = secondSortedButton;
    }
}
