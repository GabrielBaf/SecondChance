using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_Dia5A_BackHome : MonoBehaviour {

    public GameObject Player;
    public GameObject PlayerPC;
    public GameObject PlayerJantar;
    public GameObject PlayerDeitado;
    private Waypoints_4WPS PWay;
    private Waypoints_4WPS PJantarWay;
    private PlayerMovement PMov;

    //chars
    public GameObject KateKitchen;
    public GameObject Kate;
    public GameObject Case;
    public GameObject Jantar;

    private Waypoints_4WPS KateWPs;
    private Waypoints_4WPS CaseWPs;

    //door
    public GameObject DoorJantar;
    public GameObject DoorQuarto;

    //fader
    public GameObject FadeIn;

    //player pos
    public Vector2 PlayerCama;

    //cameras
    public GameObject CamJantar;
    public GameObject CamRoom;

    //triggers
    public GameObject Dormir;
    public int LevelN;

    public bool test;

	// Use this for initialization
	void Start () {

        KateWPs = Kate.GetComponent<Waypoints_4WPS>();
        CaseWPs = Case.GetComponent<Waypoints_4WPS>();
        PWay = Player.GetComponent<Waypoints_4WPS>();
        PJantarWay = PlayerJantar.GetComponent<Waypoints_4WPS>();
        PMov = Player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update () {

        if (test)
        {
            Player.transform.position = PlayerCama;
        }
	
	}

    public void KateTalk()
    {
        KateWPs.firstWPs = true;
        PWay.firstWPs = true;
    }
    public void KateTalk2()
    {
        KateWPs.secondWPS = true;
        PWay.right = false;
    }

    public void SitPC()
    {
        Player.SetActive(false);
        PlayerPC.SetActive(true);
    }

    public void OutPC()
    {
        Player.SetActive(true);
        PlayerPC.SetActive(false);
        DoorJantar.SetActive(true);
    }

    public IEnumerator FadeToRoom()
    {
        FadeIn.SetActive(true);
        PMov.enabled = false;
        yield return new WaitForSeconds(4);
        KateKitchen.SetActive(false);
        Player.transform.position = PlayerCama;
        CamJantar.SetActive(false);
        CamRoom.SetActive(true);
        PMov.enabled = false;

        yield return new WaitForSeconds(2);
        Case.SetActive(true);
        CaseWPs.firstWPs = true;
        PWay.secondWPS = true;
    }

    public void CaseDesce()
    {
        CaseWPs.secondWPS = true;
        Jantar.SetActive(true);
        PWay.left = false;
    }

    public void NoJantar()
    {
        Player.SetActive(false);
        PlayerJantar.SetActive(true);
        PJantarWay.thirdWPs = true;
    }

    public IEnumerator VoltarQuarto()
    {
        Dormir.SetActive(true);
        Player.transform.position = PlayerCama;
        Player.SetActive(true);
        PJantarWay.fouthWPs = true;
        DoorQuarto.SetActive(false);
        yield return new WaitForSeconds(3);
        FadeIn.SetActive(true);
        yield return new WaitForSeconds(3);
        CamJantar.SetActive(false);
        CamRoom.SetActive(true);
        PlayerJantar.SetActive(false);
        PMov.enabled = true;
    }

    public void Sleep()
    {
        Player.SetActive(false);
        PlayerDeitado.SetActive(true);
    }

    public IEnumerator NextScene()
    {
        FadeIn.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(LevelN);
    }

}
