using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_Day2A_Casa1 : MonoBehaviour {

    public GameObject Player;
    public GameObject PlayerPijama;
    public GameObject Fade;
    public GameObject BanheiroFade;
    public GameObject OutFade;

    public GameObject DeaCam;
    public GameObject ActCam;

    private Waypoint_1WPS PlayerWPs;
    private PlayerMovement PMov;

    public Vector2 PlayerOut;

    public GameObject SeTrocaa;

    public bool test;

    public int LevelN;
    // Use this for initialization
    void Start () {

        PlayerWPs = Player.GetComponent<Waypoint_1WPS>();
        PMov = Player.GetComponent<PlayerMovement>();


    }
	
	// Update is called once per frame
	void Update () {

        if (test)
        {
            Player.transform.position = PlayerOut;
        }
	
	}

    public void SeTrocar()
    {
        PlayerPijama.SetActive(false);
        Player.SetActive(true);
        Fade.SetActive(true);
        SeTrocaa.SetActive(false);
    }

    public void FadeBanheiro()
    {

        BanheiroFade.SetActive(true);

    }

    public void DarFade()
    {
        Fade.SetActive(true);

    }

    public IEnumerator GoToSchool()
    {
        OutFade.SetActive(true);
        PMov.enabled = false;
        Player.SetActive(false);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(LevelN);
    }

    //private IEnumerator ToSchool()
    //{
    //    yield return new WaitForSeconds(2);
    //    DeaCam.SetActive(false);
    //    ActCam.SetActive(true);
    //    Player.transform.position = PlayerOut;
    //    PlayerWPs.firstWPs = true;
    //}

}
