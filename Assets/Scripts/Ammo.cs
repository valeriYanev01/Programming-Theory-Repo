using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
