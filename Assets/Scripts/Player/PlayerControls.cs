using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour {

    public GameObject lArm, lLeg, rArm, rLeg;
    public GrabObjects lHand, rHand;
    public KickObjects lFoot, rFoot;
    public Color limbsColor = new Color(255,219,177);
    [SerializeField] float limbsSpeed;
    Transform lArmTransform, lLegTransform, rArmTransform, rLegTransform;
    Rigidbody2D lArmRB, lLegRB, rArmRB, rLegRB;
    Animator lArmAnim, lLegAnim, rArmAnim, rLegAnim;
    bool lArmSelected, lLegSelected, rArmSelected, rLegSelected, hold;
    Vector2 analogInput;
    Vector2 limbsVel;
    
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

        lArmAnim = lArm.GetComponent<Animator>();
        rArmAnim = rArm.GetComponent<Animator>();
        lLegAnim = lLeg.GetComponent<Animator>();
        rLegAnim = rLeg.GetComponent<Animator>();

        lArm.GetComponent<SpriteRenderer>().color = limbsColor;
        lLeg.GetComponent<SpriteRenderer>().color = limbsColor;
        rArm.GetComponent<SpriteRenderer>().color = limbsColor;
        rLeg.GetComponent<SpriteRenderer>().color = limbsColor;

    }
    
    void FixedUpdate() {

        MoveLimbs(lArmSelected, lArmRB);
        MoveLimbs(lLegSelected, lLegRB);
        MoveLimbs(rArmSelected, rArmRB);
        MoveLimbs(rLegSelected, rLegRB);

        if (lArmSelected) { lArmAnim.SetBool("Grabing", hold); } else { lArmAnim.SetBool("Grabing", false); }
        if (lLegSelected) { lLegAnim.SetBool("Grabing", hold); } else { lLegAnim.SetBool("Grabing", false); }
        if (rArmSelected) { rArmAnim.SetBool("Grabing", hold); } else { rArmAnim.SetBool("Grabing", false); }
        if (rLegSelected) { rLegAnim.SetBool("Grabing", hold); } else { rLegAnim.SetBool("Grabing", false); }

        lHand.canGrab = lArmSelected;
        rHand.canGrab = rArmSelected;

        lHand.heldPos = lHand.transform.position;
        rHand.heldPos = rHand.transform.position;

        lHand.releaseVelocity = limbsVel;
        rHand.releaseVelocity = limbsVel;

        lHand.Hold(hold);
        rHand.Hold(hold);

        lFoot.canKick = lLegSelected;
        rFoot.canKick = rLegSelected;

        lFoot.kick = hold;
        rFoot.kick = hold;

    }

    #region Movement

    void MoveLimbs(bool limbSelected, Rigidbody2D limbRB) {

        if (limbSelected) {
            limbRB.velocity = analogInput * limbsSpeed * Time.fixedDeltaTime;
            limbsVel = analogInput * limbsSpeed * Time.fixedDeltaTime;
        }

    }

    #endregion

    #region Input

    public void OnLeftArm(InputValue value) => lArmSelected = value.isPressed;

    public void OnRightArm(InputValue value) => rArmSelected = value.isPressed;

    public void OnLeftLeg(InputValue value) => lLegSelected = value.isPressed;

    public void OnRightLeg(InputValue value) => rLegSelected = value.isPressed;

    public void OnHold(InputValue value) => hold = value.isPressed;

    public void OnMoveSelected(InputValue value) => analogInput = value.Get<Vector2>();

    #endregion
}
