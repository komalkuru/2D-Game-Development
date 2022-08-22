using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public HealthController healthController;

    public float walkSpeed;
    public float distance;
    public bool moveRight = true;
    public Transform groundDetectionPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthController.LoseLife();
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetectionPoint.position, Vector2.down, distance);

        if (!groundInfo.collider)
        {
            if (moveRight)
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
