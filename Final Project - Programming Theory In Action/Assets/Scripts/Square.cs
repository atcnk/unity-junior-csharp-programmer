// INHERITANCE
public class Square : Enemy
{
    // POLYMORPHISM
    protected override void DealDamage()
    {
        MainManager.Instance.DamagePlayer(4);
    }
}
