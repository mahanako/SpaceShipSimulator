using UnityEngine;
using System.Collections;

public class CameraRig : MonoBehaviour {

    public enum Mode {
        Following,
        Fixed,
        Free,
        Cockpit
    }

    public GameObject player;
    public Mode mode = Mode.Free;
    public float switchrate = 0.25f;
    private float nextswitch;

    public Vector3 offset = new Vector3(0,0,-5);

    // Use this for initialization
    void Start() {
        //offset = transform.position - player.transform.position;
    }

    void Update() {
        if (Input.GetButton("Jump") && Time.time > nextswitch) {
            nextswitch = Time.time + switchrate;
            switch (mode) {
            case Mode.Following:
                mode = Mode.Fixed;
                transform.SetParent(null);
                transform.rotation = new Quaternion(0, 0, 0, 0);
                break;
            case Mode.Fixed:
                mode = Mode.Free;
                transform.SetParent(null);
                transform.rotation = new Quaternion(0, 0, 0, 0);
                break;
            case Mode.Free:
                mode = Mode.Cockpit;
                transform.SetParent(player.transform);
                transform.position = new Vector3(0, 0.31f, -0.34f);
                transform.rotation = new Quaternion(0.71f, 0, 0, 0);
                break;
            case Mode.Cockpit:
                mode = Mode.Following;
                transform.SetParent(player.transform);
                transform.position = new Vector3(0, 0, -2.34f);
                transform.rotation = new Quaternion(0, 0, 0, 0);
                break;
            }
        }
    }

    // Update is called once per frame, guaranteed to run after
    // everything else
    void LateUpdate() {
        switch (mode) {
        case Mode.Following:
            //transform.position = player.transform.position + offset;
            break;
        case Mode.Fixed:
            transform.position = player.transform.position + offset;
            break;
        case Mode.Free:
            //transform.position = player.transform.position + offset;
            break;
        case Mode.Cockpit:
            
            break;
        }
    }
}
