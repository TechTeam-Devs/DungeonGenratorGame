using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class EnemyControl : MonoBehaviour
{

    [SerializeField]
    public float speed = 10f;

    public Rigidbody2D rb;

    public float minX = 2f;
    public float maxX = 10f;
    public float minY = 2f;
    public float maxY = 10f;
   
    void Start()
    {
        minX = transform.position.x - 2;
        maxX = transform.position.x + 2;
        minY = transform.position.y - 2;
        maxY = transform.position.y + 2;
    }

    // Enemy control taken from https://answers.unity.com/questions/355804/move-game-object-left-to-right-and-vice-verse.html
    void Update() 
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 1, maxX - minX) + minX, Mathf.PingPong(Time.time * 3, maxY - minY) + minY, transform.position.z);
    }
}
