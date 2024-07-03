using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public GameObject pipes;
    public bool gameActive = true;
    public int score = 0;

    [SerializeField] private float spawnRate = 2f;
    private float lastSpawn;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);


        lastSpawn = Time.time;
        SpawnPipe();
    }

    private void Update()
    {
        if (!gameActive)
            GetComponent<GameManager>().enabled = false;

        SpawnPipeSystem();
    }

    private void SpawnPipeSystem()
    {
        if (Time.time - lastSpawn > spawnRate)
        {
            lastSpawn = Time.time;
            SpawnPipe();
        }
    }

    private void SpawnPipe()
    {
        float pipeHeights = Random.Range(-5, 6);
        Vector2 pipeSpawnPosition = new Vector2(transform.position.x, transform.position.y + pipeHeights);
        Instantiate(pipes, pipeSpawnPosition, Quaternion.identity);
    }
}
