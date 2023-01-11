using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_Day2B : MonoBehaviour {

    public GameObject IntroFade;

    public GameObject One;
    public GameObject Fade;
    public GameObject FadeLong;

    public GameObject Player;
    public GameObject PlayerCharlie;
    public GameObject CharliePijama;

    private PlayerMovement Pmov;
    private Waypoint_2WPS Pway2;
    private Waypoint_3WPS Pway3;
    public GameObject BriganoCorredor;


    public GameObject Charlie;
    public GameObject Kevin;
    public GameObject Brian;
    public GameObject Dan;
    public GameObject Sophia;
    public GameObject Steven;
    public GameObject Andy;
    public GameObject KevinCorredor;

    public Vector2 InsideClass;
    public Vector2 GoToRecepcao;
    public Vector2 GoToHall;
    public Vector2 GoToHallSteven;
    public Vector2 GoToClass;

    public GameObject CamHall;
    public GameObject CamClass;
    public GameObject CamRef;
    public GameObject CamRoom;

    public GameObject List1;
    public GameObject Hall1;
    public GameObject Recep;
    public GameObject DoorRecepRef;

    public GameObject IrateSophia;
    public GameObject FalarcomSophia;
    public GameObject SophiaeKevin;

    public GameObject IrateSteven;
    public GameObject SteveneKevin;

    private Waypoint_3WPS CharlieWP;
    private Waypoints_4WPS KevinWP;
    private Waypoint_3WPS BrianWP;
    private Waypoint_3WPS DanWP;
    private Waypoint_3WPS SophiaWP;
    private Waypoint_3WPS StevenWP;
    private PlayerHere IrateSophiaPhere;
    private PlayerHere IrateStevenPhere;

    private NPCFacePlayer KevinFace;
    private NPCFacePlayer BrianFace;
    private NPCFacePlayer StevenFace;
    private NPCFacePlayer DanFace;

    public GameObject Cama;

    public int LevelN;

    public bool test;
    private bool foirecep = true;
    private bool foirecep2 = true;

    private bool nada1 = true;
    // Use this for initialization
    void Start () {

        Pway2 = Player.GetComponent<Waypoint_2WPS>();
        Pway3 = Player.GetComponent<Waypoint_3WPS>();
        Pmov = Player.GetComponent<PlayerMovement>();
        CharlieWP = Charlie.GetComponent<Waypoint_3WPS>();
        KevinWP = Kevin.GetComponent<Waypoints_4WPS>();
        BrianWP = Brian.GetComponent<Waypoint_3WPS>();
        DanWP = Dan.GetComponent<Waypoint_3WPS>();
        SophiaWP = Sophia.GetComponent<Waypoint_3WPS>();
        StevenWP = Steven.GetComponent<Waypoint_3WPS>();

        KevinFace = Kevin.GetComponent<NPCFacePlayer>();
        BrianFace = Brian.GetComponent<NPCFacePlayer>();
        StevenFace = Steven.GetComponent<NPCFacePlayer>();
        DanFace = Dan.GetComponent<NPCFacePlayer>();

        IrateSophiaPhere = IrateSophia.GetComponent<PlayerHere>();
        IrateStevenPhere = IrateSteven.GetComponent<PlayerHere>();
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

        if (test)
        {
            Steven.transform.position = GoToHallSteven;
        }

        //ajuda sofia
        if (IrateSophiaPhere.PHere && foirecep)
        {
            Pway2.firstWPs = false;
            CamRef.SetActive(true); CamHall.SetActive(false);
            Player.transform.position = GoToRecepcao; IrateSophiaPhere.PHere = false;  IrateSophia.SetActive(false);
            foirecep = false;
            Pway2.enabled = false;
        }

        //ajuda steven
        if(IrateStevenPhere.PHere && foirecep2)
        {
            CamHall.SetActive(false);
            CamClass.SetActive(true);
            foirecep2 = false;
            Player.transform.position = GoToClass;
            Pway2.secondWPS = false;
            Pmov.ChangeAnimationState(1);
        }

	}

    public void AtivarCama()
    {
        Cama.SetActive(true);
    }

    public void KevinFight()
    {
        BriganoCorredor.SetActive(true);
        BrianWP.firstWPs = true;
        DanWP.firstWPs = true;
        DanFace.enabled = false;
        CharlieWP.firstWPs = true;
        KevinWP.firstWPs = true;
        KevinFace.enabled = false;
        Andy.SetActive(false); KevinCorredor.SetActive(false);
    }


    /// ////////////////////////////////////////// /// ////////////////////////////////////////// /// //////////////////////////////////////////

    public void AjudaSophia()
    {
        Pmov.enabled = false;
        Pway2.firstWPs = true;
        IrateSophia.SetActive(true);
        FalarcomSophia.SetActive(true);

    }

    public void SophiaCorredor()
    {
        SophiaWP.firstWPs = true;
        SophiaeKevin.SetActive(true);
        Pway2.enabled = false;
    }



    public void VoltarParaoCorredor()
    {
        Fade.SetActive(true);
        CamClass.SetActive(false);
        CamRef.SetActive(false);
        CamHall.SetActive(true);
        Player.transform.position = GoToHall;
        // Pway3.firstWPs = true;

        Pway2.ChangeAnimationState(2);

        DoorRecepRef.SetActive(true);

    }

    public void SophiaVolta()
    {
        SophiaWP.secondWPS = true;
    }

    /// ////////////////////////////////////////// /// ////////////////////////////////////////// /// //////////////////////////////////////////

    public void AjudaSteven()
    {
        Pmov.enabled = false;
        Pway2.secondWPS = true;
        IrateSteven.SetActive(true);
        SteveneKevin.SetActive(true);
    }

    public void AjudaSteven_VoltaCorredor()
    {
        Fade.SetActive(true);
        Player.transform.position = GoToHallSteven;
        Steven.transform.position = GoToHall;
        StevenFace.NPCIdlePosition = 4;
        CamClass.SetActive(false);
        CamHall.SetActive(true);
    }

    /// ////////////////////////////////////////// /// ////////////////////////////////////////// /// //////////////////////////////////////////
    public void KevinVaipraCima()
    {
        KevinWP.thirdWPs = true;
        StartCoroutine(TimertoStop());
    }

    private IEnumerator TimertoStop()
    {
        yield return new WaitForSeconds(1);
        KevinWP.currentPoint1 = 2;
        KevinWP.firstWPs = true;
        KevinWP.thirdWPs = false;
    }

    public void KevinVaiEmbora()
    {
        KevinWP.fouthWPs = true;
    }

    public void GarotosVao()
    {
        BrianWP.secondWPS = true;
        DanWP.secondWPS = true;
        BrianFace.enabled = false;
    }

    public void FezNada1()
    {
        // Pmov.enabled = false;
        //  Pway2.firstWPs = true;
        CharlieWP.secondWPS = true;

    }

    public void FezNada2()
    {
        Pmov.enabled = false;
        Pway2.secondWPS = true;
        Pway2.moveSpeed = 1;
        KevinWP.secondWPS = true;
    }

    public void FadetoClass()
    {
        Fade.SetActive(true);
        Player.transform.position = InsideClass;
        Pmov.ChangeAnimationState(4);
        CamClass.SetActive(true);
        CamHall.SetActive(false);
        List1.SetActive(false);
        Pway2.secondWPS = false;
        Pway2.enabled = false;
        One.SetActive(false);
        DoorRecepRef.SetActive(true);
        Recep.SetActive(false);
        Hall1.SetActive(false);
    }

    public void GoToCharlieRoom()
    {
        StartCoroutine(WaitToRoom());
    }

    private IEnumerator WaitToRoom()
    {
        yield return new WaitForSeconds(4f);
        FadeLong.SetActive(true);
        CamRef.SetActive(false);
        CamRoom.SetActive(true);
        PlayerCharlie.SetActive(true);
        Destroy(Player);
    }

    public void GoSleep()
    {
        Destroy(PlayerCharlie);
        CharliePijama.SetActive(true);
        StartCoroutine(WaitToEnd());
    }

    private IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(4f);
        FadeLong.SetActive(true);
        SceneManager.LoadScene(LevelN);
    }

}
