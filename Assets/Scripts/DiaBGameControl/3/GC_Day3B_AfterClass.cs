using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_Day3B_AfterClass : MonoBehaviour {

    public GameObject Fade;

    public GameObject Player;
    public GameObject PlayerS;

    public GameObject PlayerCharlie;
    public GameObject CharlieSleep;

    public GameObject KevinVest;
    public GameObject BrianVest;
    public GameObject DanVest;
    public GameObject CharlieVest;

    public GameObject CharlieHall;
    public GameObject CharlieHallS;

    public GameObject CamPool;
    public GameObject CamHall;
    public GameObject CamHallS;
    public GameObject CamRoom;

    public GameObject FalarcomProf;

    private PlayerMovement PSMov;
    private Waypoint_2WPS PlayerSWP;
    private Waypoints_4WPS KevinWP1;
    private Waypoints_4WPS BrianWP1;
    private Waypoints_4WPS DanWP1;
    private Waypoints_4WPS CharlieWP4;

    private Waypoints_4WPS CharlieHAllWP;
    private Waypoints_4WPS CharlieHAllSWP;

    private NPCFacePlayer DanFace;
    private NPCFacePlayer BrianFace;

    public Vector2 HallwayPos;
    public bool test;

    private bool TrocouRoupa;
    public int LevelN;

    // Use this for initialization
    void Start () {

        KevinWP1 = KevinVest.GetComponent<Waypoints_4WPS>();
        BrianWP1 = BrianVest.GetComponent<Waypoints_4WPS>();
        DanWP1 = DanVest.GetComponent<Waypoints_4WPS>();
        CharlieWP4 = CharlieVest.GetComponent<Waypoints_4WPS>();

        PSMov = PlayerS.GetComponent<PlayerMovement>();
        PlayerSWP = PlayerS.GetComponent<Waypoint_2WPS>();
        CharlieHAllWP = CharlieHall.GetComponent<Waypoints_4WPS>();
        CharlieHAllSWP = CharlieHallS.GetComponent<Waypoints_4WPS>();

        DanFace = DanVest.GetComponent<NPCFacePlayer>();
        BrianFace = BrianVest.GetComponent<NPCFacePlayer>();

        

    }
	
	// Update is called once per frame
	void Update () {

        if (test)
        {
            Player.transform.position = HallwayPos;
        }
	
	}
    

    public void TrocouRoupaCharlie()
    {
        TrocouRoupa = true;
    }

    public void BulliesWalkOut()
    {
        KevinWP1.firstWPs = true;
        BrianWP1.firstWPs = true;
        DanWP1.firstWPs = true;
        CharlieWP4.firstWPs = true;
        DanFace.enabled = false; BrianFace.enabled = false;
        StartCoroutine(CharlieCome());
    }

    private IEnumerator CharlieCome()
    {
        yield return new WaitForSeconds(2f);
        CharlieWP4.firstWPs = true;
    }

    public void CallTeacher()
    {
        PlayerSWP.firstWPs = true;
        PSMov.enabled = false;
        FalarcomProf.SetActive(true);
    }

    public void FadetoHall()
    {
        Fade.SetActive(true);
        CamPool.SetActive(false);

        if (!TrocouRoupa)
        {
            Player.transform.position = HallwayPos;
            Player.SetActive(true);
            PlayerS.SetActive(false);
            CamHallS.SetActive(true);
           // CharlieHAllSWP.firstWPs = true;
        }

        if (TrocouRoupa)
        {
            PlayerS.transform.position = HallwayPos;
            CamHall.SetActive(true);
        }

    }

    public void CharlieEnterHall()
    {
        if (!TrocouRoupa)
        {
            CharlieHAllSWP.firstWPs = true;

        }

        if (TrocouRoupa)
        {
            CharlieHAllWP.firstWPs = true;
        }
    }

    public void CharlieGoOut()
    {
        if (TrocouRoupa)
        {
            CharlieHAllWP.secondWPS = true;
            StartCoroutine(WaitToRoom());
        }

       
    }

    private IEnumerator WaitToRoom()
    {
        yield return new WaitForSeconds(3f);
        GotoRoom();
    }

    public void GotoRoom()
    {
        Player.SetActive(false); PlayerS.SetActive(false);
        PlayerCharlie.SetActive(true);
        Fade.SetActive(true);
        CamHall.SetActive(false); CamRoom.SetActive(true);
    }

    public void GoSleep()
    {
        PlayerCharlie.SetActive(false); CharlieSleep.SetActive(true);
        StartCoroutine(EndDay());
    }

    private IEnumerator EndDay()
    {
        yield return new WaitForSeconds(3f);
        Fade.SetActive(true);
        SceneManager.LoadScene(LevelN);
    }
}
