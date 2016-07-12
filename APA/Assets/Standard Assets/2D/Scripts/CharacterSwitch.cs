using UnityEngine;
using System.Collections;

public class CharacterSwitch : MonoBehaviour {

    public GameObject Sherry;
    public GameObject Fanta;
	// Use this for initialization
	void Start () {
        Fanta.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Sherry.active && Sherry.GetComponent<Game>().isFanta)
        {
            //Debug.Log(111);
            Fanta.SetActive(true);
            Fanta.transform.position = Sherry.transform.position;
            Fanta.GetComponent<Game>().isFanta = true;
            Sherry.SetActive(false);
        }
        if(Fanta.active && !Fanta.GetComponent<Game>().isFanta)
        {
            Sherry.SetActive(true);
            Sherry.transform.position = Fanta.transform.position;
            Sherry.GetComponent<Game>().isFanta = false;
            Fanta.SetActive(false);
        }
	}
}
