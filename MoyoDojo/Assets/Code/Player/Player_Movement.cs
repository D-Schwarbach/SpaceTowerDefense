﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private CharacterController _charCont;

    public float run = 5f;
    public float speed = 12.0f;
    public float gravity = -9.8f;


    // Use this for initialization
    void Start()
    {
        _charCont = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charCont.Move(movement);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += run;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= run;
        }
    }
}
