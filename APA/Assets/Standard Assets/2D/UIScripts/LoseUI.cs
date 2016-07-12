using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseUI : MonoBehaviour {
    public Texture2D bg;
    public Texture2D continueBut;
    public Texture2D gameover;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), bg, ScaleMode.StretchToFill, true, 0);
        GUI.DrawTexture(new Rect(Screen.width/2 - gameover.width / 2, Screen.height/2 - gameover.height / 2, gameover.width, gameover.height), gameover);
        if (GUI.Button(new Rect(Screen.width - 5 * continueBut.width / 4,Screen.height - 3*continueBut.height / 2, continueBut.width, continueBut.height), continueBut, GUIStyle.none))
        {
            restartLevel();
        }
    }
    void restartLevel()
    {
		SceneManager.LoadScene("1-1");
    }
}
