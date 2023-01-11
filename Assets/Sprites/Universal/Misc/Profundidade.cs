using UnityEngine;
using System.Collections;

public class Profundidade : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Renderer> ().sortingOrder = (int)
			(transform.position.y * -5);
	
	}
}
