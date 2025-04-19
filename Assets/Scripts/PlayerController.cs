using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public GameObject ammoPrefab;

    private readonly float horizontalBoundary = 11.5f;
    private readonly float ammoForceMultiplier = 20.0f;
    private readonly float moveSpeed = 10f;

    private float moveInput = 0f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckAndAdjustXBounds();
        Shoot();
        GetInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            MainManager.Instance.lives--;
            Destroy(other.gameObject);
        }
    }

    private void MovePlayer()
    {
        Vector3 velocity = playerRb.linearVelocity;
        velocity.x = moveInput * moveSpeed;
        playerRb.linearVelocity = velocity;
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }
        else
        {
            moveInput = 0f;
        }
    }

    private void Shoot()
    {
        Vector3 pos = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ammoObj = Instantiate(ammoPrefab, new Vector3(pos.x, pos.y + 1, pos.z), ammoPrefab.transform.rotation);

            Rigidbody ammoRb = ammoObj.GetComponent<Rigidbody>();
            if (ammoRb != null)
            {
                ammoRb.AddForce(Vector3.up * ammoForceMultiplier, ForceMode.Impulse);
            }
        }
    }

    private void CheckAndAdjustXBounds()
    {
        Vector3 pos = gameObject.transform.position;

        if (pos.x < -horizontalBoundary)
        {
            pos = new Vector3(-horizontalBoundary, pos.y, pos.z);
            playerRb.linearVelocity = new Vector3(0, 0, 0);
        }

        if (pos.x > horizontalBoundary)
        {
            pos = new Vector3(horizontalBoundary, pos.y, pos.z);
            playerRb.linearVelocity = new Vector3(0, 0, 0);
        }
    }
}
