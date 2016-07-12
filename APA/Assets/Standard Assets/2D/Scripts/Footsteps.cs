using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Footsteps : MonoBehaviour {
    public AudioClip [] footstep = new AudioClip[4];
    public AudioSource audioSource;
    private int timer;
	// Use this for initialization
	void Start () {
        timer = 0;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.3f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(CrossPlatformInputManager.GetAxis("Horizontal")!=0)
        {
            if (timer++ % 20 == 0)
            {
                audioSource.PlayOneShot(footstep[timer / 20]);
            }
            if (timer >= 80)
            {
                timer = 0;
            }
        }
	    
	}
}
