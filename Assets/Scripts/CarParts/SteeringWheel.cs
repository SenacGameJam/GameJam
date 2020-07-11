using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : MonoBehaviour {

    public CarMovement car;
    [SerializeField] float turnLimit = 3;
    float direction;
    TargetJoint2D joint;

    void Start() {
        joint = GetComponent<TargetJoint2D>();
    }

    void FixedUpdate() {

        direction = Mathf.Clamp(transform.position.x - joint.target.x, -turnLimit, turnLimit);

        car.rotationInput = direction;

    }
}
