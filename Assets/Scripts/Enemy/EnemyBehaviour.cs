using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private HealthController healthController;

    public float walkSpeed;
    public float distance;
    public bool moveRight = true;
    public Transform groundDetectionPoint;

    public BoxCollider2D bodycollider;
    public LayerMask wallLayer;

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

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetectionPoint.position, Vector2.down, distance);

        if (!groundInfo.collider)
        {
            if (moveRight )
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
    }

   
}
