using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour {

    public GameObject lArm, lLeg, rArm, rLeg;
    Transform lArmTransform, lLegTransform, rArmTransform, rLegTransform;
    Rigidbody2D lArmRB, lLegRB, rArmRB, rLegRB;
    [SerializeField] float limbsSpeed;
    bool lArmSelected, lLegSelected, rArmSelected, rLegSelected;
    Vector2 analogInput;
    Vector2 limbsVel;

    // Start is called before the first frame update
    void Start() {

        analogInput = new Vector2();

        lArmTransform = lArm.transform;
        rArmTransform = rArm.transform;
        lLegTransform = lLeg.transform;
        rLegTransform = rLeg.transform;

        lArmRB = lArm.GetComponent<Rigidbody2D>();
        rArmRB = rArm.GetComponent<Rigidbody2D>();
        lLegRB = lLeg.GetComponent<Rigidbody2D>();
        rLegRB = rLeg.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {

        MoveLimbs(lArmSelected, lArmRB);
        MoveLimbs(lLegSelected, lLegRB);
        MoveLimbs(rArmSelected, rArmRB);
        MoveLimbs(rLegSelected, rLegRB);

    }

    #region Movement

    void MoveLimbs(bool limbSelected, Rigidbody2D limbRB) {

        if (limbSelected) {
            limbRB.velocity = analogInput * limbsSpeed * Time.fixedDeltaTime;
        }

    }

    #endregion

    #region Input

    public void OnLeftArm(InputValue value) => lArmSelected = value.isPressed;

    public void OnRightArm(InputValue value) => rArmSelected = value.isPressed;

    public void OnLeftLeg(InputValue value) => lLegSelected = value.isPressed;

    public void OnRightLeg(InputValue value) => rLegSelected = value.isPressed;

    public void OnMoveSelected(InputValue value) => analogInput = value.Get<Vector2>();

    #endregion
}
