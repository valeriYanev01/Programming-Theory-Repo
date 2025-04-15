using UnityEngine;

public class SpawnEnemy : MainManager
{
    public GameObject[] enemies;

    private int enemiesToSpawn = level * 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1, 3);
    }

    // Update is called once per frame
    void Update()
    {

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
            CancelInvoke(nameof(Spawn));
        }
    }
}
