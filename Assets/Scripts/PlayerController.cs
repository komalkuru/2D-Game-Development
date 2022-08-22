using UnityEngine;

namespace playerMovement 
{
    public class PlayerController : MonoBehaviour
    {
        public ScoreController scoreController;
        public GameCompleteMenuController gameCompleteMenuController;
        [SerializeField] GameOverController gameOverController;

        public Animator animator;

        public float Speed;
        public float jump;

        private bool isCrouch = false;
        public bool isDead = false;

        private Rigidbody2D rb2d;
        private BoxCollider2D boxCollider;

        [SerializeField] private LayerMask platformLayerMask;

        private void Awake()
        {
            rb2d = gameObject.GetComponent<Rigidbody2D>();
            boxCollider = gameObject.GetComponent<BoxCollider2D>();
            animator = gameObject.GetComponent<Animator>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Jump");
            
            if(!isDead) {
                PlayerMovement(horizontal, vertical);
                PlayerJump(horizontal, vertical);
                Crouch();
            }
        }
         
        private void PlayerJump(float horizontal, float vertical)
        {
                          
                if (vertical > 0 && IsGrounded() && !isCrouch)
                {
                    animator.SetBool("Jump", true);
                    rb2d.velocity = Vector2.up * jump;
                    JumpSound();
                }
                else
                {
                    animator.SetBool("Jump", false);
                }
               
        }

        private void PlayerMovement(float horizontal, float vertical)
        {
            if(!isCrouch)
            {
                animator.SetFloat("Speed", Mathf.Abs(horizontal));
                Vector3 scale = transform.localScale;
                if (horizontal < 0)
                {
                    scale.x = -1f * Mathf.Abs(scale.x);
                }
                else if (horizontal > 0)
                {
                    scale.x = Mathf.Abs(scale.x);
                }
                transform.localScale = scale;

                Vector3 position = transform.position;
                position.x += horizontal * Speed * Time.deltaTime;
                transform.position = position;                
            }
        }

        private void Crouch()
        {
            isCrouch = (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl));
            if (isCrouch)
            {
                animator.SetBool("Crouch", true);
            }
            else
            {
                animator.SetBool("Crouch", false);
            }
        }

        private bool IsGrounded()
        {
            float extraHeight = 0.3f;

            RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
            return raycastHit.collider != null;
        }

        public void PickUpKey()
        {            
            Debug.Log("Player picked up the key");
            scoreController.IncrementScore(10);
            SoundManager.Instance.Play(Sounds.KeyPickup);
        }

        public void KillPlayer()
        {
            isDead = true;
            Debug.Log("Player Killed");
            animator.SetTrigger("Death");
            SoundManager.Instance.Play(Sounds.PlayerDeath);

            gameOverController.Invoke("GameOver", 1f);
        }

        public void LevelComplete()
        {
            Debug.Log("Level Complete");
            gameCompleteMenuController.LevelComplete();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if ((collision.gameObject.CompareTag("Death")) || collision.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Player Died");
                SoundManager.Instance.Play(Sounds.PlayerDeath);
                Destroy(gameObject);
                RespawnLevel.instance.Respawn();
            }
        }

        public void MovementSound()
        {
            SoundManager.Instance.Play(Sounds.PlayerMove);
        }

        public void JumpSound()
        {
            SoundManager.Instance.Play(Sounds.PlayerJump);
        }
    }
}