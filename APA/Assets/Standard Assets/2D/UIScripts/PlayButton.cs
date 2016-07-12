using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {
    public void Click()
    {
        Debug.Log("111");
        SceneManager.LoadScene("Skill");
    }
}
