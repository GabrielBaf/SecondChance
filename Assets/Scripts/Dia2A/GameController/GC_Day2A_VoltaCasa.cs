using UnityEngine;
using System.Collections;

public class GC_Day2A_VoltaCasa : MonoBehaviour {

    public GameObject Kate;
    private Waypoint_1WPS KateWps;

    public GameObject FadeCut;
    private PlayerHere FadeCutScript;

	// Use this for initialization
	void Start () {
        
        KateWps = Kate.GetComponent<Waypoint_1WPS>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space) && FadeCutScript.PHere)
        {
            FadeCut.SetActive(true);
        }

	}

    public void KateOut()
    {
        KateWps.firstWPs = true;
    }
    
}
