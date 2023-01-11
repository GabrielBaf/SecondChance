using UnityEngine;
using System.Collections;

public class GC_Day2B_Talks : MonoBehaviour {

    public GameObject Steven;
    public GameObject Sophia;
    public GameObject KevinCorredor;
    public GameObject RonaldCorredor;

    private Waypoint_3WPS StevenWay;
    private Waypoint_3WPS SophiaWay;
    private Waypoint_3WPS RonaldWay;
    private NPCFacePlayer RonaldFace;

	// Use this for initialization
	void Start () {

        StevenWay = Steven.GetComponent<Waypoint_3WPS>();
        SophiaWay = Sophia.GetComponent<Waypoint_3WPS>();
        RonaldWay = RonaldCorredor.GetComponent<Waypoint_3WPS>();
        RonaldFace = RonaldCorredor.GetComponent<NPCFacePlayer>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FaloucomSteven()
    {
        StevenWay.firstWPs = true;
    }

    public void FaloucomSophia()
    {
        SophiaWay.firstWPs = true;
    }

    //falando com kevin no corredor
    public void KevinTalkCorredor()
    {
        RonaldCorredor.SetActive(true);
    }
    public void Ronaldanda()
    {
        RonaldWay.firstWPs = true; RonaldFace.enabled = false;
    }

}
