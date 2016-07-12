using UnityEngine;
using System.Collections;

public class Boxcreat : MonoBehaviour {
	public GameObject boxPrefab;
	public Vector3 pos1;
	public Vector3 pos2;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.touchCount>0 &&Input.GetTouch (0).phase == TouchPhase.Began) {
		//	pos = Input.GetTouch (0).position;
		//	Instantiate (boxPrefab, pos, Quaternion.identity);
		//}
		Vector3 m_player,m_mouse;

		if (Input.GetMouseButtonDown (0)) {
			pos1 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			pos1.z = 0;
			//m_player = Camera.main.WorldToScreenPoint (GameObject.FindWithTag ("Player").transform.position);
		}
		if (Input.GetMouseButtonUp (0)) {
			m_mouse = Input.mousePosition;
			m_player = Camera.main.WorldToScreenPoint (GameObject.FindWithTag ("Player").transform.position);
				pos2 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				pos2.z = 0;

			if ((pos1 == pos2)&&(m_mouse.y>m_player.y)) {
				Instantiate (boxPrefab, pos1, Quaternion.identity);
			}
		}
		
	}
}





