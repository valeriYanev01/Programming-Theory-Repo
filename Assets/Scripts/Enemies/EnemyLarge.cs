using UnityEngine;

public class EnemyLarge : Enemy
{
    private Rigidbody rb;
    [SerializeField] private Healthbar healthbar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        yValue = 1.0f;
        maxHealth = 10;
        currentHealth = 10;

        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }

    void Update()
    {

    }
    private void FixedUpdate()
    {
        MoveDown(1.0f, rb);
    }

    public virtual void Shoot()
    {

    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        healthbar.UpdateHealthBar(maxHealth, currentHealth);
    }
}
