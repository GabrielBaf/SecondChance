using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerBom : MonoBehaviour {

	public bool NextLVLZu;
	public int Leve3BZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Fim(){

		SceneManager.LoadScene(Leve3BZ);

	}

}
