using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider BackRight;
    [SerializeField] WheelCollider BackLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform BackRightTransform;
    [SerializeField] Transform BackLeftTransform;

    [SerializeField] float Acceleration = 500;
    [SerializeField] float BreakingForce = 300;
    [SerializeField] float MaxTurningAngle = 15;

    float CurrentAcceleration = 0;
    float CurrentBreakingForce = 0;
    float CurrentTurningAngle = 0;


    void FixedUpdate()
    {
        CurrentAcceleration = Acceleration * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
            CurrentBreakingForce = BreakingForce;
        else
            CurrentBreakingForce = 0;

        frontRight.motorTorque = CurrentAcceleration;
        frontLeft.motorTorque = CurrentAcceleration;

        frontRight.brakeTorque = CurrentBreakingForce;
        frontLeft.brakeTorque = CurrentBreakingForce;
        BackRight.brakeTorque = CurrentBreakingForce;
        BackLeft.brakeTorque = CurrentBreakingForce;

        CurrentTurningAngle = MaxTurningAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = CurrentTurningAngle;
        frontRight.steerAngle = CurrentTurningAngle;

        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(BackLeft, BackLeftTransform);
        UpdateWheel(BackRight, BackRightTransform);
    }
    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }
}
