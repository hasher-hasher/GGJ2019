using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputManager : MonoBehaviour
{
    // Pai - Q e W
    // Filha - V e B
    // Mae - O e P

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

    // First button Game Object component
    public GameObject firstButton;

    // Second button Game Object component
    public GameObject secondButton;

    public string firstButtonDefault;
    public string secondButtonDefault;

    private Animator anim;

    private void Start() {
        letterSortRate = 10;

        anim = transform.GetChild(0).GetComponent<Animator>();
        // print(anim.runtimeAnimatorController);

        Setup();
    }
    
    private void Update() {
        if (GameManager.Instance.isPlaying) {
            if (Input.GetKeyDown(firstSortedButton)) {
                SortLetter("first", true);
                anim.SetTrigger("Attack");
            }

            if (Input.GetKeyDown(secondSortedButton))
            {
                SortLetter("second", true);
                anim.SetTrigger("Attack");
            }
        }
    }

    public void SortLetter(string firstOrSecondButton, bool pressed = false) {
        switch(firstOrSecondButton) {
            case "first":
                if (pressed) {
                    // Run Kill() function of button
                    firstButton.GetComponent<KillManager>().Kill();
                }
                // Append the last sorted letter to the main list
                AddToMainList(firstSortedButton);
                firstSortedButton = GameManager.Instance.listOfKeys[Random.Range(0, GameManager.Instance.listOfKeys.Count - 1)];
                // Remove the new sorted letter from the main list
                RemoveFromMainList(firstSortedButton);
                RenderButton();
            break;
            case "second":
                // Run Kill() function of button
                secondButton.GetComponent<KillManager>().Kill();
                // Append the last sorted letter to the main list
                AddToMainList(secondSortedButton);
                secondSortedButton = GameManager.Instance.listOfKeys[Random.Range(0, GameManager.Instance.listOfKeys.Count - 1)];
                // Remove the new sorted letter from the main list
                RemoveFromMainList(secondSortedButton);
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

    public void RemoveFromMainList(string letterToRemove) {
        GameManager.Instance.listOfKeys.Remove(letterToRemove);
        GameManager.Instance.outKeys.Add(letterToRemove);
    }

    public void AddToMainList(string letterToAppend) {
        GameManager.Instance.outKeys.Remove(letterToAppend);
        GameManager.Instance.listOfKeys.Add(letterToAppend);
    }

    // Setup keys and render on startup
    public void Setup() {
        firstSortedButton = firstButtonDefault;
        secondSortedButton = secondButtonDefault;

        RemoveFromMainList(firstSortedButton);
        RemoveFromMainList(secondSortedButton);

        firstButtonText.GetComponent<Text>().text = firstSortedButton;
        secondButtonText.GetComponent<Text>().text = secondSortedButton;
    }
}
