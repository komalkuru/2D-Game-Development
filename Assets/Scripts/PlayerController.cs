﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// namespace playerMovement 
// {
    public class PlayerController : MonoBehaviour 
    {
        Animator animator;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private BoxCollider2D box_collider;
        [SerializeField] private float speed;
        //[SerializeField] private float crouch;
        [SerializeField] private float jump;
        private float horizontal;
        private float vertical;

        

        private void Awake()
        {
            Debug.Log("Player controller awake");
            
            rb = gameObject.GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        }

        private void Update() {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            PlayerMoving(horizontal, vertical);
            PlayerCrouchMovement();
            PlayerMovementAnimation(horizontal, vertical);
        }

        void PlayerMoving(float horizontal, float vertical) {
            //Move character horizontally
            Vector3 position = transform.position;

            // speed = distance / time;      time.deltaTime = 1 / Frames per second
            position.x = position.x + horizontal * speed * Time.deltaTime;
            transform.position = position; 
        }

        void PlayerMovementAnimation(float horizontal, float vertical) {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            
            Vector3 scale = transform.localScale;
            
            if(horizontal < 0) {
                scale.x = -1f * Mathf.Abs(scale.x);
            } 
            else if(horizontal > 0) {
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;

            if(!(vertical > 0)) {
                animator.SetBool("Jump", false);
            }
        }

        void PlayerCrouchMovement() {
        if(Input.GetKeyDown(KeyCode.RightControl)) {
            animator.SetBool("Crouch", true);
            //rb.AddForce(new Vector2(0f, crouch), ForceMode2D.Force);
        }
        else if(Input.GetKeyUp(KeyCode.RightControl)) {
            animator.SetBool("Crouch", false);
        }
    }

        void OnCollisionStay2D(Collision2D collisionInfo)
        {
            //Move character vertically
            if(vertical > 0) {
                animator.SetBool("Jump", true);
                rb.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            if(collision.gameObject.CompareTag("Death")) {
                Debug.Log("Player Dead");
                Destroy(gameObject);
                LevelManager.instance.Respawn();
            }
        }

        
    }
//}