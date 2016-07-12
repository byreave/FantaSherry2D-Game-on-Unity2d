using UnityEngine;
using System.Collections;

public class OnFanta : MonoBehaviour {

    AudioSource newItem;
    bool isTriggered;
    void Start()
    {
        isTriggered = false;
        newItem = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isTriggered)
        {
            other.GetComponent<Game>().health ++;
            //Debug.Log(other.GetComponent<Game>().hasKey);
            newItem.volume = 0.5f;
            newItem.Play();
            isTriggered = true;
            this.GetComponent<Renderer>().enabled = false;
            //Destroy(gameObject);
        }
        //Debug.Log(other.GetComponent<Game>().health);
    }
    void Update()
    {
        if (isTriggered && !newItem.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
