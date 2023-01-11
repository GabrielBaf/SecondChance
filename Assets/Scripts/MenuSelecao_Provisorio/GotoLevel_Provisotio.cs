using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GotoLevel_Provisotio : MonoBehaviour {

    public bool GoLevel;
    public int LevelN;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (GoLevel)
        {
            SceneManager.LoadScene(LevelN);
        }


	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GoLevel = true;
        }
    }

}
