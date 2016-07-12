using UnityEngine;
using System.Collections;

public class DeleteBox : MonoBehaviour {
	//public GameObject boxPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 m_mouse, m_player;
		if (Input.GetMouseButtonDown(0)) {
			m_player = Camera.main.WorldToScreenPoint (GameObject.FindWithTag ("Player").transform.position);
			m_mouse = Input.mousePosition;
			if (m_mouse.y > m_player.y) {
				Destroy (this.gameObject);
			}
		}
	}
}
