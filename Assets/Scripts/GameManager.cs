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

    public List<string> adjectives;

    public float maxSpeed;

    private float timer;

    private int howMuchDead;

    private int howMuchOnCouch;

    public Text CouchUI;
    public Text DeadUI;

    void Start() {
        // Initial value for maxSpeed
        maxSpeed = 0.5f;

        howMuchOnCouch = 0;
        howMuchDead = 0;
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= 15f) {
            print("Aumentou");
            maxSpeed += 0.25f;
            timer = 0;
        }
    }

    public Parents GetParents() {
        return parents[Random.Range(0, parents.Count - 1)];
    }

    public string Adjectives() {
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
        DeadUI.text = "Mortos: " + howMuchDead;
        CouchUI.text = "No sofá: " + howMuchOnCouch;
    }


}

[System.Serializable]
public class Parents {
    public string name;
    public Sprite sprite;
}
