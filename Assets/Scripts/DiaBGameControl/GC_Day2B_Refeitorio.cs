using UnityEngine;
using System.Collections;

public class GC_Day2B_Refeitorio : MonoBehaviour {

    public GameObject Player;
    public GameObject Charlie;
    public GameObject Jenny;
    public GameObject Jenna;
    public GameObject Chris;
    public GameObject James;
    public GameObject Kevin;

    private Waypoint_3WPS PlayerWP3;
    private Waypoints_4WPS PlayerWP4;
    private PlayerMovement PlayerMov;

    private Waypoints_4WPS CharlieWP;
    private Waypoints_4WPS JennyWP;
    private Waypoints_4WPS JennaWP;
    private Waypoints_4WPS ChrisWP;
    private Waypoints_4WPS JamesWP;
    private Waypoints_4WPS KevinWP;

    private NPCFacePlayer JennyFace;
    public Vector2 LugarnaFila;

    public bool teste;

	// Use this for initialization
	void Start () {

        PlayerWP3 = Player.GetComponent<Waypoint_3WPS>();
        PlayerWP4 = Player.GetComponent<Waypoints_4WPS>();
        PlayerMov = Player.GetComponent<PlayerMovement>();


        CharlieWP = Charlie.GetComponent<Waypoints_4WPS>();
        JennyWP = Jenny.GetComponent<Waypoints_4WPS>();
        JennaWP = Jenna.GetComponent<Waypoints_4WPS>();
        ChrisWP = Chris.GetComponent<Waypoints_4WPS>();
        JamesWP = James.GetComponent<Waypoints_4WPS>();
        KevinWP = Kevin.GetComponent<Waypoints_4WPS>();

        JennyFace = Jenny.GetComponent<NPCFacePlayer>();
    }
	
	// Update is called once per frame
	void Update () {

        if (teste)
        {
            Player.transform.position = LugarnaFila;
        }

	}

    public void CharlieEnters()
    {
        CharlieWP.firstWPs = true;
        Player.transform.position = LugarnaFila;
        PlayerMov.enabled = false;
    }

    public void Walk1()
    {
        PlayerWP4.firstWPs = true;

        CharlieWP.firstWPs = true;
        JennyWP.firstWPs = true;
        JennaWP.firstWPs = true;
        ChrisWP.firstWPs = true;
        JamesWP.firstWPs = true;
        JennyFace.enabled = false;
    }

    public void Walk2()
    {
        PlayerWP4.secondWPS = true;

        CharlieWP.secondWPS = true;
        JennyWP.secondWPS = true;
        JennaWP.secondWPS = true;
        ChrisWP.secondWPS = true;
        JamesWP.secondWPS = true;

    }

    public void Walk3()
    {
        JennyWP.thirdWPs = true;
        JennaWP.thirdWPs = true;
        ChrisWP.thirdWPs = true;
        JamesWP.thirdWPs = true;

    }

    public void Walk4()
    {
        PlayerWP4.fouthWPs = true;
        JamesWP.fouthWPs = true;
    }

    public void KEvinEntra()
    {
        KevinWP.firstWPs = true;
    }

    public void KevinPegaLugar()
    {
        KevinWP.thirdWPs = true;
        PlayerWP4.secondWPS = true;
    }
    
    public void KevinPegaLugar2()
    {
        KevinWP.fouthWPs = true;
    }
    
    public void KevinFimdaFila()
    {
        KevinWP.secondWPS = true;
    }

    public void EmilySaidaFila()
    {
        PlayerWP3.firstWPs = true;
    }

}
