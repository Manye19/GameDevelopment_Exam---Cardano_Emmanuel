using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Mathematics;
using Unity.Netcode;
using Unity.Netcode.Editor;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Serialization;

public class CarController : NetworkBehaviour
{
    [Header("Car Values")]
    public float maxSpeed;
    public float carRotationSpeed;
    public float wheelRotation;
    
    private Vector3 localAngle;
    private float steerAngle;
    private float move;
    private float speed;
    private float angle;
    
    [Header("Object Lists")]
    public List<GameObject> wheelDrive = new();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuOpen();
        }
        SteerWheels();
        MoveCar();
    }

    #region Wheel Turning
    private void SteerWheels()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            foreach (GameObject go in wheelDrive)
            {
                steerAngle = Input.GetAxis("Horizontal") * -wheelRotation;
                localAngle = go.transform.localEulerAngles;
                localAngle.z = steerAngle;
                go.transform.localEulerAngles = localAngle;
            }
        }
    }
    #endregion
    
    #region Movement
    private void MoveCar()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            angle = Input.GetAxis("Horizontal") * -carRotationSpeed * Time.deltaTime;

            // car movement
            transform.Translate(0, move, 0);
            if (speed < maxSpeed)
            {
                // car acceleration
                speed += 0.015f;
            }

            // this makes sure that player is turning
            if (Input.GetAxis("Horizontal") == 0) return;
            // this only will run if the player is moving, hence Input.GetAxis("Vertical")
            transform.Rotate(0, 0, angle);
            if (Constants.DEFAULT_CAR_SPEED < speed)
            {
                // car drifts and slows down when turning
                speed -= 0.02f;
            }
        }
        else
        {
            // reset acceleration to zero (0) when car stops or reverses
            speed = Constants.DEFAULT_CAR_SPEED;
        }
    }
    #endregion

    #region Menu
    private void MenuOpen()
    {
        // toggles Menu Panel on/off
        UiManager.instance.menuPanel.SetActive(!UiManager.instance.menuPanel.activeSelf);
    }
    #endregion
}
