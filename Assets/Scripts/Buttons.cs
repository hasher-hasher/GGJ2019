using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void LoadLevel(string levelName) {
        SceneManager.LoadScene(levelName);
    }

    public void Exit() {
        Application.Quit();
    }

    public void Disable(GameObject other) {
        other.SetActive(false);
    }

    public void Enable(GameObject other) {
        other.SetActive(true);
    }
}
