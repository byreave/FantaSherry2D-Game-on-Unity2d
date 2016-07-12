using UnityEngine;
using System.Collections;

public class BoardCreat : MonoBehaviour {
	public GameObject boardPrefab;
	public Vector3 point1;
	public Vector3 point2;
	public Vector3 point3;
	public Vector3 towards;
	public Vector3 towards2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 m_mouse, m_player;
		if (Input.GetMouseButtonDown (0)) {
			point1 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			point1.z=0;
		}
		if(Input.GetMouseButtonUp(0)){
			point2 = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			point2.z = 0;
			m_player = Camera.main.WorldToScreenPoint (GameObject.FindWithTag ("Player").transform.position);
			m_mouse = Input.mousePosition;

			point3 = (point1 + point2) / 2;
			point3.z = 0;
			towards = point2 - point1;
			towards.z = 0;
			towards.Normalize ();

			if ((point1 != point2)&&(m_mouse.y>m_player.y)) {
				boardPrefab.transform.up = towards;
				GameObject o = Instantiate (boardPrefab, point3, Quaternion.identity) as GameObject;
				o.transform.up = towards;
			}
		}
	}
}


	