using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_4B1 : MonoBehaviour {
    
    public int LevelN;

    public GameObject IntroFade;
    private bool nada1 = true;
    
    public GameObject Player;
    private Waypoint_1WPS PlayerWP;
    private PlayerMovement PMov;

    public GameObject Fader;

    public GameObject Kevin;
    private Waypoints_4WPS KevinWP;
    private NPCFacePlayer KevinFace;

    public GameObject KevinBully;
    private Waypoints_4WPS KevinBullyWP;
    private NPCFacePlayer KevinBullyFace;

    public GameObject Charlie;
    private Waypoint_2WPS CharlieWP;

    public GameObject Boy;
    private Waypoints_4WPS AndyWP;

    private bool CharlieWalking = false;
     
    public GameObject BeforeBully_Group;
    public GameObject KevinBully_Group;

	// Use this for initialization
	void Start () {

        KevinWP = Kevin.GetComponent<Waypoints_4WPS>();
        KevinBullyWP = KevinBully.GetComponent<Waypoints_4WPS>();
        KevinFace = Kevin.GetComponent<NPCFacePlayer>();

        KevinBullyFace = KevinBully.GetComponent<NPCFacePlayer>();
        CharlieWP = Charlie.GetComponent<Waypoint_2WPS>();
        AndyWP = Boy.GetComponent<Waypoints_4WPS>();

        PlayerWP = Player.GetComponent<Waypoint_1WPS>();
        PMov = Player.GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {

        if (IntroFade.activeSelf == true)
        {
            PMov.enabled = false;
        }

        if (IntroFade.activeSelf == false && nada1)
        {
            PMov.enabled = true; nada1 = false;
        }

        if (CharlieWalking)
        {
            CharlieWP.distance = 0f;
        }
	
	}

    //before bully
    public void KevinW()
    {
        KevinWP.secondWPS = true;
    }

    public void KevinWalk()
    {
        KevinWP.firstWPs = true; KevinFace.enabled = false;
    }

    public void AndyAproxima()
    {
        AndyWP.firstWPs = true;
    }    

    public void FaloucomAndy()
    {
        AndyWP.secondWPS = true;
    }

    public void CharlieCome()
    {
        CharlieWP.firstWPs = true;
        CharlieWalking = true;
    }

    public void CharlieVai()
    {
        CharlieWP.secondWPS = true;
        CharlieWP.ChangeAnimationState(44);
    }

    //kevinbully
    public IEnumerator KevinBullyTime()
    {
        yield return new WaitForSeconds(4f);
        Destroy(BeforeBully_Group);
        KevinBully_Group.SetActive(true);
    }

    public void KevinWalk2()
    {
        KevinBullyWP.firstWPs = true; KevinBullyFace.enabled = false;
    }

    public IEnumerator GoOut()
    {
        yield return new WaitForSeconds(2f);
        PMov.enabled = false;
        PlayerWP.firstWPs = true;
        yield return new WaitForSeconds(2f);
        Fader.SetActive(true);
        SceneManager.LoadScene(LevelN);
    }

}
