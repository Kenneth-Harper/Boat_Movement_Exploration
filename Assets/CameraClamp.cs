using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float rotationSpeedMultipler = 20;
    [SerializeField] float mouseMovementThreshold = 0.5f;

    Vector3 offset;

    void Start()
    {
        offset = target.localPosition - transform.localPosition;
    }

    void Update()
    {
        if (Input.GetButton(buttonName: "Fire2"))
        {
            transform.Rotate(new Vector3(0,  (Input.GetAxis("Mouse X") * rotationSpeedMultipler * Time.deltaTime), 0));
        }
    }

    void FixedUpdate()
    {
        transform.localPosition = target.localPosition - offset;
    }
}
