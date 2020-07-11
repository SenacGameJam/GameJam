using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour {

    [HideInInspector] public bool canGrab;
    [HideInInspector] public Vector2 heldPos, releaseVelocity;
    bool grabing;
    Rigidbody2D heldObject;

    void FixedUpdate() {

        if (!canGrab)
            grabing = false;

        if (grabing && heldObject != null) {
            heldObject.position = heldPos;
            heldObject.velocity = releaseVelocity;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Holdable")) { heldObject = collision.GetComponent<Rigidbody2D>(); } 
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (heldObject != null) {if (!grabing && collision.gameObject.Equals(heldObject.gameObject)) { heldObject = null; }}
    }

    public void Hold(bool value) {
        if (canGrab) { grabing = value; }
    }

}
