using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public float speed = 21;
    public float power = 100;
    public float decay = 5;
    public float decay_step_seconds = 0.3f;
    public float currentPower { get { return current_power; } }
    private float current_power;
    private float next_decay;
    private Vector3 spawnpoint;

    void Start() {
        spawnpoint = transform.position;
        current_power = power;
        Rigidbody r = GetComponent<Rigidbody>();
        r.velocity = transform.forward * speed;
    }

    // Update is called once per frame, guaranteed to run after
    // everything else
    void LateUpdate() {
        if (Time.time <= next_decay)
            return;

        next_decay = Time.time + decay_step_seconds;
        current_power -= decay;
        //Debug.LogFormat("Spawnpoint: {0}, Position: {1}, power: {2}", spawnpoint, transform.position, current_power);
        if (current_power <= 0)
            Destroy(gameObject);
    }
}
