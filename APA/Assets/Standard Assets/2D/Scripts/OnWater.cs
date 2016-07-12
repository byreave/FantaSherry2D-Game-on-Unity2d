using UnityEngine;
using System.Collections;

public class OnWater : MonoBehaviour {
    private bool isSlipping = false;
    private Transform P;
    private Vector3 speed = new Vector3(0.1f, 0);
    private bool faceRight;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            P = other.transform;
            //Debug.Log(P.name);
            isSlipping = true;
            //other.transform.position
            if (P.position.x < transform.position.x)
            {
                faceRight = true;
            }
            else
                faceRight = false;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            isSlipping = false;
        }
    }

    void Update()
    {
        if(isSlipping)
        {
            if (faceRight)
            {
                P.position += speed;
            }
            else
            {
                P.position -= speed;
            }
        }
        
    }
}
