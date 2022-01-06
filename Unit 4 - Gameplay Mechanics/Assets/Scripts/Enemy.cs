using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRB;
    private GameObject playerGO;

    private float yBound = -5f;
    private float enemySpeed = 2f;

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        playerGO = GameObject.Find("Player");
    }

    private void Update()
    {
        FollowPlayer();
        CheckBounds();
    }

    private void CheckBounds()
    {
        if (transform.position.y < yBound)
        {
            Destroy(this.gameObject);
        }
    }

    private void FollowPlayer()
    {
        Vector3 lookDirection = playerGO.transform.position - this.transform.position;
        enemyRB.AddForce(lookDirection.normalized * enemySpeed);
    }
}
