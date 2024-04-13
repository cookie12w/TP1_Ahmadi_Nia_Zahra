using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothCarFollow : MonoBehaviour
{
    [SerializeField] Transform CameraPlace;
    [SerializeField] Transform Car;

    [SerializeField] float Speed;
    private void Start()
    {
        CameraPlace = GameObject.FindGameObjectWithTag("CameraFollow").transform;
    }
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, CameraPlace.position, ref ccurrent, Speed * Time.deltaTime,50);
        transform.LookAt(Car);
    }
    Vector3 ccurrent;
}
