using UnityEngine;
using System.Collections;

public class GC_School2_Armario : MonoBehaviour {

    public GameObject GameController;
    public GameObject Player;
    public GameObject KevinHall;
    public GameObject Andy;

    public GameObject Black;

    public GameObject NPCHall;
    public GameObject Chris;
    public GameObject ChrisRecep;
    public GameObject Steven;
    public GameObject Pamela;
    public GameObject Jenna;

    public GameObject Event_Triggers;
    public GameObject Event_SomeChars;
    public GameObject Event_Andarecep;
    public GameObject Event_KevinPrende;
    public GameObject Event_GoHome;

    private PlayerHere Event_SomeCharsSC;
    private PlayerHere Event_AndarecepSC;
    private PlayerHere Event_GoHomeSC;

    private Waypoint_1WPS CrisWay;
    private Waypoint_1WPS StevenWay;
    private Waypoint_1WPS PamelaWay;
    private Waypoint_1WPS JennaWay;

    private Waypoints_4WPS KevinWay;
    private Waypoint_1WPS PlayerWay1;
    private Waypoints_4WPS PlayerWay4;
    private NPCFacePlayer KevinNPCFace;

    private PlayerMovement PMov;
    private GC_School2 GCSchool2;
    public float TimetoHelp = 10f;
    public bool Andycome;

    private bool nada1 = false;
    private bool nada2 = true;

    // Use this for initialization
    void Start () {

        Event_SomeCharsSC = Event_SomeChars.GetComponent<PlayerHere>();
        Event_AndarecepSC = Event_Andarecep.GetComponent<PlayerHere>();
        Event_GoHomeSC = Event_GoHome.GetComponent<PlayerHere>();

        CrisWay = Chris.GetComponent<Waypoint_1WPS>();
        StevenWay = Steven.GetComponent<Waypoint_1WPS>();
        PamelaWay = Pamela.GetComponent<Waypoint_1WPS>();
        JennaWay = Jenna.GetComponent<Waypoint_1WPS>();

        PlayerWay1 = Player.GetComponent<Waypoint_1WPS>();
        PlayerWay4 = Player.GetComponent<Waypoints_4WPS>();
        KevinWay = KevinHall.GetComponent<Waypoints_4WPS>();

        PMov = Player.GetComponent<PlayerMovement>();
        GCSchool2 = GameController.GetComponent<GC_School2>();

        KevinNPCFace = KevinHall.GetComponent<NPCFacePlayer>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Event_SomeCharsSC.PHere)
        {
            Event_SomeChars.SetActive(false);
            NPCHall.SetActive(false);
            CrisWay.firstWPs = true;
            ChrisRecep.SetActive(false);
        }

        if (Event_AndarecepSC.PHere)
        {
            Event_Andarecep.SetActive(false);
            StevenWay.firstWPs = true; PamelaWay.firstWPs = true; JennaWay.firstWPs = true;
        }

        if (Andycome == true)
        {
            PMov.enabled = false;
            KevinHall.SetActive(false);

            TimetoHelp -= Time.deltaTime;

            if (TimetoHelp <= 0)
            {
                Andy.SetActive(true);
                Black.SetActive(false);
                Andycome = false;
            }

        }

        if (Event_GoHomeSC.PHere && nada2)
        {
            GCSchool2.GoHomee = true;
            nada2 = false;
        }

	
	}

    public void AtivarEventSomeChars()
    {
        Event_Triggers.SetActive(true);
        KevinHall.SetActive(true);
    }

    /// ARMARIO
    /// 
    public void charlie1()
    {
        PlayerWay4.firstWPs = true;
    }

    public void charlie2()
    {
        PlayerWay4.secondWPS = true;
    }

    public void charlie3()
    {
        PlayerWay4.thirdWPs = true;
    }

    public void charlie4()
    {
        PlayerWay4.fouthWPs = true;
    }

    public void Kevin1()
    {
        KevinWay.firstWPs = true;
        KevinNPCFace.enabled = false;
    }

    public void Kevin2()
    {
        KevinWay.secondWPS = true;
    }

    public void Kevin3()
    {
        KevinWay.thirdWPs = true;
    }

    public void InsideLocker()
    {
        Black.SetActive(true);
        Andycome = true;
    }

    public IEnumerator GoHome()
    {
      //  Event_GoHome.SetActive(true);
        PlayerWay4.down = false;
        PlayerWay1.firstWPs = true;
		PMov.speed = 0;
        PMov.enabled = false;
        yield return new WaitForSeconds(2);

        GCSchool2.GoHomee = true;
        nada2 = false;

        Player.SetActive(false);
        PlayerWay1.enabled = false;
    }

}
