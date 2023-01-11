using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_Day3A_Bully : MonoBehaviour {

    public GameObject Player;

    public GameObject PlayerCaixa;

    public GameObject Kevin;
    public GameObject Brian;
    public GameObject Dan;

    public GameObject IrParaCorredor;
    public GameObject CaixaPapelao;
    public GameObject RoupaPequena;

    public Vector2 Corredor;
    public GameObject FadeCut;

    public GameObject DeaCam;
    public GameObject DeaBound;
    public GameObject ActCam;
    public GameObject ActBound;

    private PlayerMovement Pmov;

    private Waypoint_1WPS KevinWP;
    private Waypoint_1WPS BrianWP;
    private Waypoint_1WPS DanWP;

    private NPCFacePlayer KevinFace;
    private NPCFacePlayer BrianFace;
    private NPCFacePlayer DanFace;
    public int LevelN;

    //cams
    public GameObject VestBoxCam;
    public GameObject HallBoxCam;
    public Vector2 zerovector;


    // Use this for initialization
    void Start () {

        KevinWP = Kevin.GetComponent<Waypoint_1WPS>();
        BrianWP = Brian.GetComponent<Waypoint_1WPS>();
        DanWP = Dan.GetComponent<Waypoint_1WPS>();

        KevinFace = Kevin.GetComponent<NPCFacePlayer>();
        BrianFace = Brian.GetComponent<NPCFacePlayer>();
        DanFace = Dan.GetComponent<NPCFacePlayer>();

        Pmov = Player.GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SairdoVestiario()
    {
        KevinWP.firstWPs = true;
        BrianWP.firstWPs = true;
        DanWP.firstWPs = true;

        KevinFace.enabled = false;
        BrianFace.enabled = false;
        DanFace.enabled = false;
    }

    public void Ativartriggers()
    {
        IrParaCorredor.SetActive(true);
        CaixaPapelao.SetActive(true);
    }

    public void DesativaRoupas()
    {
        CaixaPapelao.SetActive(false);
        PlayerCaixa.SetActive(true);
        VestBoxCam.SetActive(true);
        DeaCam.SetActive(false);

        Player.SetActive(false);
       // Pmov.enabled = false;

    }

    public void IrparaCorredor()
    {
        Player.transform.position = Corredor;
        DeaBound.SetActive(false);
        DeaCam.SetActive(false);
        ActBound.SetActive(true);
        ActCam.SetActive(true);
    }

    public void IrparaCorredorCaixa()
    {
        PlayerCaixa.transform.position = Corredor;

        DeaBound.SetActive(false);
        DeaCam.SetActive(false);
        ActBound.SetActive(true);
        HallBoxCam.SetActive(true);
    }


    public void Fader()
    {
        FadeCut.SetActive(true);
        //trocar isso nas novas builds
        // SceneManager.LoadScene(LevelN);
       // StartCoroutine(TimeOut());
    }

    private IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(LevelN);
    }

}
