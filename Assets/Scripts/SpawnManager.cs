using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        canvas = GameObject.Find("Enemies");

        spawnRate = 6f;
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
        var adjective = GameManager.Instance.Adjectives();
        // Setting up Sprite
        instantiatedObj.GetComponent<Animator>().runtimeAnimatorController = parent.controller;
        // Setting up scale
        instantiatedObj.transform.localScale = new Vector3(15f, 15f, 15f);
        // Setting up text
        instantiatedObj.transform.GetChild(0).GetComponent<Text>().text = parent.name + " " + adjective.name;
        // Setting up sorted audio clip for the end
        instantiatedObj.GetComponent<AudioSource>().clip = adjective.RandomClip();
    }
}
