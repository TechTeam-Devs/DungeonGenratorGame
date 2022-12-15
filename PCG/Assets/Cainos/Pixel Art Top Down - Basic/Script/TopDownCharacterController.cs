using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        public GameObject deathScreen;
        public GameObject winScreen;

        private Animator animator;

        public GameObject timerObject;
        private TimeCountdown timeCountdown;
        private bool gameWon;

        private void Awake()
        {
            timeCountdown = timerObject.GetComponent<TimeCountdown>();
        }

        private void Start()
        {
            animator = GetComponent<Animator>();
            
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Goal"))
            {
                gameWon = true;


                GameObject player = GameObject.Find("PF Player");
                winScreen.SetActive(true);
                player.SetActive(false);
                timeCountdown.TimerStop(gameWon);
            }

            if (collision.gameObject.CompareTag("Enemy"))
            {
                gameWon = false;
              
              
                GameObject player = GameObject.Find("PF Player");
                deathScreen.SetActive(true);
                player.SetActive(false);
                timeCountdown.TimerStop(gameWon);


            }
        }

        
    }
}
