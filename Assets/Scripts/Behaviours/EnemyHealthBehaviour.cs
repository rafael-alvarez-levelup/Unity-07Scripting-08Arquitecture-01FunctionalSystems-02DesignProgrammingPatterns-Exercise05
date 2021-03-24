public class EnemyHealthBehaviour : HealthBehaviour
{
    private IDie dieBehaviour;

    protected override void Awake()
    {
        base.Awake();

        dieBehaviour = GetComponent<EnemyDieBehaviour>();
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);

        if (CurrentHealth <= 0)
        {
            dieBehaviour.Die();
        }
    }
}