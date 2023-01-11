using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_Party1 : MonoBehaviour {
    public GameObject FlashFoto;
    public GameObject Player;

    public GameObject Andy;
    public GameObject AndyF;

    public GameObject KissConversation;
    public GameObject CharlieKissCut;
    public GameObject AnyKissCut;
    public GameObject KevinCut;
    public GameObject KevinCam;
    public GameObject BrianCut;
    public GameObject DanCut;

    public GameObject KissCutscene;

    private Waypoints_4WPS CHWay;
    private Waypoints_4WPS ANWay;
    private Waypoints_4WPS KVWay;
    private Waypoints_4WPS DAWay;
    private Waypoints_4WPS BBWay;
    private Waypoint_1WPS CHWay1;
    private Waypoint_2WPS CHWay2;
    private Waypoint_2WPS ANWay2;
    private PlayerHere KissConversationSC;

    private Animator KevinCamAnim;
    public int LevelN;

    // Use this for initialization
    void Start () {

        CHWay = CharlieKissCut.GetComponent<Waypoints_4WPS>();
        CHWay1 = CharlieKissCut.GetComponent<Waypoint_1WPS>();
        ANWay = AnyKissCut.GetComponent<Waypoints_4WPS>();
        CHWay2 = CharlieKissCut.GetComponent<Waypoint_2WPS>();
        ANWay2 = AnyKissCut.GetComponent<Waypoint_2WPS>();
        KVWay = KevinCut.GetComponent<Waypoints_4WPS>();
        DAWay = BrianCut.GetComponent<Waypoints_4WPS>();
        BBWay = DanCut.GetComponent<Waypoints_4WPS>();
        KissConversationSC = KissConversation.GetComponent<PlayerHere>();
        KevinCamAnim = KevinCam.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if (KissConversationSC.PHere)
        {
            Player.SetActive(false);
            AndyF.SetActive(false);
            CharlieKissCut.SetActive(true);
            AnyKissCut.SetActive(true);
        }
	
	}

    public void ProcuraAndy()
    {
        Andy.SetActive(true);
    }

    public void AndyFollow()
    {
        Andy.SetActive(false); AndyF.SetActive(true);
        KissConversation.SetActive(true);
    }

    public void ActivateKissCut()
    {
        KissCutscene.SetActive(true);
    }

    /// ///////////////////////////////////////////////////////////////////////
    /// 

    public void Charlie1() { CHWay.firstWPs = true; }
    public void Charlie2() { CHWay.secondWPS = true; }
    public void Charlie3() { CHWay.thirdWPs = true; }
    public void Charlie4() { CHWay.fouthWPs = true; }

    public void Andy1() { ANWay.firstWPs = true; }
    public void Andy2() { ANWay.secondWPS = true; }
    public void Andy3() { ANWay.thirdWPs = true; }
    public void Andy4() { ANWay.fouthWPs = true; }


    public void CharlieW21() { CHWay2.firstWPs = true; CHWay.enabled = false; }
    public void CharlieW22() { CHWay2.secondWPS = true; }

    public void AndyW21() { ANWay2.firstWPs = true; ANWay.enabled = false; }
    public void AndyW22() { ANWay2.secondWPS = true; }

    public void KevinCamIn() { KevinCamAnim.SetTrigger("In"); FlashFoto.SetActive(true); }
    public void KevinCamOut() { KevinCamAnim.SetTrigger("Out"); }

    public void Kevin1() { KVWay.firstWPs = true; }
    public void Kevin2() {

        KVWay.secondWPS = true;
        DAWay.firstWPs = true;
        BBWay.secondWPS = true;
        BBWay.firstWPs = false;
        CHWay2.enabled = false;
        CHWay1.firstWPs = true;
    }


    public void Dan1() { DAWay.firstWPs = true; }
    public void Dan2() { DAWay.secondWPS = true; }

    public void Brian1() { BBWay.firstWPs = true; }
    public void Brian2() { BBWay.secondWPS = true; }

    public void NextScene()
    {
        SceneManager.LoadScene(LevelN);
    }

}
