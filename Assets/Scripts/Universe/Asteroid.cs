using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0.1f, 0.1f, 0.1f);
    }


    /// <summary>
    /// Breaks an asteorid into pieces
    /// </summary>
    public void BreakAsteroid() {
        Debug.Log("Breaking the Asteorid!");
        for (int i = 0 ; i < transform.childCount ; i++) {
            transform.GetChild(i).gameObject.AddComponent<BoxCollider>();

            // If the child object has a MapSymbol, turn it active
            Transform mapSymbolTransform = transform.GetChild(i).transform.FindChild("MapSymbol");
            if (mapSymbolTransform != null)
                mapSymbolTransform.gameObject.SetActive(true);            
            Rigidbody rigidBody = transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
            rigidBody.mass = 1;
            rigidBody.useGravity = false;
            transform.GetChild(i).parent = transform.parent;
            // TODO add the Asteorids to the List of Objects in the Solar System
        }
        //transform.DetachChildren();   // Since children got a new Parent...
        Destroy(gameObject);
    }

}
