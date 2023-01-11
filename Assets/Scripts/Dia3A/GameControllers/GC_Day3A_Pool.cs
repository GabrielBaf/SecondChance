using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_Day3A_Pool : MonoBehaviour
{

    private bool nada1;

    public GameObject Player;
    public GameObject PlayerSwim;
    public GameObject PlayerSunga;

    public GameObject Kevin;
    public GameObject BigB;
    public GameObject Emily;
    public GameObject Steven;

    public GameObject KevinWP;
    public GameObject BigBWP;
    public GameObject EmilyWP;
    public GameObject StevenWP;

    public GameObject ActCam;
    public GameObject DeaCam;

    public GameObject TriggerPrimeiroFim;
    public GameObject PrimeiroFimDialogo;

    public GameObject FadeCut;

    public GameObject TriggarVencedores;
    public GameObject StevenVence;
    public GameObject CharlieVence;

    private Waypoint_2WPS PlayerSwimWPs;
    private Waypoints_4WPS KevinWps;
    private Waypoint_2WPS BigBWps;
    private Waypoint_2WPS EmilyWps;
    private Waypoint_2WPS StevenWps;

    private Waypoints_2_Generic KevinWpsSwim;
    private Waypoints_2_Generic BigBWPsSwim;
    private Waypoints_2_Generic EmilyWPsSwim;
    private Waypoints_2_Generic StevenWPsSwim;


    private PlayerSwim PlayerSwimScript;

    private PlayerHere TriggerPrimeiroFim_Script;
    private PlayerHere TriggarVencedores_Script;
    public int LevelN;

    public GameObject Tut1;
    public GameObject Tut2;
    // Use this for initialization
    void Start()
    {

        PlayerSwimWPs = PlayerSwim.GetComponent<Waypoint_2WPS>();
        KevinWps = Kevin.GetComponent<Waypoints_4WPS>();
        BigBWps = BigB.GetComponent<Waypoint_2WPS>();
        EmilyWps = Emily.GetComponent<Waypoint_2WPS>();
        StevenWps = Steven.GetComponent<Waypoint_2WPS>();

        KevinWpsSwim = KevinWP.GetComponent<Waypoints_2_Generic>();
        StevenWPsSwim = StevenWP.GetComponent<Waypoints_2_Generic>();
        EmilyWPsSwim = EmilyWP.GetComponent<Waypoints_2_Generic>();
        BigBWPsSwim = BigBWP.GetComponent<Waypoints_2_Generic>();

        PlayerSwimScript = PlayerSwim.GetComponent<PlayerSwim>();
        TriggerPrimeiroFim_Script = TriggerPrimeiroFim.GetComponent<PlayerHere>();
        TriggarVencedores_Script = TriggarVencedores.GetComponent<PlayerHere>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Tut1.activeSelf && Input.GetKey(KeyCode.Return))
        {
            StartCoroutine(DelaytoSwim());
        }

        if (KevinWps.secondWPS && KevinWps.thirdWPs)
        {
            KevinWps.secondWPS = false;
        }

        if (TriggerPrimeiroFim_Script.PHere)
        {
            PrimeiroFimDialogo.SetActive(true);
            TriggerPrimeiroFim.SetActive(false);
        }

        if (TriggarVencedores_Script.PHere)
        {
            CharlieVence.SetActive(true);
            StevenVence.SetActive(true);
        }

    }

    public void KevinAnda()
    {
        KevinWps.firstWPs = true;
    }

    public void ComecouAula()
    {
        ActCam.SetActive(true);
        DeaCam.SetActive(false);

        PlayerSunga.SetActive(false);
        PlayerSwim.SetActive(true);
        PlayerSwimWPs.firstWPs = true;

        //  Tut1.SetActive(true);
        //    Tut2.SetActive(true);
    }

    public void ChegaKevin()
    {
        KevinWps.secondWPS = true;
    }

    public void Preparar()
    {
        KevinWps.moveSpeed = 2f;
        KevinWps.thirdWPs = true;
        EmilyWps.firstWPs = true;
        BigBWps.firstWPs = true;
        StevenWps.firstWPs = true;
        PlayerSwimWPs.secondWPS = true;
    }

    public void Nadar1()
    {
        Tut1.SetActive(true);
        Tut2.SetActive(true);
        PlayerSwimScript.enabled = true;
        // StartCoroutine(DelaytoSwim());

    }

    private IEnumerator DelaytoSwim()
    {
        yield return new WaitForSeconds(2);
        KevinWps.fouthWPs = true;
        EmilyWps.secondWPS = true;
        BigBWps.secondWPS = true;
        StevenWps.secondWPS = true;

        yield return new WaitForSeconds(0.8f);
        KevinWpsSwim.firstWPs = true;
        EmilyWPsSwim.firstWPs = true;
        BigBWPsSwim.firstWPs = true;
        StevenWPsSwim.firstWPs = true;

    }

    public void NadarPraValer()
    {
        StartCoroutine(DelaytoSwim2());

        PlayerSwimScript.currentPoint = 0;

        KevinWpsSwim.ChangeAnimationState(4);
        EmilyWPsSwim.ChangeAnimationState(4);
        StevenWPsSwim.ChangeAnimationState(4);
        BigBWPsSwim.ChangeAnimationState(4);

    }

    private IEnumerator DelaytoSwim2()
    {
        yield return new WaitForSeconds(2);



        KevinWpsSwim.firstWPs = true;
        EmilyWPsSwim.firstWPs = true;
        BigBWPsSwim.firstWPs = true;
        StevenWPsSwim.firstWPs = true;

        TriggarVencedores.SetActive(true);
    }

    public void Fader()
    {
        FadeCut.SetActive(true);
        //trocar isso nas novas builds
        SceneManager.LoadScene(LevelN);
    }

    public void destroyWinners()
    {
        CharlieVence.SetActive(false);
        StevenVence.SetActive(false);
    }

}