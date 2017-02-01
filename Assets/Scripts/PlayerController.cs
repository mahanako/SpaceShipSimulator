using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float max_speed = 5;
    public float acceleration = 0.3f;
    public float angular_speed = 100;

    public GameObject shot;
    public Transform shotspawn;
    public float firerate = 0.25f;
    private float nextfire;
    private float nextacceleration;
    private float current_speed;
    private Rigidbody r;
    private ParticleSystem p;


    // Use this for initialization
    void Start () {
        r = GetComponent<Rigidbody>();
        p = GetComponentInChildren<ParticleSystem>();
        current_speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextfire) {
            nextfire = Time.time + firerate;
            Instantiate(shot, shotspawn.position, shotspawn.rotation);
            AudioSource audio = GetComponents<AudioSource>()[0];
            audio.Play();
        }
        if (Input.GetButton("Fire2") && Time.time > nextacceleration) {
            nextacceleration = Time.time + acceleration;
            current_speed += acceleration;
        }
        if (Input.GetButton("Fire3") && Time.time > nextacceleration) {
            nextacceleration = Time.time + acceleration;
            current_speed -= acceleration;
        }
        if (current_speed > max_speed)
            current_speed = max_speed;
        if (current_speed < 0)
            current_speed = 0;

        if (current_speed == 0) {
            AudioSource audio = GetComponents<AudioSource>()[1];
            audio.Stop();
            p.Stop();
        }
        else {
            AudioSource audio = GetComponents<AudioSource>()[1];
            audio.volume = current_speed / max_speed;
            audio.pitch = current_speed / max_speed;
            if (!audio.isPlaying)
                audio.Play();
            p.Play();
        }
    }

    void FixedUpdate() {
        //float translation = Input.GetAxis("Vertical") * speed;
        float roll = Input.GetAxis("Horizontal") * angular_speed;
        float pitch = Input.GetAxis("Vertical") * angular_speed;
        //translation *= Time.deltaTime;
        roll *= Time.deltaTime;
        pitch *= Time.deltaTime;
        //transform.Translate(0, 0, translation);
        transform.Rotate(pitch, 0, -roll);
        r.velocity = transform.forward * current_speed;
    }
}
