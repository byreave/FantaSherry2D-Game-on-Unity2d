using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour {
    public Texture2D bg;
    public Texture2D playBut;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame


    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), bg, ScaleMode.StretchToFill, true, 0);
		if(GUI.Button(new Rect(Screen.width-5*playBut.width/4, Screen.height-3*playBut.height/2, playBut.width, playBut.height), playBut, GUIStyle.none))
			SceneManager.LoadScene("1-1");
    }
}
