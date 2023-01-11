using UnityEngine;
using System.Collections;

public class GC_Waypoints : MonoBehaviour {

    public GameObject Anne;
    private Waypoint_1WPS AnneWP;
    private NPCFacePlayer AnneFace;

	// Use this for initialization
	void Start () {

        AnneWP = Anne.GetComponent<Waypoint_1WPS>();
        AnneFace = Anne.GetComponent<NPCFacePlayer>();

    }
	
	// Update is called once per frame
	void Update () {

	
	}

    public void AnneWalk()
    {
        AnneWP.firstWPs = true;
        AnneFace.enabled = false;
    }
}
