 using UnityEngine;
using System.Collections;

public class GC_Day3B : MonoBehaviour {


    public GameObject IntroFade;

    public GameObject Player;
    public GameObject PlayerS;
    public GameObject PlayerCut;

    public GameObject Fade;
    public Vector2 AfterClassPos;

    public GameObject CharsOnPool;
    public GameObject Vest2;

    public GameObject DoorVestPool;
    public GameObject DoorPoolVest;
    public GameObject SeTrocar;
    public GameObject SeTrocouPHere;
    public GameObject IrParaPiscina;

    public GameObject KevinPool;
    public GameObject CharliePool;
    public GameObject EmilyPool;
    public GameObject BrianPool;

    

    public GameObject VestCam;
    public GameObject VestCamS;
    public GameObject PoolCam;
    public GameObject PoolCamCut;

    public GameObject FinishCheck;
    public GameObject FinishPool;

    public GameObject BulliesTalk;

    private PlayerHere SeTrocouPhereScript;
    private PlayerHere IrParaPiscinaScript;
    private PlayerHere FinishCheckScript;
    private PlayerHere FinishPoolScript;

    private Waypoints_4WPS PlayerWP;
    private Waypoints_4WPS CharlieWP;
    private Waypoints_4WPS KevinWP;
    private Waypoints_4WPS EmilyWP;
    private Waypoints_4WPS BrianWP;

    private NPCFacePlayer EmilyFace;
    private NPCFacePlayer BrianFace;

    private CG_Chars_3B CG_CharsSC;

    public bool test;


    private PlayerMovement Pmov;
    private bool nada1 = true;

    // Use this for initialization
    void Start ()
    {
        Pmov = Player.GetComponent<PlayerMovement>();

        CG_CharsSC = GetComponent<CG_Chars_3B>();

        SeTrocouPhereScript = SeTrocouPHere.GetComponent<PlayerHere>();
        IrParaPiscinaScript = IrParaPiscina.GetComponent<PlayerHere>();
        FinishCheckScript = FinishCheck.GetComponent<PlayerHere>();
        FinishPoolScript = FinishPool.GetComponent<PlayerHere>();


        PlayerWP = PlayerCut.GetComponent<Waypoints_4WPS>();
        CharlieWP = CharliePool.GetComponent<Waypoints_4WPS>();
        KevinWP = KevinPool.GetComponent<Waypoints_4WPS>();
        EmilyWP = EmilyPool.GetComponent<Waypoints_4WPS>();
        BrianWP = BrianPool.GetComponent<Waypoints_4WPS>();

        BrianFace = BrianPool.GetComponent<NPCFacePlayer>();
        EmilyFace = EmilyPool.GetComponent<NPCFacePlayer>();

    }
	
	// Update is called once per frame
	void Update () {

        if (IntroFade.activeSelf == true)
        {
            Pmov.enabled = false;
        }

        if (IntroFade.activeSelf == false && nada1)
        {
           Pmov.enabled = true; nada1 = false;
        }

        if (SeTrocouPhereScript.PHere)
        {
            SeTrocar.SetActive(true);
        }

        if (IrParaPiscinaScript.PHere)
        {
            PlayerS.SetActive(false);
            PlayerCut.SetActive(true);
            PlayerWP.firstWPs = true;
            PoolCam.SetActive(false); PoolCamCut.SetActive(true);
            IrParaPiscinaScript.PHere = false;
            IrParaPiscina.SetActive(false);
            CG_CharsSC.KevinPoolTalk.SetActive(false);
        }

        if (FinishCheckScript.PHere)
        {
            FinishPool.SetActive(true);
        }

        if (test)
        {
            PlayerS.transform.position = AfterClassPos;
        }

        ///CONTROL PLAYER CUT WAYPOINTS
        ///
        if(PlayerWP.firstWPs && PlayerWP.secondWPS)
        {
            PlayerWP.firstWPs = false;
        }

	}

    public void SeTrocou()
    {
        Fade.SetActive(true);
        DoorVestPool.SetActive(true);
        DoorPoolVest.SetActive(true);
        CharsOnPool.SetActive(true);
        Player.SetActive(false);
        PlayerS.SetActive(true);

        IrParaPiscina.SetActive(true);

        VestCam.SetActive(false);
        VestCamS.SetActive(true);
    }

    

    public void CharlieEnter()
    {
        CharlieWP.firstWPs = true;
    }

    public void KevinEnter()
    {
        KevinWP.firstWPs = true;
    }

    public void GoSwim()
    {
        PlayerWP.secondWPS = true;
        BrianWP.firstWPs = true;
        EmilyWP.firstWPs = true;
        KevinWP.secondWPS = true;
        CharlieWP.secondWPS = true;

        BrianFace.enabled = false;
        EmilyFace.enabled = false;

    }

    public void WinSwim()
    {
        PlayerWP.thirdWPs = true;
        BrianWP.secondWPS = true;
        EmilyWP.secondWPS = true;
        KevinWP.thirdWPs = true;
        CharlieWP.thirdWPs = true;
        PlayerWP.moveSpeed = 2.5f;
    }

    public void LoseSwim()
    {
        PlayerWP.thirdWPs = true;
        BrianWP.secondWPS = true;
        EmilyWP.secondWPS = true;
        KevinWP.thirdWPs = true;
        CharlieWP.thirdWPs = true;
        PlayerWP.moveSpeed = 1.9f;
    }

    public void AfterClass()
    {
        Fade.SetActive(true);
        StartCoroutine(WaittoGetoutofthePool());
    }

    private IEnumerator WaittoGetoutofthePool()
    {
        yield return new WaitForSeconds(2f);

        PlayerS.SetActive(true);
        PlayerCut.SetActive(false);
        PlayerS.transform.position = AfterClassPos;
        CharsOnPool.SetActive(false);

        PoolCamCut.SetActive(false);
        PoolCam.SetActive(true);

        Vest2.SetActive(true);
        BulliesTalk.SetActive(true);
        CharsOnPool.SetActive(false);
    }

}
