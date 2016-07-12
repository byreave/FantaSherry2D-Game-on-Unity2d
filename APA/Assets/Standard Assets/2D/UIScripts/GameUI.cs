using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;

public class GameUI : MonoBehaviour {
    public Texture2D pauseBut;
    public Texture2D resumeBut;
    public Texture2D healthBar;
    public Texture2D switchButF;
    public Texture2D switchButS;
    public Texture2D modeButFire;
    public Texture2D modeButRope;
    
    private int lives;
    public bool isPaused;
    private GameObject[] player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectsWithTag("Player");

        isPaused = false;
        //Debug.Log(pauseBut.width);
        //pauseBut.Resize(pauseBut.width * 2, pauseBut.height * 2);
       //Debug.Log(pauseBut.width);

	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Screen.width);
        //Debug.Log(Screen.height);
		lives = player[0].GetComponent<Game>().health>player[1].GetComponent<Game>().health?player[0].GetComponent<Game>().health:player[1].GetComponent<Game>().health;
	    
	}
    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width-pauseBut.width*3.0f/2.0f, pauseBut.height/2, pauseBut.width, pauseBut.height), pauseBut, GUIStyle.none))
        {
            Time.timeScale = 0;
            isPaused = true;
        }
        if(isPaused)
        {
            if(GUI.Button(new Rect(Screen.width/2-resumeBut.width/2, Screen.height/2-resumeBut.height/2, resumeBut.width, resumeBut.height), resumeBut, GUIStyle.none))
            {
                Time.timeScale = 1;
                isPaused = false;
            }
        }
        
        //if (GUI.Button(new Rect(Screen.width-jumpBut.width*4.0f/3.0f, Screen.height - jumpBut.height*2.0f, jumpBut.width, jumpBut.height), jumpBut, GUIStyle.none))
        //{
        //    //GameObject.FindGameObjectWithTag("Player").GetComponent<Platformer2DUserControl>().setJump();
        //   CrossPlatformInputManager.SetButtonDown("Jump");
        //    CrossPlatformInputManager.SetButtonUp("Jump");
            
        //}
        if (GameObject.FindWithTag("Player").GetComponent<Game>().isFanta)
        {
            if (GUI.Button(new Rect(50, 30 + healthBar.height, switchButF.width, switchButF.height), switchButF, GUIStyle.none))
            {
                GameObject.FindWithTag("Player").GetComponent<Game>().isFanta = false;
            }
        }
        else
        {
            if (GUI.Button(new Rect(50, 30 + healthBar.height, switchButS.width, switchButS.height), switchButS, GUIStyle.none))
            {
                GameObject.FindWithTag("Player").GetComponent<Game>().isFanta = true;
            }
        }
        if (!GameObject.FindWithTag("Player").GetComponent<Game>().isFanta)
        {
            if (!GameObject.FindWithTag("Player").GetComponent<Game>().isModeRope)
            {
                if (GUI.Button(new Rect(Screen.width - modeButFire.width * 2.0f-pauseBut.width, pauseBut.height / 2, modeButFire.width, modeButFire.height), modeButFire, GUIStyle.none))
                {
                    GameObject.FindWithTag("Player").GetComponent<Game>().isModeRope = true;
                }
            }
            else
            {
                if (GUI.Button(new Rect(Screen.width - modeButRope.width * 2.0f-pauseBut.width, pauseBut.height / 2, modeButRope.width, modeButRope.height), modeButRope, GUIStyle.none))
                {
                    GameObject.FindWithTag("Player").GetComponent<Game>().isModeRope = false;
                }
            }
        }
        for (int i = 0; i < lives; ++i)
        {
            GUI.DrawTexture(new Rect(50 + (healthBar.width + 10) * i, 10, healthBar.width, healthBar.height), healthBar);
        }
    }
}
