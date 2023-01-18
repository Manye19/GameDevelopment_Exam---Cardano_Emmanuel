using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0f, speed * Time.deltaTime, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            
        }
            
    }
}
