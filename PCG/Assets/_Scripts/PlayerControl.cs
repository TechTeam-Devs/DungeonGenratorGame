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

    public float minX = 2f;
    public float maxX = 10f;
    public float minY = 2f;
    public float maxY = 10f;
    // Use this for initialization
    void Start()
    {
        minX = transform.position.x - 5;
        maxX = transform.position.x + 5;
        minY = transform.position.y - 5;
        maxY = transform.position.y + 5;
    }


    // Update is called once per frame
    void Update() //input
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

        if (trigger)
        {
            Debug.Log("Game Failed");
            SceneManager.LoadScene("Menu");
        }

        transform.position = new Vector3(Mathf.PingPong(Time.time * 5, maxX - minX) + minX, Mathf.PingPong(Time.time * 3, maxY - minY) + minY, transform.position.z);

    }

    //private void FixedUpdate() //executed on a fixed time -- movement
    //{
        //rb = variable for player. currentposition + new movment x & y * speed
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Goal"))
        //{
        //    Debug.Log("Entered goal");
        //    trigger = true;
        //}
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("DEAD");
            trigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited goal");
        trigger = false;
    }
}
