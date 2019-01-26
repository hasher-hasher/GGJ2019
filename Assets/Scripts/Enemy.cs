using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector2 moveDirection;

    public float moveSpeed = 0f;

    // Is the enemy heading the house?
    public bool headingHouse;

    private GameObject couch;

    private void Start() {
        headingHouse = true;
        couch = null;
    }

    private void Update() {
        if (headingHouse) {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        } else {
            transform.position = Vector2.MoveTowards(transform.position, couch.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    public void SetupDirection(int direction) {
        // Up = 1
        // Down = 2
        // Left = 3
        // Right = 4
        switch(direction) {
            case 1:
                moveDirection = Vector2.up;
            break;
            case 2:
                moveDirection = -Vector2.up;
            break;
            case 3:
                moveDirection = -Vector2.right;
            break;
            case 4:
                moveDirection = Vector2.right;
            break;
            default:
                print("Error");
            break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Button")
        {
            headingHouse = false;
            GameObject target = GameObject.FindWithTag("Couch");
            couch = target;
        }
    }
}
