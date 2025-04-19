using UnityEngine;

public class EnemyBoss : Enemy
{
    private Rigidbody rb;
    [SerializeField] private Healthbar healthbar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        yValue = 0.25f;
        maxHealth = 20;
        currentHealth = 20;

        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        MoveDown(0.25f, rb);
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }
}
