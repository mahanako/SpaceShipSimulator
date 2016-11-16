using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public float speed = 21;
    public float range = 102;
    private Vector3 spawnpoint;

    void Start() {
        spawnpoint = transform.position;
        Rigidbody r = GetComponent<Rigidbody>();
        r.velocity = transform.forward * speed;
    }

    // Update is called once per frame, guaranteed to run after
    // everything else
    void LateUpdate() {
        float distance = (transform.position - spawnpoint).magnitude;
        Debug.LogFormat("Spawnpoint: {0}, Posistion: {1}, distance: {2}", spawnpoint, transform.position, distance);
        if (distance >= range)
            Destroy(gameObject);
    }
}
