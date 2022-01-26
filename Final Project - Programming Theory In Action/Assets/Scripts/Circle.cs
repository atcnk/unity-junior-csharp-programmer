// INHERITANCE
public class Circle : Enemy
{
    // POLYMORPHISM
    protected override void DealDamage()
    {
        MainManager.Instance.DamagePlayer(5);
    }
}
