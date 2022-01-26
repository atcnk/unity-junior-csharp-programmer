using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float boundX = 10f;
    private float boundY = 7f;

    private void Update()
    {
        DestroyOutOfBounds();
    }

    private void DestroyOutOfBounds()
    {
        if (this.transform.position.x > boundX || this.transform.position.x < -boundX ||
            this.transform.position.y > boundY || this.transform.position.y < -boundY)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);

            MainManager.Instance.UpdateScore();
        }
    }
}
