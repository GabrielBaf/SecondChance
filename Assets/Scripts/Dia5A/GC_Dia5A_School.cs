using UnityEngine;
using System.Collections;

public class GC_Dia5A_School : MonoBehaviour {

    public GameObject Player;
    private Waypoints_4WPS PlayerWP;
    private PlayerMovement PMov;

    //CharsOut
    public GameObject James;
    public GameObject EmilyOut;
    public GameObject Chris;

    private NPCFacePlayer JamesFace;
    private Waypoint_1WPS JamesWP;
    private Waypoint_1WPS EmilyOutWP;
    private Waypoint_1WPS ChrisWP;

    //chars hall
    public GameObject Kevin;
    public GameObject EmilyHall;
    public GameObject Jenna;
    public GameObject Pamela;
    public GameObject Steven;
    public GameObject Dan;
    public GameObject Brian;
    public GameObject Catherine;
    public GameObject Leroy;

    private Waypoints_4WPS KevinWP;
    private Waypoints_4WPS EmilyHallWP;
    private Waypoints_4WPS JennaWP;
    private Waypoints_4WPS PamelaWP;
    private Waypoints_4WPS StevenWP;
    private Waypoints_4WPS DanWP;
    private Waypoints_4WPS BrianWP;
    private Waypoints_4WPS CatherineWP;
    private Waypoints_4WPS LeroyWP;

	private NPCFacePlayer_Inverse EmilyFace;

    //triggers
    public GameObject GoBackHome;
    public bool isWalkingHome;

    // Use this for initialization
    void Start () {

        PlayerWP = Player.GetComponent<Waypoints_4WPS>();
        PMov = Player.GetComponent<PlayerMovement>();

        //chars out
        JamesFace = James.GetComponent<NPCFacePlayer>();
        JamesWP = James.GetComponent<Waypoint_1WPS>();
        EmilyOutWP = EmilyOut.GetComponent<Waypoint_1WPS>();
        ChrisWP = Chris.GetComponent<Waypoint_1WPS>();

        //chars hall
        KevinWP = Kevin.GetComponent<Waypoints_4WPS>();
        EmilyHallWP = EmilyHall.GetComponent<Waypoints_4WPS>();
        JennaWP = Jenna.GetComponent<Waypoints_4WPS>();
        PamelaWP = Pamela.GetComponent<Waypoints_4WPS>();
        StevenWP = Steven.GetComponent<Waypoints_4WPS>();
        DanWP = Dan.GetComponent<Waypoints_4WPS>();
        BrianWP = Brian.GetComponent<Waypoints_4WPS>();
        CatherineWP = Catherine.GetComponent<Waypoints_4WPS>();
        LeroyWP = Leroy.GetComponent<Waypoints_4WPS>();

		EmilyFace = EmilyHall.GetComponent<NPCFacePlayer_Inverse>();


    }
	
	// Update is called once per frame
	void Update () {

        if (isWalkingHome)
        {
            PMov.enabled = false;
        }
	
	}

    public void JamesWalk() { JamesFace.enabled = false; JamesWP.firstWPs = true; }
    public void ChrisEmilyWalk() { ChrisWP.firstWPs = true; EmilyOutWP.firstWPs = true; }

    public IEnumerator HallCut()
    {
        GoBackHome.SetActive(true);
        isWalkingHome = true;
        PlayerWP.firstWPs = true;
        yield return new WaitForSeconds(2f);
        KevinWP.firstWPs = true;
        yield return new WaitForSeconds(4f);
        EmilyHallWP.firstWPs = true;
		EmilyFace.enabled = false;
        JennaWP.firstWPs = true;
        PamelaWP.firstWPs = true;
        StevenWP.firstWPs = true;
        DanWP.firstWPs = true;
        BrianWP.firstWPs = true;
        CatherineWP.firstWPs = true;
        LeroyWP.firstWPs = true;
    }

    public void KevinClose()
    {
        KevinWP.secondWPS = true;
        PlayerWP.secondWPS = true;
    }

    public void CharlieRun()
    {
        PlayerWP.thirdWPs = true;
    }

}
