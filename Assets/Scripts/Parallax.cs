using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    [SerializeField] private Vector2 parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position -= new Vector3(deltaMovement.x * parallaxEffect.x, deltaMovement.y * parallaxEffect.y, 0);
        lastCameraPosition = cameraTransform.position;
    }
}
