using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    public float zoomSpeed = 5f;
    public float minFOV = 10f;
    public float maxFOV = 80f;

    private Camera camera;

    private void Start()
    {
        camera = FindAnyObjectByType<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles += speed * new Vector3(x: Input.GetAxis("Mouse Y"), y: -Input.GetAxis("Mouse X"), z: 0) ;
        }
        
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            float newFOV = camera.fieldOfView - scroll * zoomSpeed;
            newFOV = Mathf.Clamp(newFOV, minFOV, maxFOV);
            camera.fieldOfView = newFOV;
        }
    }

    public void FOVBackToNormal()
    {
        camera.fieldOfView = 60;
    }
}
