using UnityEngine;
using System.Collections;

public class GC_Day3A_Chars : MonoBehaviour {

    public GameObject TrocarFade;

    public GameObject Player;
    public GameObject PlayerSunga;
    public GameObject Danwp;
    public GameObject StevenWp;
    public GameObject JennaWp;
    public GameObject PamelaWp;

    private Waypoint_1WPS Dansc;
    private Waypoint_1WPS Stevensc;
    private Waypoint_1WPS Jennasc;
    private Waypoint_1WPS Pamelasc;

    //cams
    public GameObject CamDea;
    public GameObject CamAct;

	// Use this for initialization
	void Start () {

        Dansc = Danwp.GetComponent<Waypoint_1WPS>();
        Stevensc = StevenWp.GetComponent<Waypoint_1WPS>();
        Jennasc = JennaWp.GetComponent<Waypoint_1WPS>();
        Pamelasc = PamelaWp.GetComponent<Waypoint_1WPS>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Fadetrocar()
    {
        TrocarFade.SetActive(true);
        Player.SetActive(false);
        PlayerSunga.SetActive(true);
        CamDea.SetActive(false);
        CamAct.SetActive(true);
    }

    public void SairVest()
    {
        Dansc.firstWPs = true;
        Stevensc.firstWPs = true;
        Jennasc.firstWPs = true;
        Pamelasc.firstWPs = true;
    }

}
