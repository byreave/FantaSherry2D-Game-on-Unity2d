using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

	// Use this for initialization
    public int health;
    public bool hasKey;
    public bool hasTreasureMap;
    public bool isFanta;
    public bool isModeRope;
	public string level;
	void Awake() {
        isModeRope = false;
        health = 3;
        isFanta = false;
        hasKey = false;
        hasTreasureMap = false;
	}
    public void forceKill()
    {
        health = 0;
    }
    void Update()
    {
        //Debug.Log(transform.position);
		if (Application.loadedLevelName != "LoseScene")
			level = Application.loadedLevelName;
		if (transform.position.y < GameObject.Find ("ground").transform.position.y)
			forceKill ();
        if(health <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
		//Debug.Log (level);
    }
}
