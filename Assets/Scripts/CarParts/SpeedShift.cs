using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedShift : MonoBehaviour {

    public CarMovement car;
    float speed;
    SliderJoint2D joint;

    void Start() => joint = GetComponent<SliderJoint2D>();

    void Update() {

        speed = Mathf.Clamp(joint.connectedAnchor.y - transform.position.y, -3, 1);

        car.accelerateInput = speed * -1;

    }
}
