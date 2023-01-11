using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_School2 : MonoBehaviour {
    public int LevelN;
    public GameObject Fade;

    public GameObject Player;
    public GameObject PlayerCut;
    public GameObject Mom;

    public GameObject OutCam;
    public GameObject OutBound;
    public GameObject HomeCam;
    public GameObject HomeBound;
    public GameObject HouseCam;
    public GameObject HouseBounds;
    public GameObject RoomCam;
    public GameObject RoomBound;

    public GameObject Bed;
    public GameObject FadeIn;

    private PlayerHere BedScript;

    private Waypoint_3WPS PCutWPS;
    private Waypoint_1WPS MomWPs;
    private PlayerMovement Pmov;

    public Vector2 Pos1;
    public Vector2 Pos2;

    public bool End;

    public bool GoHomee;

    // Use this for initialization
    void Start () {

        PCutWPS = PlayerCut.GetComponent<Waypoint_3WPS>();
        Pmov = Player.GetComponent<PlayerMovement>();
        MomWPs = Mom.GetComponent<Waypoint_1WPS>();
       // BedScript = Bed.GetComponent<PlayerHere>();
    }
	
	// Update is called once per frame
	void Update () {

        if (End)
        {
            End = false;
            Ending();
        }

        //if (BedScript.PHere)
        //{
        //    StartCoroutine(EndDay());
        //}

        if (GoHomee)
        {
            PCutWPS.firstWPs = true;
            OutBound.SetActive(false);
            OutCam.SetActive(false);
            HomeBound.SetActive(true);
            HomeCam.SetActive(true);
            Fade.SetActive(true);
            Pmov.enabled = false;
            GoHomee = false;
        }

	
	}

    public void BackHome()
    {

        PCutWPS.firstWPs = true;
        OutBound.SetActive(false);
        OutCam.SetActive(false);
        HomeBound.SetActive(true);
        HomeCam.SetActive(true);
        Fade.SetActive(true);
        Pmov.enabled = false;
    }

    public IEnumerator InsideHouse()
    {
        PlayerCut.transform.position = Pos1;
        PCutWPS.firstWPs = false;
        HomeCam.SetActive(false);
        HomeBound.SetActive(false);
        HouseBounds.SetActive(true);
        HouseCam.SetActive(true);
        PCutWPS.secondWPS = true;
    //    MomWPs.firstWPs = true;
        Fade.SetActive(true);
        yield return new WaitForSeconds(3);
        MomWPs.firstWPs = true;
    }

    public void WalktoRoom()
    {
        PCutWPS.thirdWPs = true;
    }

    public void Ending()
    {
        HouseBounds.SetActive(false);
        HouseCam.SetActive(false);
        RoomBound.SetActive(true);
        RoomCam.SetActive(true);
        Player.SetActive(true);
        Player.transform.position = Pos2;
		Pmov.speed = 0.04f;
        Pmov.ChangeAnimationState(4);
        Pmov.enabled = true;
    }

     public void NextScene()
        {
            StartCoroutine(EndDay());
        }

private IEnumerator EndDay()
    {
        yield return new WaitForSeconds(3);
        FadeIn.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(LevelN);
    }

}
