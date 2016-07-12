using UnityEngine;
using System.Collections;

public class UPUP : MonoBehaviour {
	private int clock;
	private bool clockStarted = false;
	private bool startFalling= false;
	private Transform P;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			clockStarted = true;
			P = other.transform;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			clockStarted = false;
			clock = 0;
			P = null;
			startFalling = false;
		}
	}
	// Update is called once per frame
	void Update () {
		if(clockStarted)
		{
			clock++;
		}
		if(clock > 60)
		{
			clockStarted = false;
			startFalling = true;
		}
		if(startFalling)
		{
			P.position += new Vector3(0, 0.5f);

			//GameObject.FindWithTag("Player").GetComponent<Game>().forceKill();       
			//P.GetComponentInParent<Game>().forceKill();
		}
	}
}
