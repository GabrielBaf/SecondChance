using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MudaSemana : MonoBehaviour {

    public int LevelN;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NextScene()
    {
        SceneManager.LoadScene(LevelN);
    }

}
