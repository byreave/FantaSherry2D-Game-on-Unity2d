using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour {
    public Texture2D doorOpen;
    AudioSource door;
	// Use this for initialization
	void Start () {
        door = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponent<Game>().hasKey)
            {
                DoorOpens();
            }
        }
        Debug.Log(111);
    }
    void DoorOpens()
    {
        SpriteRenderer spr = gameObject.GetComponent<SpriteRenderer>();
        //Texture2D texture2d = (Texture2D)Resources.Load("门开");//更换为红色主题英雄角色图片  
        Sprite sp = Sprite.Create(doorOpen, spr.sprite.textureRect, new Vector2(0.5f, 0.5f));//注意居中显示采用0.5f值  
        spr.sprite = sp;
        door.Play();
        if (Application.loadedLevelName == "1-2")
            SceneManager.LoadScene("1-3");
        else
            SceneManager.LoadScene("1-2");
    }
}
