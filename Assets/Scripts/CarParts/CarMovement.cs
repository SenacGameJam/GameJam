using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    public float carSpeed, rotationSpeed;
    [HideInInspector] public float rotationInput;

    private void FixedUpdate() {

        transform.Rotate(0, rotationInput * rotationSpeed * Time.fixedDeltaTime, 0);

        transform.position += transform.forward * carSpeed * Time.fixedDeltaTime;

    }

}
