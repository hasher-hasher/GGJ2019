using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector2 moveDirection;

    public float moveSpeed = 0f;

    private void Update() {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
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
}
