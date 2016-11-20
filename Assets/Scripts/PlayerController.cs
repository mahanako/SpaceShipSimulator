using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 10;
    public float angular_speed = 10;

    public GameObject shot;
    public Transform shotspawn;
    public float firerate;
    private float nextfire;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextfire) {
            nextfire = Time.time + firerate;
            Instantiate(shot, shotspawn.position, shotspawn.rotation);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }

    }

    void FixedUpdate() {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * angular_speed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
}
