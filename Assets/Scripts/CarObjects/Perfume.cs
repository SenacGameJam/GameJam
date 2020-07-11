using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perfume : MonoBehaviour {

    public ParticleSystem ps;
    bool canSpawnParticles = true;

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Holdable") && canSpawnParticles) {
            canSpawnParticles = false;
            Invoke("CanSpawnParticles", 20);
            ps.gameObject.transform.position = transform.position;
            ps.Play();
        }

    }

    void CanSpawnParticles() => canSpawnParticles = true;

}
