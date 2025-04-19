using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject enemyBoss;

    private int level;
    public int enemiesToSpawn;

    private int repeatInterval;

    void Start()
    {
        level = GameManager.Instance.playerData.level;
        enemiesToSpawn = level * 5;

        CalculateRepeatInterval();

        if (level % 5 == 0)
        {
            enemiesToSpawn = 1;
            InvokeRepeating(nameof(SpawnBoss), 1, repeatInterval);
        }
        else
        {
            InvokeRepeating(nameof(Spawn), 1, repeatInterval);
        }
    }

    private void Spawn()
    {
        int randomEnemy = Random.Range(0, enemies.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-11, 11), 8, -1);

        if (enemiesToSpawn > 0)
        {
            Instantiate(enemies[randomEnemy], spawnPos, enemies[randomEnemy].transform.rotation);

            enemiesToSpawn--;
        }
        else
        {
            int currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (currentEnemies == 0)
            {
                CancelInvoke(nameof(Spawn));
                ProceedToTheNextLevel();
            }
        }
    }

    private void SpawnBoss()
    {
        Debug.Log(enemiesToSpawn);

        Vector3 spawnPos = new Vector3(Random.Range(-11, 11), 8, -1);

        if (enemiesToSpawn > 0)
        {
            Instantiate(enemyBoss, spawnPos, enemyBoss.transform.rotation);

            enemiesToSpawn--;
        }
        else
        {
            int currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (currentEnemies == 0)
            {
                CancelInvoke(nameof(SpawnBoss));
                ProceedToTheNextLevel();
            }
        }
    }

    private void CalculateRepeatInterval()
    {
        if (level > 0 && level <= 5)
        {
            repeatInterval = 3;
        }
        else if (level > 5)
        {
            repeatInterval = 2;
        }
    }

    // Load the next level scene
    private void ProceedToTheNextLevel()
    {
        GameManager.Instance.playerData.level++;

        MainManager.Instance.lives = 3;

        SceneManager.LoadScene(2);
    }
}
