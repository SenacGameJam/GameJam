using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    public List<WheelCollider> backWheels, frontWheels;
    public List<Rigidbody2D> carObjects;
    public float carSpeed, rotationSpeed, objectsForce = 5;
    [HideInInspector] public float rotationInput, accelerateInput;
    float moveCarObjects;
    Rigidbody rb;

    private void Start() => rb = GetComponent<Rigidbody>();

    private void FixedUpdate() {

        foreach (var item in backWheels) item.motorTorque = carSpeed * accelerateInput * Time.fixedDeltaTime;

        foreach (var item in frontWheels) item.steerAngle = rotationSpeed * rotationInput;

        moveCarObjects = rb.velocity.x * -1 * objectsForce * Time.fixedDeltaTime;

        foreach (var item in carObjects) {
            item.AddForce(new Vector2(moveCarObjects, item.velocity.y), ForceMode2D.Force);
        }

    }

}
