using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickObjects : MonoBehaviour {

    [HideInInspector] public bool kick, canKick;
    bool wasButtonPressed;
    float kickStrenght = 750;
    Rigidbody2D kickObject;

    void FixedUpdate() {

        if (canKick) {
            if (kick) {
                if (!wasButtonPressed) {
                    if (kickObject != null) {
                        Vector2 kickDirection = new Vector2((Random.value*2)-1, Random.value);
                        kickObject.AddForce(kickDirection * kickStrenght);
                    }
                    wasButtonPressed = true;
                }
            } else { wasButtonPressed = false; }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<Rigidbody2D>()) { kickObject = collision.GetComponent<Rigidbody2D>(); }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (kickObject != null) { if (collision.gameObject.Equals(kickObject.gameObject)) { kickObject = null; } }
    }

}
