using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillManager : MonoBehaviour
{
    public Color normalColor;
    public Color killColor;

    private bool someoneInside;
    private GameObject enemy;

    private void Start() {
        GetComponent<RawImage>().color = normalColor;

        someoneInside = false;
    }

    public void Kill() {
        if (someoneInside) {
            Destroy(enemy);
            print("Destroooooooooooooooy");
        } else {
            print("Nobody's here!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            GetComponent<RawImage>().color = killColor;
            enemy = other.gameObject;
            someoneInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            GetComponent<RawImage>().color = normalColor;
            enemy = null;
            someoneInside = false;
        }
    }
}
