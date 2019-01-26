using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<string> currentLetters = new List<string>();

    public bool AlreadySorted(string SortedLetter) {
        return true;
    }
}
