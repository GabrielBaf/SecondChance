using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class OrderinLayer_NPC : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Renderer>().sortingOrder = (int)(transform.position.y * -5);

	}
}
