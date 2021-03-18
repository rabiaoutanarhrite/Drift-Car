using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerNew : MonoBehaviour
{
    private float m_horizontalInput;
    private float m_verticallInput;
    private float m_steeringAngle;

    public WheelCollider wheelLeftF, wheelRightF;
    public WheelCollider wheelLeftB, wheelRightB;
    public Transform transLeftF, transRightF;
    public Transform transLeftB, transRightB;

    public float maxSteerAngle = 30;
    public float motorForce = 50;

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticallInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        wheelLeftF.steerAngle = m_steeringAngle;
        wheelRightF.steerAngle = m_steeringAngle;
    }

    private void Accelerate()
    {
        wheelLeftF.motorTorque = m_verticallInput * motorForce;
        wheelRightF.motorTorque = m_verticallInput * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(wheelLeftF, transLeftF);
        UpdateWheelPose(wheelRightF, transRightF);
        UpdateWheelPose(wheelLeftB, transLeftB);
        UpdateWheelPose(wheelRightB, transRightB);

    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }

}
