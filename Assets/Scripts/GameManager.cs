using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : Singleton<GameManager>
{
    // List of available letters

    public List<string> listOfKeys = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "y", "w", "x", "z" };
    // List of removed letters
    public List<string> outKeys = new List<string>();

    public List<Parents> parents;

    public List<string> adjectives;

    public Parents GetParents() {
        return parents[Random.Range(0, parents.Count - 1)];
    }

    public string Adjectives() {
        return adjectives[Random.Range(0, adjectives.Count - 1)];
    }
}

[System.Serializable]
public class Parents {
    public string name;
    public Sprite sprite;
}
