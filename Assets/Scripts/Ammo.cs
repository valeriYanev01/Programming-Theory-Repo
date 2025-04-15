using UnityEngine;

public class Ammo : MainManager
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DestroyObjectOutOfBounds();
    }

    private void DestroyObjectOutOfBounds()
    {
        if (gameObject.transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            score += 5;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
