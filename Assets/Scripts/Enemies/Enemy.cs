using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float yValue;
    protected int currentHealth;
    protected int maxHealth;

    public enum EnemyType
    {
        Small,
        Medium,
        Large,
        Boss
    }

    public EnemyType enemyType;

    void Update()
    {
        DestroyOutOfBounds();
    }

    private void DestroyOutOfBounds()
    {
        if (gameObject.transform.position.y < -8.0f)
        {
            Destroy(gameObject);
        }
    }

    public void MoveDown(float yValue, Rigidbody enemyRb)
    {
        Vector3 velocity = enemyRb.linearVelocity;
        velocity.y = -yValue;
        enemyRb.linearVelocity = velocity;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Enemy enemy = gameObject.gameObject.GetComponent<Enemy>();

        if (other.gameObject.CompareTag("Ammo"))
        {
            currentHealth--;

            if (currentHealth == 0)
            {
                Destroy(gameObject);

                if (enemy.enemyType == EnemyType.Small)
                {
                    MainManager.Instance.score += 1;
                }
                else if (enemy.enemyType == EnemyType.Medium)
                {
                    MainManager.Instance.score += 2;
                }
                else if (enemy.enemyType == EnemyType.Large)
                {
                    MainManager.Instance.score += 10;
                }
                else if (enemy.enemyType == EnemyType.Boss)
                {
                    MainManager.Instance.score += 100;
                }
            }
        }
    }
}
