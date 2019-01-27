using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : Singleton<GameManager>
{
    // List of available letters

    public List<string> listOfKeys = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "y", "w", "x", "z" };
    // List of removed letters
    public List<string> outKeys = new List<string>();

    public List<Parents> parents;

    public List<Adjectives> adjectives;

    public float maxSpeed;

    private float timer;

    private int howMuchDead;

    private int howMuchOnCouch;

    public Text CouchUI;
    public Text DeadUI;

    // Pause gameObject
    public GameObject pause;
    public GameObject gameOver;

    // Is the gameplay running?
    public bool isPlaying;

    void Start() {
        // Initial value for maxSpeed
        maxSpeed = 0.5f;

        howMuchOnCouch = 0;
        howMuchDead = 0;

        isPlaying = true;
        Time.timeScale = 1f;

        // Reset order in layer
        GameObject.Find("Canvas").GetComponent<Canvas>().sortingOrder = 5;
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= 15f) {
            print("Aumentou");
            maxSpeed += 0.25f;
            timer = 0;
        }

        // Pause handler
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!pause.activeSelf) {
                Time.timeScale = 0f;
                GameObject.Find("Canvas").GetComponent<Canvas>().sortingOrder = 7;
            } else {
                Time.timeScale = 1f;
                GameObject.Find("Canvas").GetComponent<Canvas>().sortingOrder = 5;
            }
            pause.SetActive(!pause.activeSelf);
        }

        // Game Over
        if (howMuchOnCouch >= 5) {
            Time.timeScale = 0f;
            gameOver.SetActive(true);
            isPlaying = false;
            GameObject.Find("Canvas").GetComponent<Canvas>().sortingOrder = 7;
            GameObject.Find("Steps").GetComponent<AudioSource>().Stop();
            GameObject.Find("Mortos").GetComponent<Text>().text = "SCORE: " + howMuchDead;
            foreach (GameObject x in GameObject.FindGameObjectsWithTag("DeleteSubtitle")) {
                Destroy(x);
            }
        }
    }

    public Parents GetParents() {
        return parents[Random.Range(0, parents.Count - 1)];
    }

    public Adjectives Adjectives() {
        return adjectives[Random.Range(0, adjectives.Count - 1)];
    }

    public void AddDead() {
        howMuchDead++;
        Render();
    }

    public void AddCouch()
    {
        howMuchOnCouch++;
        Render();
    }

    // Refresh UI
    public void Render() {
        DeadUI.text = "SCORE: " + howMuchDead;
        CouchUI.text = "INVASORES: " + howMuchOnCouch;
    }


}

[System.Serializable]
public class Parents {
    public string name;
    public RuntimeAnimatorController controller;
}

[System.Serializable]
public class Adjectives {
    public string name;
    public List<AudioClip> clips;

    public AudioClip RandomClip()
    {
        try {
            return clips[Random.Range(0, clips.Count - 1)];
        } catch {
            return null;
        }
    }
}
