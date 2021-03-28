﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    float dragSpeed = 75.0f;

    void Start() {}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))//Умножаем изменение координат на Time.deltatime, чтобы движение было независимо от частоты кадров
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * dragSpeed,
                                           0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * dragSpeed);
            }
        }
    }
}
