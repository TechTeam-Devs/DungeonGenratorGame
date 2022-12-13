using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerControl : MonoBehaviour
{

    [SerializeField]
    public float speed = 10f;

    public Rigidbody2D rb;

    bool trigger = false;

    Vector2 movement; //stores X & Y-value


    // Update is called once per frame
    void Update() //input
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.E) && trigger)
        {
            Debug.Log("Game Won");
            SceneManager.LoadScene("Menu");
        }

    }

    private void FixedUpdate() //executed on a fixed time -- movement
    {
        //rb = variable for player. currentposition + new movment x & y * speed
          rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Entered goal");
            trigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited goal");
        trigger = false;
    }
}
