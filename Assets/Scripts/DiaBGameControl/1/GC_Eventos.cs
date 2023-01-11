using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_Eventos : MonoBehaviour
{
    public GameObject DormirTXT;
    //faders
    public GameObject OpeningFade;

    public GameObject Player;
    public GameObject PlayerCharlie;
    public GameObject Fade;
    public GameObject FadeLong;

    public GameObject Fala_Sala;
    public GameObject Monologo;
    public GameObject VoltarProCorredor;
    public GameObject Porta_HallClass;
    public GameObject Porta_RecepOut;
    public GameObject Npodesair;
    public GameObject DialogoDentrodaSala;
    public GameObject CutsceneForadaSala_Grupo;
    public GameObject SaiudaSala_Fade;
    public GameObject SaiudaSala_BacktoClass;

    public GameObject KevinTalk;

    public Vector2 DentroSala;
    public Vector2 PosCorredor;

    //textis
    public GameObject IntroText;

    //kevindan pos
    public Vector2 KevinClassPos;
    public Vector2 DanClassPos;

    //class
    public GameObject ClassGroup;
    public GameObject KevinClass;
    public GameObject DanClass;
    public GameObject CharlieAfterClass;
    public GameObject FadeCharlieToRoom;

    //room
    public GameObject CharlieSleep;

    public GameObject CamHall;
    public GameObject CamClass;
    public GameObject CamRoom;

    private PlayerMovement Pmov;
    private Waypoint_3WPS Pway;
    private Waypoint_2WPS Pway2;
    private Waypoints_4WPS Pway4;
    private PlayerHere FimSc;
    private PlayerHere VoltarSc;
    private PlayerHere SaiudaSala_FadePHere;
    private PlayerHere SaiudaSala_BackToClassScript;
    private PlayerHere FadeCharlieToRoomSC;

    private Waypoint_3WPS CharlieAfterWP;

    public int LevelN;


    private bool nada = true;
    public bool teste2;

    private bool andadenovo1 = true;
    private bool andadenovo = true;

    //bools para n dar ruim
    private bool movimento = false;

    //não se mexer na cutscene
    public GameObject DontMove;
    private PlayerHere DontMovePHere;

    // Use this for initialization
    void Start()
    {

        Pmov = Player.GetComponent<PlayerMovement>();
        Pway = Player.GetComponent<Waypoint_3WPS>(); Pway2 = Player.GetComponent<Waypoint_2WPS>(); Pway4 = Player.GetComponent<Waypoints_4WPS>();
        VoltarSc = VoltarProCorredor.GetComponent<PlayerHere>();
        SaiudaSala_FadePHere = SaiudaSala_Fade.GetComponent<PlayerHere>();
        SaiudaSala_BackToClassScript = SaiudaSala_BacktoClass.GetComponent<PlayerHere>();
        FadeCharlieToRoomSC = FadeCharlieToRoom.GetComponent<PlayerHere>();
        DontMovePHere = DontMove.GetComponent<PlayerHere>();

        CharlieAfterWP = CharlieAfterClass.GetComponent<Waypoint_3WPS>();

    }

    // Update is called once per frame
    void Update()
    {

        if (OpeningFade.activeSelf)
        {
            Pmov.enabled = false;
        }

        if (!OpeningFade.activeSelf && !movimento)
        {
            IntroText.SetActive(true);
            movimento = true;
        }

        if (DontMovePHere.PHere)
        {
            Pmov.enabled = false;
        }

        if (VoltarSc.PHere && andadenovo)
        {
            Player.transform.position = PosCorredor;
            CamClass.SetActive(false);
            CamHall.SetActive(true);
            VoltarProCorredor.SetActive(false);
            Pway.thirdWPs = false;
            Pmov.enabled = true;
            Pway.enabled = false;
            Pmov.ChangeAnimationState(4);
            VoltarSc.PHere = false;
            andadenovo = false;
        }

        if (SaiudaSala_FadePHere.PHere)
        {
            Pmov.enabled = false;
            FadeLong.SetActive(true);
            SaiudaSala_Fade.SetActive(false);
            SaiudaSala_BacktoClass.SetActive(true);
            SaiudaSala_FadePHere.PHere = false;
            DontMove.SetActive(true);
        }

        if (SaiudaSala_BackToClassScript.PHere && nada)
        {
            Fade.SetActive(true);
            KevinTalk.SetActive(true);
            Player.transform.position = DentroSala;
            //Pmov.enabled = true;
            //  Pway2.firstWPs = true;
            Pway.up = false;
            Pway.enabled = false;
            CamHall.SetActive(false);
            CamClass.SetActive(true);
            nada = false;

            Pway.firstWPs = false; //Pway.enabled = false;
            Pway4.secondWPS = true;
            SaiudaSala_BackToClassScript.PHere = false;
        }

        //Ir para quarto do charlie
        if (FadeCharlieToRoomSC.PHere)
        {
            FadeLong.SetActive(true);
            CamClass.SetActive(false);
            CamRoom.SetActive(true);

           // Destroy(Player);
            Player.SetActive(false);
            //PlayerCharlie.SetActive(true);
            DormirTXT.SetActive(true);
            FadeCharlieToRoomSC.PHere = false;
            FadeCharlieToRoom.SetActive(false);


            StartCoroutine(StartLastTalk());

        }

    }

    public void MonologoCorredorCutscete()
    {
        //Pway.firstWPs = true;
        Pmov.enabled = false;
    }

    public void EntraSala()
    {
        Pway.secondWPS = true;
    }

    public void VoltaProCorredor()
    {
        Pway.secondWPS = false;
        Pway.thirdWPs = true;
        VoltarProCorredor.SetActive(true);
        Fala_Sala.SetActive(false);
        Monologo.SetActive(false);

        Porta_RecepOut.SetActive(true);
        Npodesair.SetActive(false);
        //   DialogoDentrodaSala.SetActive(true);
        DontMove.SetActive(true);

        CutsceneForadaSala_Grupo.SetActive(true);


    }

    public void Cutscene_PlayerAndanoCorredor()
    {
        Pway.firstWPs = true;
        Pway.enabled = true;
        Pmov.enabled = false;
        KevinClass.transform.position = KevinClassPos;
        DanClass.transform.position = DanClassPos;
    }


    public void PortaSala()
    {
        Porta_HallClass.SetActive(true);
        KevinTalk.SetActive(true);
    }

    public void StopBully_Walk1()
    {
        // Pway4.secondWPS = true;
    }

    public void StopBully_EndKevin()
    {
        Pway4.thirdWPs = true;
    }
    public void StopBully_EndNada()
    {
        Pway4.thirdWPs = true;
    }

    public IEnumerator StopBullt_End()
    {
        FadeLong.SetActive(true);
        ClassGroup.SetActive(false);
        yield return new WaitForSeconds(3f);
        CharlieAfterClass.SetActive(true);
        //Player.SetActive(false);
    }

    //charlieafter
    public void CharlieFalacomProf()
    {
        CharlieAfterWP.firstWPs = true;
    }
    public void CharlieVaiEmbora()
    {
        CharlieAfterWP.thirdWPs = true;
    }
    public void CharlieNAOFalacomProf()
    {
        CharlieAfterWP.secondWPS = true;
    }
    public void ProfPegarlivro()
    {
        CharlieAfterWP.firstWPs = false;
    }


    //END VAI PRO QUARTO DO CHARLIE
    public void GoSleep()
    {
        Destroy(PlayerCharlie);
        CharlieSleep.SetActive(true);
        StartCoroutine(FadeToEnd());
    }

    private IEnumerator FadeToEnd()
    {
        Fade.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(LevelN);
    }

    public IEnumerator StartLastTalk()
    {
        yield return new WaitForSeconds(3f);
        DormirTXT.SetActive(true);
    }
}