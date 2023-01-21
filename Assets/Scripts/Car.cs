using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float move;
    private float rotation;
    
    [Header("Speed Values")]
    public float maxSpeed;
    public float rotationSpeed;
    
    private float speed;
    private static float _defaultSpeed = 1;
    
    //[Header("")]
    public List<GameObject> wheelDrive = new();
    
    private void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            rotation = Input.GetAxis("Horizontal") * -rotationSpeed * Time.deltaTime;
            
            transform.Translate(0, move, 0);
            
            if (speed < maxSpeed)
            {
                speed += 0.015f;
            }

            if (Input.GetAxis("Horizontal") == 0) return;
            transform.Rotate(0, 0, rotation);
                
            if (_defaultSpeed < speed)
            {
                speed -= 0.02f;
            }
        }
        else
        {
            speed = _defaultSpeed;
        }
    }
}
