using UnityEngine;

public class EnemyMedium : Enemy
{
    private Rigidbody rb;
    [SerializeField] private Healthbar healthbar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        yValue = 2.0f;
        maxHealth = 2;
        currentHealth = 2;

        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }

    private void FixedUpdate()
    {
        MoveDown(2.0f, rb);
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }
}
