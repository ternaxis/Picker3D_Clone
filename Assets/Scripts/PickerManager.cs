using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerManager : MonoBehaviour
{
    public float speed = 5.0f;
    
    private Rigidbody rb;
    private Camera mainCamera;
    private float distanceBetweenCameraAndPicker;
    private Transform cameraTransform;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        cameraTransform = mainCamera.transform;
        distanceBetweenCameraAndPicker = cameraTransform.position.z - transform.position.z;
    }

    private void Update()
    {
        FollowPicker();
    }

    private void FollowPicker()
    {
        if (cameraTransform.position.z - transform.position.z != distanceBetweenCameraAndPicker)
        {
            cameraTransform.position = new Vector3(cameraTransform.position.x,cameraTransform.position.y,transform.position.z + distanceBetweenCameraAndPicker);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = -Vector3.forward * speed * Time.deltaTime;
    }

    public void PushCollectibles()
    {
        var colliders = Physics.OverlapSphere(transform.position, 1.0f, LayerMask.GetMask("Ball"));
        foreach (var collider in colliders)
        {
            collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * 30f);
        }
    }
}
