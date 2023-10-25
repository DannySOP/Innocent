using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPos : MonoBehaviour
{
    public GameObject player;

    private CameraMovement cameraMovement;
    void Start()
    {
        player = GameObject.Find("Player");
        cameraMovement = FindAnyObjectByType<CameraMovement>();
    }

    public void OnPosPressed()
    {
        if (player != null)
        {
            Vector3 newPos = transform.position;

            newPos.y = this.transform.position.y + 1f;

            LeanTween.move(player.gameObject, newPos, 0.2f);
        }
        cameraMovement.FOVBackToNormal();
    }
}
