using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_GetOut : MonoBehaviour {

    public GameObject GoOut;
    private PlayerHere GoOutPHere;

    public GameObject Pamela;
    public GameObject CamSala;
    public GameObject CamOut;
    public GameObject CamRoom;

    public GameObject Roomdialogue;
    private Animator CarAnim;
    public GameObject Car;
    
    public GameObject CharlieBath;
    public GameObject CharlieWay2;
    private Waypoint_1WPS CharlieWay2WP;
    public int LevelN;

    private bool nada1 = true;
    
	// Use this for initialization
	void Start ()
    {
        GoOutPHere = GoOut.GetComponent<PlayerHere>();
        CharlieWay2WP = CharlieWay2.GetComponent<Waypoint_1WPS>();

        CarAnim = Car.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (GoOutPHere.PHere && Input.GetKey(KeyCode.Space) && nada1)
        {
            CamSala.SetActive(false);
            CamOut.SetActive(true);
            CharlieBath.SetActive(false);
            CharlieWay2.SetActive(true);
            CharlieWay2WP.firstWPs = true;
            StartCoroutine(CutSceneGoHome());
            nada1 = false;
        }

	}

    public void StartCar()
    {
        CarAnim.SetTrigger("Go");
    }

    private IEnumerator CutSceneGoHome()
    {
        yield return new WaitForSeconds(2f);
        Pamela.SetActive(true);
        yield return new WaitForSeconds(9f);
        CarAnim.SetTrigger("Go");
    }

    public void InsideCar()
    {
        CamRoom.SetActive(true);
        CamOut.SetActive(false);
        Roomdialogue.SetActive(true);
    }

    public void FadeNextScene()
    {
        SceneManager.LoadScene(LevelN);

    }

}
