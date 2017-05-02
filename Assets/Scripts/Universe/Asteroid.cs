using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

    public float Size = 1;
    public float SpeedNumerator = .3f;
    public GameObject small_explosion;
    public GameObject big_explosion;
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    private float hitpoints;

	// Use this for initialization
	void Start () {
        setSize(Size);
    }

    void setSize(float newSize) {
        Size = newSize;
        hitpoints = Size * 100;
        transform.localScale *= Size;
        GetComponent<Rigidbody>().mass = Size;
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(0.1f, 0.1f, 0.1f);
    }

    void OnCollisionEnter(Collision collision) {
        Collider other = collision.collider;
        if (other.tag != "Shot")
            return;

        Instantiate(small_explosion, collision.transform.position, collision.transform.rotation);
        Shot shot = other.GetComponentInParent<Shot>();
        hitpoints -= shot.currentPower;
        Destroy(other.gameObject);

        if (hitpoints > 0)
            return;

        Instantiate(big_explosion, transform.position, transform.rotation);
        if (Size > 1)
            BreakAsteroid(Size / 3);
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// Breaks an asteroid into pieces
    /// </summary>
    public void BreakAsteroid(float newSize) {
        GameObject o;
        float speed = SpeedNumerator / newSize;

        o = (GameObject)Instantiate(asteroid1, transform.position, transform.rotation);
        o.GetComponent<Asteroid>().setSize(newSize);
        o.GetComponent<Rigidbody>().velocity = transform.forward * speed;

        o = (GameObject)Instantiate(asteroid2, transform.position, transform.rotation);
        o.GetComponent<Asteroid>().setSize(newSize);
        o.GetComponent<Rigidbody>().velocity = transform.right * speed;

        o = (GameObject)Instantiate(asteroid3, transform.position, transform.rotation);
        o.GetComponent<Asteroid>().setSize(newSize);
        o.GetComponent<Rigidbody>().velocity = transform.up * speed;

        Destroy(gameObject);
    }

}
