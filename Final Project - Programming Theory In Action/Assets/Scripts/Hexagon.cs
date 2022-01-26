// INHERITANCE
public class Hexagon : Enemy
{
    // POLYMORPHISM
    protected override void DealDamage()
    {
        MainManager.Instance.DamagePlayer(3);
    }
}
