using UnityEngine;
using System.Collections;

public class Ch_Choices_1 : MonoBehaviour {

    private CutCharlie_Day1A cutCharlie;
    private PlayerMovement Pmov;

    public GameObject Player;
    public GameObject PlayerPijama;
    public GameObject PlayerWay;
    public Vector2 OutsidePos;
    public GameObject Fader;
    public bool test = false;

    public GameObject CharlieIntroCut;
    private Animator CharlieIntroCutAnim;
    private CutsceneTrigger CharlieIntroSC;

    public GameObject PratoVazio;

    public GameObject camCut;
    public GameObject camPijama;
    public GameObject camRoom;

    public GameObject CamDea;
    public GameObject BoundDea;
    public GameObject CamAct;
    public GameObject BoundAct;

    //textis
    public GameObject IntroText;

    //faders
    public GameObject OpeningFade;
    public GameObject FadeBanheiro;
    public GameObject FadeTrocar;

    //tutorial
    public GameObject Tutorial;

    //bools para n dar ruim
    private bool movimento = false;
    private PlayerMovement PlayerPijamaPMov;

    private bool nada = true;
    private bool nada1 = true;

    // Use this for initialization
    void Start () {

        CharlieIntroCutAnim = CharlieIntroCut.GetComponent<Animator>();
        CharlieIntroSC = CharlieIntroCut.GetComponent<CutsceneTrigger>();

        cutCharlie = Player.GetComponent<CutCharlie_Day1A>();
        Pmov = Player.GetComponent<PlayerMovement>();
        PlayerPijamaPMov = PlayerPijama.GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {

        if (OpeningFade.activeSelf)
        {
            Pmov.enabled = false;
        }

        if (!OpeningFade.activeSelf && !movimento)
        {
            IntroText.SetActive(true);
          //  Pmov.enabled = true;
            movimento = true;
            //CharlieIntroCutAnim.SetTrigger("Cut");
        }

        if (CharlieIntroSC.AnimationshasEnded && nada)
        {
            CharlieIntroCut.SetActive(false);
            camCut.SetActive(false);
            camPijama.SetActive(true);
            PlayerPijama.SetActive(true);
            CharlieIntroSC.AnimationshasEnded = false;
            Tutorial.SetActive(true);

            PlayerPijamaPMov.enabled = false;
            nada = false;
        }

        if (Input.GetKey(KeyCode.Return) && Tutorial.activeSelf)
        {
            PlayerPijamaPMov.enabled = true;
            Tutorial.SetActive(false);
        }

        //if(!nada && nada1)
        //{
        //    PlayerPijamaPMov.enabled = true;
        //    nada1 = false;
        //}

    }

    

    public void ShowTutorial()
    {
        //Tutorial.SetActive(true);
    }

    public void StartGame()
    {
        CharlieIntroCutAnim.SetTrigger("Cut");
    }

    public void GotoSchool()
    {
      //  Player.transform.position = OutsidePos;
        Fader.SetActive(true);
       // cutCharlie.goToSchool = true;
        CamDea.SetActive(false);
        BoundDea.SetActive(false);
        CamAct.SetActive(true);
        BoundAct.SetActive(true);
        PlayerWay.SetActive(true);

    }

    public void FadeBath()    {        FadeBanheiro.SetActive(true);    }
    public void FadeChange()
    {
        PlayerPijama.SetActive(false);
        camPijama.SetActive(false);
        FadeTrocar.SetActive(true);
        Player.SetActive(true);
        camRoom.SetActive(true);
        Pmov.enabled = true;
    }

    public void ComeuLanche() { PratoVazio.SetActive(true); }

}
