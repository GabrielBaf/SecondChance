using UnityEngine;
using System.Collections;

public class GC_Day2A_RefFila : MonoBehaviour {

    public GameObject Anne;
    public GameObject Catherine;
    public GameObject Leroy;

    private Waypoints_4WPS Annewp;
    private Waypoints_4WPS LeroyWps;

	// Use this for initialization
	void Start () {

        Annewp = Anne.GetComponent<Waypoints_4WPS>();
        LeroyWps = Leroy.GetComponent<Waypoints_4WPS>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Anneanda()
    {
        Annewp.firstWPs = true;
    }
    public void LeroyAnda()
    {
        LeroyWps.firstWPs = true;
    }

}
