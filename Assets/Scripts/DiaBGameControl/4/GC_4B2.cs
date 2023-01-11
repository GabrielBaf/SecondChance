using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_4B2 : MonoBehaviour {

    public GameObject Player;
    private PlayerMovement PMov;
    public GameObject PlayerOnPool;

    public GameObject Kevin;
    public GameObject Dan;
    public GameObject Brian;
    public GameObject Charlie;
    public GameObject CharlieNadando;

    private Waypoints_4WPS KevinWP;
    private Waypoints_4WPS DanWP;
    private Waypoints_4WPS BrianWP;
    private Waypoints_4WPS CharlieWP;
    private Waypoints_4WPS CharlieNadandoWP;

    public GameObject Jenny;
    public GameObject Jenna;
    public GameObject Emily;
    public GameObject Chris;
    public GameObject Anne;

    private Waypoint_2WPS JennyWP;
    private Waypoint_2WPS JennaWP;
    private Waypoint_2WPS EmilyWP;
    private Waypoint_2WPS ChrisWP;
    private Waypoint_2WPS AnneWP;

    public GameObject Fader;
    public int LevelN;

    private bool KevinNadando = false;

    public GameObject CharlieOut;
    private Waypoints_4WPS CharlieOutWP;
    private NPCFacePlayer CharlieOutFace;
    public GameObject Cam_Pool;
    public GameObject Outside_Group;
    public GameObject Final_Group;
    public GameObject CharlieRoom_Group;

    // Use this for initialization
    void Start () {

        KevinWP = Kevin.GetComponent<Waypoints_4WPS>();
        DanWP = Dan.GetComponent<Waypoints_4WPS>();
        BrianWP = Brian.GetComponent<Waypoints_4WPS>();
        CharlieWP = Charlie.GetComponent<Waypoints_4WPS>();
        CharlieNadandoWP = CharlieNadando.GetComponent<Waypoints_4WPS>();


        JennyWP = Jenny.GetComponent<Waypoint_2WPS>();
        JennaWP = Jenna.GetComponent<Waypoint_2WPS>();
        EmilyWP = Emily.GetComponent<Waypoint_2WPS>();
        ChrisWP = Chris.GetComponent<Waypoint_2WPS>();
        AnneWP = Anne.GetComponent<Waypoint_2WPS>();

        PMov = Player.GetComponent<PlayerMovement>();


        CharlieOutWP = CharlieOut.GetComponent<Waypoints_4WPS>();
        CharlieOutFace = CharlieOut.GetComponent<NPCFacePlayer>();

    }
	
	// Update is called once per frame
	void Update () {

        if (KevinNadando)
        {
            CharlieNadandoWP.ChangeAnimationState(44);
        }
	
	}

    public IEnumerator PeopleEnter()
    {
        yield return new WaitForSeconds(1f);
        JennyWP.firstWPs = true;
        JennaWP.firstWPs = true;
        EmilyWP.firstWPs = true;
        ChrisWP.firstWPs = true;
        AnneWP.firstWPs = true;
    }

    public IEnumerator KevinGangEnter()
    {
        yield return new WaitForSeconds(1f);
        CharlieWP.firstWPs = true;
        KevinWP.firstWPs = true;
        PMov.ChangeAnimationState(3);
        yield return new WaitForSeconds(2f);
        DanWP.firstWPs = true;
        BrianWP.firstWPs = true;
    }

    public IEnumerator KevinGoToPool()
    {
        yield return new WaitForSeconds(2f);
        PMov.ChangeAnimationState(2);
        CharlieWP.secondWPS = true;
        KevinWP.secondWPS = true;
        DanWP.secondWPS = true;
        BrianWP.secondWPS = true;
    }

    public IEnumerator JogaPool()
    {
        CharlieWP.secondWPS = false; KevinWP.secondWPS = false;
        yield return new WaitForSeconds(2f);
        CharlieWP.thirdWPs = true;
        KevinWP.thirdWPs = true;
        yield return new WaitForSeconds(1f);
        CharlieWP.ChangeAnimationState(55); CharlieWP.up = false;
        yield return new WaitForSeconds(2f);
        Charlie.SetActive(false);
        CharlieNadando.SetActive(true);
        KevinNadando = true;
    }

    public IEnumerator CharlieFoge()
    {
        yield return new WaitForSeconds(2f);
        Destroy(CharlieNadando);
        Charlie.SetActive(true);
        CharlieWP.fouthWPs = true;
        yield return new WaitForSeconds(4f);
        Fader.SetActive(true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(BadEnd());
    }

    public IEnumerator PularPool()
    {
        yield return new WaitForSeconds(2f);
        JennyWP.secondWPS = true;
        JennaWP.secondWPS = true;
        EmilyWP.secondWPS = true;
        ChrisWP.secondWPS = true;
        AnneWP.secondWPS = true;
        yield return new WaitForSeconds(2f);
        PlayerOnPool.SetActive(true);
        Player.SetActive(false);
    }

    public IEnumerator KevinOut()
    {
        yield return new WaitForSeconds(2f);
        KevinWP.fouthWPs = true;
        yield return new WaitForSeconds(2f);
        BrianWP.thirdWPs = true;
        DanWP.thirdWPs = true;
    }

    public IEnumerator BadEnd()
    {
        
        yield return new WaitForSeconds(2f);
        Fader.SetActive(true);
        Final_Group.SetActive(true);
        Cam_Pool.SetActive(false);
    }

    public IEnumerator GoodEnd()
    {
        yield return new WaitForSeconds(2f);
        Outside_Group.SetActive(true);
        Cam_Pool.SetActive(false);
    }

    public IEnumerator GoodEnd_Walk()
    {
        CharlieOutFace.enabled = false;
        CharlieOutWP.firstWPs = true;
        yield return new WaitForSeconds(2f);
        Fader.SetActive(true);
        yield return new WaitForSeconds(1f);
        Outside_Group.SetActive(false);
        Final_Group.SetActive(true);
    }

    public IEnumerator End()
    {
        Fader.SetActive(true);
        yield return new WaitForSeconds(1f);
        // SceneManager.LoadScene(LevelN);
        Final_Group.SetActive(false);
        CharlieRoom_Group.SetActive(true);
    }

}
