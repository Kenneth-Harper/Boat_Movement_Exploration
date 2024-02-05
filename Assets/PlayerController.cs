using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform front;
    [SerializeField] Transform center;
    [SerializeField] float speedMultiplier = 1;
    [SerializeField] float rotationMultiplier = 1; 
    [SerializeField] Rigidbody boatBody;

    void Update()
    {
        Vector3 currentDirection = Vector3.Normalize(front.position - center.position);
        if (Input.GetAxis("Vertical") > 0)
        {
            boatBody.AddForce(currentDirection * speedMultiplier * Input.GetAxis("Vertical") * Time.deltaTime, ForceMode.VelocityChange);
        }
        if (boatBody.velocity.magnitude > 10)
        {
            boatBody.AddTorque(new Vector3(0, Input.GetAxis("Horizontal") * rotationMultiplier * Time.deltaTime, 0), ForceMode.VelocityChange);
        }
    }
}
