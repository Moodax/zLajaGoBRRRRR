using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public Transform centerOfMass;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;
    private WheelFrictionCurve friction;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;
    public GameObject speed;
    private bool braked;

    [SerializeField] private WheelCollider wheelColliderLeftFront;
    [SerializeField] private WheelCollider wheelColliderRightFront;
    [SerializeField] private WheelCollider wheelColliderLeftBack;
    [SerializeField] private WheelCollider wheelColliderRightBack;

    [SerializeField] private Transform wheelLeftFront;
    [SerializeField] private Transform wheelRightFront;
    [SerializeField] private Transform wheelLeftBack;
    [SerializeField] private Transform wheelRightBack;
    private Rigidbody _rigidbody;
    private bool firstTime;
    private bool air;
    void Start()
    {
        air=false;
        firstTime=false;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
        braked=false;
    }
    private void FixedUpdate()
    {
        GetInput();
        wheelColliderLeftFront.ConfigureVehicleSubsteps(5, 12, 15);
        wheelColliderRightFront.ConfigureVehicleSubsteps(5, 12, 15);
        wheelColliderLeftBack.ConfigureVehicleSubsteps(5, 12, 15);
        wheelColliderRightBack.ConfigureVehicleSubsteps(5, 12, 15);
        HandleMotor();
        
        var velocity = GetComponent<Rigidbody>().velocity;
        var localVel = transform.InverseTransformDirection(velocity);
 
        if (localVel.z > 0)
        {
            speed.GetComponent<Text>().text=-(Int32)GetComponent<Rigidbody>().velocity.magnitude*3.6 +" Km/h";
        }
        else
        {
            speed.GetComponent<Text>().text=(Int32)GetComponent<Rigidbody>().velocity.magnitude*3.6 +" Km/h";
        }

        if(!isGrounded(wheelColliderLeftFront)&& !isGrounded(wheelColliderRightFront)&& !isGrounded(wheelColliderLeftBack)&& !isGrounded(wheelColliderRightBack))
        {
            air=true;
            if(Input.GetKey(KeyCode.LeftShift) && firstTime)
            {
            _rigidbody.constraints=RigidbodyConstraints.FreezeRotationX;
            firstTime=false;
            }
        }
        else 
        {
        _rigidbody.constraints=RigidbodyConstraints.None;
        air=false;
        firstTime=true;
        }
        HandleSteering();
        UpdateWheels();
    }

    private bool isGrounded(WheelCollider wheel)
    {
        if(wheel.GetGroundHit(out WheelHit hit))
        return true;
        return false;
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.LeftShift);
    }

    private void HandleMotor()
    {
        wheelColliderLeftBack.motorTorque = verticalInput * motorForce;
        wheelColliderRightBack.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        if(!air)
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        { 
        friction = wheelColliderRightBack.sidewaysFriction;
        friction.extremumSlip = 1f;
        wheelColliderRightBack.sidewaysFriction = friction;

        friction = wheelColliderLeftBack.sidewaysFriction;
        friction.extremumSlip = 1f;
        wheelColliderLeftBack.sidewaysFriction = friction;

        friction = wheelColliderLeftFront.sidewaysFriction;
        friction.extremumValue = 1.5f;
        wheelColliderLeftFront.sidewaysFriction = friction;

        friction = wheelColliderRightFront.sidewaysFriction;
        friction.extremumValue = 1.5f;
        wheelColliderRightFront.sidewaysFriction = friction;

        braked=true;

        }
        else if(braked)
        {
            friction = wheelColliderRightBack.sidewaysFriction;
            friction.extremumSlip = 0.01f;
            friction.extremumValue = 5f;
            wheelColliderRightBack.sidewaysFriction = friction;

            friction = wheelColliderLeftBack.sidewaysFriction;
            friction.extremumSlip = 0.01f;
            friction.extremumValue = 5f;
            wheelColliderLeftBack.sidewaysFriction = friction;

            friction = wheelColliderLeftFront.sidewaysFriction;
            friction.extremumValue = 5f;
            wheelColliderLeftFront.sidewaysFriction = friction;

            friction = wheelColliderRightFront.sidewaysFriction;
            friction.extremumValue = 5f;
            wheelColliderRightFront.sidewaysFriction = friction;
            braked=false;
        }
        else{
            friction = wheelColliderRightBack.sidewaysFriction;
            friction.extremumSlip = 0.05f;
            friction.extremumValue = 1;
            wheelColliderRightBack.sidewaysFriction = friction;

            friction = wheelColliderLeftBack.sidewaysFriction;
            friction.extremumSlip = 0.05f;
            friction.extremumValue = 1;
            wheelColliderLeftBack.sidewaysFriction = friction;

            friction = wheelColliderLeftFront.sidewaysFriction;
            friction.extremumValue = .9f;
            wheelColliderLeftFront.sidewaysFriction = friction;

            friction = wheelColliderRightFront.sidewaysFriction;
            friction.extremumValue = .9f;
            wheelColliderRightFront.sidewaysFriction = friction;
        }
        wheelColliderRightFront.brakeTorque = currentbreakForce/2;
        wheelColliderLeftFront.brakeTorque = currentbreakForce/2;
        wheelColliderLeftBack.brakeTorque = currentbreakForce/2;
        wheelColliderRightBack.brakeTorque = currentbreakForce/2;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        wheelColliderLeftFront.steerAngle = currentSteerAngle;
        wheelColliderRightFront.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(wheelColliderLeftFront, wheelLeftFront);
        UpdateSingleWheel(wheelColliderRightFront, wheelRightFront);
        UpdateSingleWheel(wheelColliderRightBack, wheelRightBack);
        UpdateSingleWheel(wheelColliderLeftBack, wheelLeftBack);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot; 
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}