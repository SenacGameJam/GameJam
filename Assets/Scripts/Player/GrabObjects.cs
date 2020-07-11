using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour {

    [HideInInspector] public bool canGrab;
    [HideInInspector] public Vector2 heldPos, releaseVelocity;
    bool grabing;
    GameObject heldObject;
    Rigidbody2D heldObjectRB;

    void FixedUpdate() {

        if (!canGrab) grabing = false;

        if (heldObject) {
            if (grabing) {
                heldObjectRB.position = heldPos;
                heldObjectRB.velocity = releaseVelocity;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Holdable") && !grabing) { heldObject = collision.gameObject; heldObjectRB = heldObject.GetComponent<Rigidbody2D>(); } 
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (heldObject != null) {if (!grabing && collision.gameObject.Equals(heldObject)) { heldObject = null; heldObjectRB = null; } }
    }

    public void Hold(bool value) {
        if (canGrab) { grabing = value; }
    }

}
