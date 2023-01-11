using UnityEngine;
using System.Collections;

public class GC_Good : MonoBehaviour {

    public GameObject Fader;
    public GameObject Player;
    private PlayerMovement PlayerMov;
    public GameObject DayIntro;
    public GameObject IntroText;
    public GameObject Subir;

    public GameObject CamCut;
    public GameObject CamRoom;
    public GameObject CamHall;
    public GameObject CamOut;

    public GameObject CharlieOut;
    private Waypoint_1WPS CharlieWP;
    public GameObject AndyOut;
    private Waypoint_1WPS AndywP;

    private bool nada = true;

    // Use this for initialization
    void Start ()
    {
        PlayerMov = Player.GetComponent<PlayerMovement>();
        AndywP = AndyOut.GetComponent<Waypoint_1WPS>();
        CharlieWP = CharlieOut.GetComponent<Waypoint_1WPS>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (DayIntro.activeSelf)
        {
            PlayerMov.enabled = false;
        }

        if (!DayIntro.activeSelf && nada)
        {
            IntroText.SetActive(true);
            CamCut.SetActive(false);
            CamRoom.SetActive(true);
            nada = false;
        }

    }

    public void FalouMae()
    {
        Subir.SetActive(true);
    }

    public void irPraFora()
    {
        Fader.SetActive(true);
        Player.SetActive(false);
        CamHall.SetActive(false);
        CamOut.SetActive(true);

        StartCoroutine(StartWalk());

    }

    private IEnumerator StartWalk()
    {
        yield return new WaitForSeconds(2f);

        CharlieWP.firstWPs = true;

        yield return new WaitForSeconds(3f);
        AndywP.firstWPs = true;
    }

}
