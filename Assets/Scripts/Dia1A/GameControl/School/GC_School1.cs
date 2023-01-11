using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_School1 : MonoBehaviour {

    public GameObject Fade;
    public GameObject Player;

    public GameObject Stephen;

    public GameObject Emily;
    public GameObject Jenna;
    public GameObject Pamela;
    public GameObject Steven;
    public GameObject Kevin;
    public GameObject BigB;
    public GameObject Dan;


    private Waypoints_4WPS StephenWPs;
    private Waypoint_3WPS EmilyWPs;
    private Waypoint_2WPS JennaWPs;
    private Waypoint_2WPS PamelaWPs;
    private Waypoint_2WPS StevenWps;
    private Waypoint_3WPS KevinWps;
    private Waypoint_2WPS Kevin2Wps;
    private Waypoint_2WPS BigBWps;
    private Waypoint_3WPS DanWPs;

    private CharlieSit choices;
    public bool EmilyEntra;
    public bool EmilySenta;

    private bool KevinEventEnd;

    public GameObject BullyText; public int LevelN;

    //fade pra proxima fase
    public GameObject FadeNextScene;
    private Animator animatorFade;

    // Use this for initialization
    void Start () {

        EmilyWPs =      Emily.GetComponent<Waypoint_3WPS>();
        JennaWPs =      Jenna.GetComponent<Waypoint_2WPS>();
        PamelaWPs =     Pamela.GetComponent<Waypoint_2WPS>();
        StevenWps =     Steven.GetComponent<Waypoint_2WPS>();
        KevinWps =      Kevin.GetComponent<Waypoint_3WPS>();
        Kevin2Wps =     Kevin.GetComponent<Waypoint_2WPS>();
        BigBWps =       BigB.GetComponent<Waypoint_2WPS>();
        DanWPs =        Dan.GetComponent<Waypoint_3WPS>();
        StephenWPs =    Stephen.GetComponent<Waypoints_4WPS>();

        choices = Player.GetComponent<CharlieSit>();

        //fade
        animatorFade = FadeNextScene.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (EmilyEntra)
        {
            Emily.SetActive(true);
            EmilyWPs.firstWPs = true;
            EmilyEntra = false;
        }

        if (EmilySenta)
        {
            EmilyWPs.firstWPs = false;
            if (choices.Emily)
            {
                EmilyWPs.thirdWPs = true;
            }
            else
            {
                EmilyWPs.secondWPS = true;
            }
            EmilySenta = false;

            DanWPs.firstWPs = true;
            KevinWps.firstWPs = true;

        }

        if (KevinEventEnd)
        {
            StartCoroutine(OutrosAlunosEntram());
        }
	
	}

    public void SentarEmily()
    {
        EmilySenta = true;
    }
    public void KevineDanEntram()
    {
        StartCoroutine(ContadorparaKevinSentar());
    }

    IEnumerator ContadorparaKevinSentar()
    {
        yield return new WaitForSeconds(4);
        if (choices.Dan)
        {
            DanWPs.thirdWPs = true;
        }
        else
        {
            DanWPs.secondWPS = true;
        }

        if (choices.Kevin)
        {
            KevinWps.thirdWPs = true;
        }
        else
        {
            KevinWps.secondWPS = true;
            KevinEventEnd = true;
        }
    }

    public void FimdoKevinBully1()
    {
        Fade.SetActive(true);
        choices.Kevin = false;
        StartCoroutine(ContadorparaTrocardeLugar());
    }

    IEnumerator ContadorparaTrocardeLugar()
    {
        Vector2 PlayerPos = new Vector3(6.39f, 4.96f);
        Vector2 KevinPos = new Vector3(8.41f, 4.97f);
        yield return new WaitForSeconds(2);
        Player.transform.position = PlayerPos;
        Kevin.transform.position = KevinPos;
        KevinWps.up = true;
        KevinWps.left = false;
        KevinEventEnd = true;
    }

    IEnumerator OutrosAlunosEntram()
    {
        if (choices.pamela)
        {
            PamelaWPs.secondWPS = true;
        }
        else
        {
            PamelaWPs.firstWPs = true;
        }

        if (choices.BigB)
        {
            BigBWps.secondWPS = true;
        }
        else
        {
            BigBWps.firstWPs = true;
        }

        yield return new WaitForSeconds(2);

        

        if (choices.Jenna)
        {
            JennaWPs.secondWPS = true;
        }
        else
        {
            JennaWPs.firstWPs = true;
        }

        if (choices.Steven)
        {
            StevenWps.secondWPS = true;
        }
        else
        {
            StevenWps.firstWPs = true;
        }

    }

    public void ProfessorIn()
    {
        StartCoroutine(ProfessoEntra());
    }

    IEnumerator ProfessoEntra()
    {
        yield return new WaitForSeconds(1);
        KevinEventEnd = false;
        StephenWPs.firstWPs = true;
    }

    public void Professorvaipegaroslivros()
    {
        StephenWPs.secondWPS = true;
        StartCoroutine(ContadorparaKevinBully());
    }

    IEnumerator ContadorparaKevinBully()
    {
        yield return new WaitForSeconds(3);
        BullyText.SetActive(true);
    }

    public void TeacherReturns1()
    {
        StephenWPs.thirdWPs = true;
        BullyText.SetActive(false);
    }
    public void FadetoAfterClass()
    {
        StephenWPs.fouthWPs = true;
        animatorFade.Play("FadeIn");
        StartCoroutine(ProximaFase());
        //desativar isso nas proximas builds
        //SceneManager.LoadScene(LevelN);
    }
    private IEnumerator ProximaFase()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(LevelN);

    }



}
