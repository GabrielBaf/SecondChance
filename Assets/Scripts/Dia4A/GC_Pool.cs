using UnityEngine;
using System.Collections;

public class GC_Pool : MonoBehaviour {

    public GameObject Fade;

    public GameObject Charlie;
    public GameObject CharliePool;
    public GameObject CharlieWay;
    public GameObject CharlieBath;

    public GameObject Kevin;
    public GameObject Brian;
    public GameObject Dan;
    public GameObject KevinCam;

    public GameObject NPCsPool;
    public GameObject NPCsParty;

    public GameObject CamPool;
    public GameObject CamBath;
    
    public Vector2 BrianPos;
    public Vector2 DanPos;
    
    public GameObject ActiveOnPool;
    public GameObject ColToBath;
    private PlayerHere ColToBathHere;
     
    private Waypoints_4WPS KevinWay;
    private Waypoints_4WPS BrianWay;
    private Waypoints_4WPS DanWay;

    private NPCFacePlayer KevinFace;
    private NPCFacePlayer BrianFace;
    private NPCFacePlayer DanFace;

    private GC_GetOut GetOutScript;

    public bool test;

    // Use this for initialization
    void Start () {

        GetOutScript = GetComponent<GC_GetOut>();

        KevinWay = Kevin.GetComponent<Waypoints_4WPS>();
        BrianWay = Brian.GetComponent<Waypoints_4WPS>();
        DanWay = Dan.GetComponent<Waypoints_4WPS>();

        KevinFace = Kevin.GetComponent<NPCFacePlayer>();
        BrianFace = Brian.GetComponent<NPCFacePlayer>();
        DanFace = Dan.GetComponent<NPCFacePlayer>();

        ColToBathHere = ColToBath.GetComponent<PlayerHere>();

    }
	
	// Update is called once per frame
	void Update () {

        if (test)
        {
            Fade.SetActive(true);
            Kevin.SetActive(false);
            KevinCam.SetActive(true);
            Charlie.SetActive(false);
            CharliePool.SetActive(true);

            Brian.transform.position = BrianPos;
            Dan.transform.position = DanPos;
        }

        if(ColToBathHere.PHere)
        {
            CharlieBath.SetActive(true);
            CamBath.SetActive(true);
            CamPool.SetActive(false);
        }
	}

    public void WalkToPool()
    {
        KevinFace.enabled = false;
        BrianFace.enabled = false;
        DanFace.enabled = false;

        KevinWay.firstWPs = true;
        BrianWay.firstWPs = true;
        DanWay.firstWPs = true;

    }

    public void FadeToPool()
    {
        Fade.SetActive(true);
        Kevin.SetActive(false);
        KevinCam.SetActive(true);
        Charlie.SetActive(false);
        CharliePool.SetActive(true);
        ActiveOnPool.SetActive(true);
        Brian.transform.position = BrianPos;
        Dan.transform.position = DanPos;    
    }

    public void OutofPool()
    {
        Fade.SetActive(true);
        CharliePool.SetActive(false);
        CharlieWay.SetActive(true);
    }

    public void ToBath()
    {
        NPCsPool.SetActive(false);
        NPCsParty.SetActive(true);
        ColToBathHere.PHere = false; ColToBath.SetActive(false);
        Destroy(CharlieWay);
        Destroy(CharliePool);
        Destroy(Charlie);
        GetOutScript.enabled = true;
    }

}
