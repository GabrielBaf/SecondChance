using UnityEngine;
using System.Collections;

public class CutCharlie_Day1A : MonoBehaviour {

    private PlayerMovement pmov;
    private POnCutscenes pcut;
    private Waypoint_1WPS wps;

    public bool goToSchool;
    private bool turnBackOn;

	// Use this for initialization
	void Start () {

        pmov = gameObject.GetComponent<PlayerMovement>();
        pcut = gameObject.GetComponent<POnCutscenes>();
        wps = gameObject.GetComponent<Waypoint_1WPS>();


    }
	
	// Update is called once per frame
	void Update () {

        if (goToSchool)
        {
            GoingToSchool();
        }
        if (turnBackOn)
        {
            pmov.enabled = true;
            pcut.enabled = true;
            wps.enabled = false;
        }

	}

    private void GoingToSchool()
    {
        pmov.enabled = false;
        pcut.enabled = false;
        wps.enabled = true;
        wps.firstWPs = true;

        goToSchool = false;
    }
}
