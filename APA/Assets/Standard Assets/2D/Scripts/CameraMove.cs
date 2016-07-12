using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	// Use this for initialization
    private GameObject mainCharacter;
	void Start () {
        mainCharacter = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(mainCharacter.name);
	}
	
	// Update is called once per frame
	void Update () {
        mainCharacter = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(mainCharacter.name);
        //Debug.Log(mainCharacter.transform.position);
        transform.position = mainCharacter.transform.position + new Vector3(0, 0, -10);
	}
}
