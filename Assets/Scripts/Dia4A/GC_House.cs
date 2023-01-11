using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_House : MonoBehaviour {

    public GameObject CharliePijama;
    private PlayerMovement CharliePijamaPMov;
    public GameObject CharlieFesta;
	private PlayerMovement CharlieFestaMov;

	public GameObject GuardaRoupa;
	private PlayerHere GuardaRoupaPHere;

    public GameObject CamCut;
    public GameObject CamPijama;
    public GameObject CamRoom;

    public GameObject IntroDay4;
    public GameObject IntroDialogue;
    public GameObject KateRoom;
    public GameObject KillKate;

    public GameObject George;
    private Waypoint_1WPS GeorgeWP;

    public GameObject Keys;

    public GameObject PortaCharlie;

    public GameObject FadeChange;
	public GameObject FadeInn;

    private Waypoint_3WPS KateRoomWP;
    private PlayerHere KillKatePHere;

    private bool katebool = true;
    public int LevelN;

    // Use this for initialization
    void Start ()
    {
		CharlieFestaMov = CharlieFesta.GetComponent<PlayerMovement>();

		GuardaRoupaPHere = GuardaRoupa.GetComponent<PlayerHere>();

        GeorgeWP = George.GetComponent<Waypoint_1WPS>();
        KateRoomWP = KateRoom.GetComponent<Waypoint_3WPS>();
        CharliePijamaPMov = CharliePijama.GetComponent<PlayerMovement>();
        KillKatePHere = KillKate.GetComponent<PlayerHere>();

    }
	
	// Update is called once per frame
	void Update () {

		if(GuardaRoupaPHere.PHere)
		{
			CharlieFestaMov.enabled = true;
		}

        if (KateRoom.activeSelf)
        {
            CharliePijamaPMov.enabled = false;
        }

        if (!KateRoom.activeSelf && katebool)
        {
            CharliePijamaPMov.enabled = true;
            katebool = false;
        }

        if (!IntroDay4.activeSelf)
        {
            IntroDialogue.SetActive(true);
        }

        if (KillKatePHere.PHere)
        {
            KateRoom.SetActive(false);
        }
        
	
	}

    public void MomEnters()
    {
        CamCut.SetActive(false);
        CamPijama.SetActive(true);
        KateRoomWP.firstWPs = true;
    }

    public void MomExits()
    {
        KateRoomWP.secondWPS = true;
        KillKate.SetActive(true);
    }

    public void DadExits()
    {
        GeorgeWP.firstWPs = true;
    }

    public void SuitUp()
    {
        FadeChange.SetActive(true);
        CamPijama.SetActive(false);
        CamRoom.SetActive(true);
        CharliePijama.SetActive(false);
        CharlieFesta.SetActive(true);
        PortaCharlie.SetActive(false);
    }

    public void GetKeys()
    {
        Keys.SetActive(false);
    }

	public IEnumerator GoToParty()
    {
		FadeInn.SetActive(true);
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene(LevelN);
    }
}
