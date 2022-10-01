using System.Collections;
using UnityEngine;

public class EnemyPatrolling: MonoBehaviour
{
    [SerializeField] private HealthController healthController;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float distance;

    [SerializeField] BoxCollider2D bodycollider;
    [SerializeField] private LayerMask wallLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthController.LoseLife();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            if (bodycollider.IsTouchingLayers(wallLayer))
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                walkSpeed *= -1;
            }
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
    }
}
