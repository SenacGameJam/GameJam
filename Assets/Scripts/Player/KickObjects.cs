using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickObjects : MonoBehaviour {

    [HideInInspector] public bool kick, canKick, isLocked;
    bool wasButtonPressed;
    float kickStrenght = 750;
    Rigidbody2D kickObject;

    void FixedUpdate() {

        if (canKick) {
            if (kick) {
                if (!wasButtonPressed) {
                    if (kickObject) {
                        Vector2 kickDirection = new Vector2();
                        if (kickObject.GetComponent<TargetJoint2D>()) Debug.Log("Buzina");

                        if (kickObject.GetComponent<SliderJoint2D>())
                            kickDirection = new Vector2(0, (Random.value * 2) - 1);
                        else
                            kickDirection = new Vector2((Random.value * 2) - 1, Random.value);

                        kickDirection.x = Mathf.Clamp(kickDirection.x, -0.5f, 0.5f);
                        kickDirection.y = Mathf.Clamp(kickDirection.y, 0.4f, 1);
                        kickObject.AddForce(kickDirection * kickStrenght);
                    }
                    wasButtonPressed = true;
                }
            } else wasButtonPressed = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<Rigidbody2D>()) { kickObject = collision.GetComponent<Rigidbody2D>(); }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (kickObject != null) { if (collision.gameObject.Equals(kickObject.gameObject)) { kickObject = null; } }
    }

}
