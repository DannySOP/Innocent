using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// test git 2

public class ChangePos : MonoBehaviour
{
    public float transitionFOV;
    public float originFOV;
    public float transitionTime;

    public Camera camera;
    public List<GameObject> target360Pos = new List<GameObject>();

    public CameraMovement cameraMovement;
    void Start()
    {
        cameraMovement = FindAnyObjectByType<CameraMovement>();
        camera = FindAnyObjectByType<Camera>();
    }

    public void OnPosChange(int i)
    {
        foreach (var targetPos in target360Pos)
        {
            targetPos.SetActive(false);
        }

        this.gameObject.SetActive(false);
        target360Pos[i].SetActive(true);

        float cameraFOV = camera.fieldOfView;
        LeanTween.value(camera.gameObject, transitionFOV, originFOV, transitionTime).setEase(LeanTweenType.linear).setOnUpdate((float updatedFOV) => {camera.fieldOfView = updatedFOV;});

        cameraMovement.OnPlaceChange();
    }   
}
