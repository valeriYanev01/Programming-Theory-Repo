using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DestroyOutOfBounds();
    }

    void FixedUpdate()
    {
        Vector3 velocity = enemyRb.linearVelocity;
        velocity.y = -1f;
        enemyRb.linearVelocity = velocity;
    }

    private void DestroyOutOfBounds()
    {
        if (gameObject.transform.position.y < -8.0f)
        {
            Destroy(gameObject);
        }
    }
}
