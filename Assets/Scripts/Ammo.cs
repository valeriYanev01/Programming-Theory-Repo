using UnityEngine;

public class Ammo : MonoBehaviour
{
    void Update()
    {
        DestroyObjectOutOfBounds();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void DestroyObjectOutOfBounds()
    {
        if (gameObject.transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
