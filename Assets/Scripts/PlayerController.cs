using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public GameObject ammoPrefab;

    public float forceReducer = 6.0f;

    private readonly float horizontalBoundary = 11.5f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerMovementXAxis();
        CheckAndAdjustXBounds();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ammoObj = Instantiate(ammoPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, gameObject.transform.position.z), ammoPrefab.transform.rotation);

            Rigidbody ammoRb = ammoObj.GetComponent<Rigidbody>();
            if (ammoRb != null)
            {
                ammoRb.AddForce(Vector3.up * 2.0f, ForceMode.Impulse);
            }
        }
    }

    // Moves the player horizontally, and adds velocity when the player stops pressing A or D keys so that the stopping is not instant
    void PlayerMovementXAxis()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerRb.AddForce(Vector3.left / forceReducer, ForceMode.Impulse);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            StopVelocity();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerRb.AddForce(Vector3.right / forceReducer, ForceMode.Impulse);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            StopVelocity();
        }
    }

    // Restricts horizontal movement, so that the player cannot exit the scene and nullifies the linear velocity
    // so that the player can move to the other direction immediatelly
    void CheckAndAdjustXBounds()
    {
        if (gameObject.transform.position.x < -horizontalBoundary)
        {
            gameObject.transform.position = new Vector3(-horizontalBoundary, gameObject.transform.position.y, gameObject.transform.position.z);
            playerRb.linearVelocity = new Vector3(0, 0, 0);
        }

        if (gameObject.transform.position.x > horizontalBoundary)
        {
            gameObject.transform.position = new Vector3(horizontalBoundary, gameObject.transform.position.y, gameObject.transform.position.z);
            playerRb.linearVelocity = new Vector3(0, 0, 0);
        }
    }

    void StopVelocity()
    {
        playerRb.linearVelocity = new Vector3(0, 0, 0);
        playerRb.angularVelocity = new Vector3(0, 0, 0);
    }
}
