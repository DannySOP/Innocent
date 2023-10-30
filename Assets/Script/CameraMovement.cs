using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    public float zoomSpeed = 5f;
    public float minFOV = 10f;
    public float maxFOV = 80f;

    public float rotationX;
    public float rotationY;
    public float rotationZ;

    private Camera camera;

    private void Start()
    {
        camera = FindAnyObjectByType<Camera>();
    }

    void Update()
    {
        rotationX = this.gameObject.transform.eulerAngles.x;
        rotationY = this.gameObject.transform.eulerAngles.y;
        rotationZ = this.gameObject.transform.eulerAngles.z;

        if (Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            Vector2 inputDelta = Vector2.zero;

            if (Input.GetMouseButton(0))
            {
                inputDelta.x = Input.GetAxis("Mouse X");
                inputDelta.y = Input.GetAxis("Mouse Y");
            }
            else if (Input.touchCount > 0)
            {
                inputDelta = Input.GetTouch(0).deltaPosition;
            }

            transform.eulerAngles += speed * new Vector3(inputDelta.y, -inputDelta.x, 0);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            float newFOV = camera.fieldOfView - scroll * zoomSpeed;
            newFOV = Mathf.Clamp(newFOV, minFOV, maxFOV);
            camera.fieldOfView = newFOV;
        }
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touch0PrevPos = touch0.position - touch0.deltaPosition;
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;

            float prevTouchDeltaMag = (touch0PrevPos - touch1PrevPos).magnitude;
            float touchDeltaMag = (touch0.position - touch1.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            float newFOV = camera.fieldOfView + deltaMagnitudeDiff * zoomSpeed * 0.01f;
            newFOV = Mathf.Clamp(newFOV, minFOV, maxFOV);
            camera.fieldOfView = newFOV;
        }
    }

    public void FOVBackToNormal()
    {
        camera.fieldOfView = 60;
    }

    public void OnPlaceChange()
    {
        rotationX = 0f;
        rotationZ = 0f;

        transform.eulerAngles = new Vector3(rotationX, rotationY, rotationZ);
    }
}
