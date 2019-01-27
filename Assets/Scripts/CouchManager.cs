using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouchManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            GameManager.Instance.AddCouch();
            other.GetComponent<AudioSource>().Play();
        }
    }
}
