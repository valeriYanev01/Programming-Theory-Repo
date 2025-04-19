using UnityEngine;

public class EnemySmall : Enemy
{
    private Rigidbody rb;
    [SerializeField] private Healthbar healthbar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        yValue = 3.0f;
        maxHealth = 1;
        currentHealth = 1;

        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }

    private void FixedUpdate()
    {
        MoveDown(3.0f, rb);
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }
}
