using UnityEngine;
using System.Collections;

public class UpDown : MonoBehaviour {

	private Transform P;
	private bool UP = false;
	private bool DOWN = false;
	private bool clockStarted = false;
	private float UPandDown;
//	private int PlayerDown;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			UPandDown = Input.GetAxis ("Vertical");
			P = other.transform;
		}
		if (UPandDown > 0) {
			UP = true;
		}
		if (UPandDown < 0) {
			DOWN = true;
		}
	}

	void Goahead(){
		if (UP) {
			P.position += new Vector3 (0, 1f);
		}
	}



	// Update is called once per frame
	void Update () {
	
	}
		
}
