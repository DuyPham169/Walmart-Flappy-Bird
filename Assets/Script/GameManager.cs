using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameActive = true;
    public GameObject gameOverScreen;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pipes;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float spawnRate = 2f;
    private float lastSpawn;
    private int score = 0;

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
        GameOverCheck();
        SpawnPipeSystem();
    }

    private void GameOverCheck()
    {
        if (!gameActive)
            GetComponent<GameManager>().enabled = false;
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

    public void AddScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
