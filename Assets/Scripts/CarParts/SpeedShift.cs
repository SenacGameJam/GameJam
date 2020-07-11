using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedShift : MonoBehaviour {

    public CarMovement car;
    float speed;
    SliderJoint2D joint;

    void Start() => joint = GetComponent<SliderJoint2D>();

    void Update() {

        speed = joint.connectedAnchor.y - transform.position.y;

        car.accelerateInput = speed * -1;

    }
}
