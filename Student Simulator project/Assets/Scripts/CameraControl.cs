using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    float dragSpeed = 75.0f;
    float cornerSpeed = 8.0f;
    int boundary = 20;
    int width;
    int height;

    void Start()
    {
        width = Screen.width;
        height = Screen.height;

    }

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
        if (Input.mousePosition.x > width - boundary)
        {
            transform.position += new Vector3(Time.deltaTime * cornerSpeed,
                                       0.0f, 0.0f);
        }

        if (Input.mousePosition.x < 0 + boundary)
        {
            transform.position -= new Vector3(Time.deltaTime * cornerSpeed,
                                       0.0f, 0.0f);
        }

        if (Input.mousePosition.y > height - boundary)
        {
            transform.position += new Vector3(0.0f, 0.0f, Time.deltaTime * cornerSpeed);
        }

        if (Input.mousePosition.y < 0 + boundary)
        {
            transform.position -= new Vector3(0.0f, 0.0f,
                                       Time.deltaTime * cornerSpeed);
        }
    }
}
