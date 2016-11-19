using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuControllerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGameScene() {
        SceneManager.LoadScene("gameScene", LoadSceneMode.Single);
        //Application.LoadLevel("gameScene");
    }

}
