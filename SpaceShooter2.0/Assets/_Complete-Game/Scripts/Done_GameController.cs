using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using System;

public class Done_GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    public Action m_WaveChange;

    private bool gameOver;
    private bool restart;
    private int score;

    public int m_PlayerCount = 0;

    public Transform m_Player1Spawn;
    public Transform m_Player2Spawn;

    public Transform m_SinglePlayerSpawn;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());

        SpawnPlayers();
    }

    private void SpawnPlayers()
    {
        if(PlayerManager.Instance.GetPlayerShip(0))
        {
            if(PlayerManager.Instance.GetPlayerShip(1) == null)
            {
                m_PlayerCount++;
                Instantiate(PlayerManager.Instance.GetPlayerShip(0), m_SinglePlayerSpawn.position, m_SinglePlayerSpawn.rotation);
            }
            else
            {
                m_PlayerCount++;
                Instantiate(PlayerManager.Instance.GetPlayerShip(0), m_Player1Spawn.position, m_Player1Spawn.rotation);
            }
           
        }
        if(PlayerManager.Instance.GetPlayerShip(1))
        {
            m_PlayerCount++;
            Instantiate(PlayerManager.Instance.GetPlayerShip(1), m_Player2Spawn.position, m_Player2Spawn.rotation);
        }
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[UnityEngine.Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
            else
            {
                if (m_WaveChange != null)
                {
                    m_WaveChange();
                }
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        m_PlayerCount--;

        if(m_PlayerCount == 0)
        {
            gameOverText.text = "Game Over!";
            gameOver = true;
        }
    }
}