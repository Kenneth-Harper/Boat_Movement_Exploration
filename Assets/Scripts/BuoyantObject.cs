using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyantObject : MonoBehaviour
{
    [SerializeField] private Rigidbody floatingRigidBody;
    [SerializeField] private float displacementAmount = 3f;
    [SerializeField] private int numBuoyancyPoints = 1;
    
    [SerializeField] private float waterDrag = 0.99f;
    [SerializeField] private float waterAngularDrag = 0.5f;

    private float depthBeforeSubmerged = 1f;
    

    private void FixedUpdate() 
    {
        floatingRigidBody.AddForceAtPosition(Physics.gravity / numBuoyancyPoints, transform.position, ForceMode.Acceleration);
        float waterSurfaceHeight = WaveManager.instance.GetWaveHeight(transform.position.y, transform.position.z);
        if (transform.position.y < waterSurfaceHeight)
        {
            float displacementMultiplier = Mathf.Clamp01(( waterSurfaceHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            floatingRigidBody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier), transform.position, ForceMode.Acceleration);
            floatingRigidBody.AddForce(displacementMultiplier * -floatingRigidBody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange );
            floatingRigidBody.AddTorque(displacementMultiplier * -floatingRigidBody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange );
        }    
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
