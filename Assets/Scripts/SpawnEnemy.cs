using UnityEngine;

public class SpawnEnemy : MainManager
{
    public GameObject[] enemies;

    private int repeatInterval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CalculateRepeatInterval();
        InvokeRepeating(nameof(Spawn), 1, repeatInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Spawn()
    {
        int randomEnemy = Random.Range(0, enemies.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-11, 11), 8, -1);

        if (EnemiesToSpawn > 0)
        {
            Instantiate(enemies[randomEnemy], spawnPos, enemies[randomEnemy].transform.rotation);

            EnemiesToSpawn--;
        }
        else
        {
            CancelInvoke(nameof(Spawn));
        }
    }

    private void CalculateRepeatInterval()
    {
        if (level > 0 && level < 5)
        {
            repeatInterval = 3;
        }
        else if (level > 5)
        {
            repeatInterval = 2;
        }
    }
}
