using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControll : MonoBehaviour
{
    private Camera mainCamera;
    private float cameraZDistance;

    private void Start()
    {
        mainCamera = Camera.main;
        cameraZDistance = mainCamera.WorldToScreenPoint(transform.position).z;
    }

    private void OnMouseDrag()
    {
        Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZDistance);
        Vector3 NewWorldPosition = mainCamera.ScreenToWorldPoint(ScreenPosition);
        transform.position = NewWorldPosition;
    }

    //когда подвели мышь к объекту, он увеличивается
    void OnMouseEnter()
    {
        transform.localScale = new Vector3(2.2f, 0.07f, 1.2f);
    }


    //когда убрали мышь от объекта, он возвращается в исходную форму
    void OnMouseExit()
    {
        transform.localScale = new Vector3(2f, 0.05f, 1f);
    }
}
