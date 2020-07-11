using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perfume : MonoBehaviour {

    public ParticleSystem ps;

    private void OnTriggerEnter2D(Collider2D collision) {
        ps.gameObject.transform.position = transform.position;
        ps.Play();
    }

}
