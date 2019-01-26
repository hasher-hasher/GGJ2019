using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public enum Direction {
        Right = 4,
        Left = 3,
        Up = 1,
        Down = 2
    };

    public Direction direction;

    public GameObject enemyToSpawn;

    public float spawnRate;

    public float moveSpeed = 0;

    private float timer;

    private GameObject canvas;

    private void Start() {
        timer = 0;
        canvas = GameObject.Find("Canvas");

        spawnRate = 4f;
        Spawn();
    }

    private void Update() {
        timer += Time.deltaTime;
        if (timer >= spawnRate) {
            Spawn();
            timer = 0;
        }
    }

    public void Spawn() {
        // Spawn
        GameObject instantiatedObj = Instantiate(enemyToSpawn, transform.position, Quaternion.identity, canvas.transform);
        // Setting up direction
        instantiatedObj.GetComponent<Enemy>().SetupDirection((int)direction);
        // instantiatedObj.GetComponent<Enemy>().moveSpeed = moveSpeed;
        var parent = GameManager.Instance.GetParents();
        // Setting up Sprite
        instantiatedObj.GetComponent<SpriteRenderer>().sprite = parent.sprite;
        // Setting name
        // print(parent.name + " " +GameManager.Instance.Adjectives());
    }
}
