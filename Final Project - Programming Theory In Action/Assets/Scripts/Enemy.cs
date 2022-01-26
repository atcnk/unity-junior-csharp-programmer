using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected abstract void DealDamage();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DealDamage();
            Destroy(gameObject);
        }
    }
}
