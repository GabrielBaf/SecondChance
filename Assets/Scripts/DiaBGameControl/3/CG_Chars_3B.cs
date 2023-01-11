using UnityEngine;
using System.Collections;

public class CG_Chars_3B : MonoBehaviour {

    //grupo
    public GameObject Vest1;

    public GameObject BrianPool1;
    public GameObject CharlieVest1;
    public GameObject DanVest;
    public GameObject JennaVest;
    public GameObject PamelaVest;
    public GameObject KevinPoolTalk;
    public GameObject DanPool;

    private Waypoint_3WPS BrianPoolWP;
    private Waypoint_3WPS CharlieVest1WP;
    private Waypoint_3WPS DanVestWP;
    private Waypoint_3WPS JennaVestWP;
    private Waypoint_3WPS PamelaVestWP;
    private Waypoints_4WPS KevinPoolWP;
    private Waypoint_3WPS DanPoolWP;

    private NPCFacePlayer DanFace;
    private NPCFacePlayer KevinFace;

	// Use this for initialization
	void Start () {

        BrianPoolWP = BrianPool1.GetComponent<Waypoint_3WPS>();
        CharlieVest1WP = CharlieVest1.GetComponent<Waypoint_3WPS>();
        DanVestWP = DanVest.GetComponent<Waypoint_3WPS>();
        JennaVestWP = JennaVest.GetComponent<Waypoint_3WPS>();
        PamelaVestWP = PamelaVest.GetComponent<Waypoint_3WPS>();
        KevinPoolWP = KevinPoolTalk.GetComponent<Waypoints_4WPS>();
        DanPoolWP = DanPool.GetComponent<Waypoint_3WPS>();

        DanFace = DanPool.GetComponent<NPCFacePlayer>();
        KevinFace = KevinPoolTalk.GetComponent<NPCFacePlayer>();

    }
	
	// Update is called once per frame
	void Update () {

        if(BrianPoolWP.currentPoint1 == BrianPoolWP.lastWP1)
        {
            BrianPoolWP.currentPoint1 = 0;
        }
	
	}

    //charlie dentro do vestiario
    public void CharlieAnda1()
    {
        CharlieVest1WP.firstWPs = true;
    }

    public void CharlieAnda2()
    {
        CharlieVest1WP.secondWPS = true;
    }

    //do vestiario turma vai para a aula
    public void GoCLass()
    {
        DanVestWP.firstWPs = true;
        PamelaVestWP.firstWPs = true;
        JennaVestWP.firstWPs = true;
    }

    //Dan e kevin no corredor
    public void KevinCorredor()
    {
        DanPoolWP.firstWPs = true;
        KevinPoolWP.firstWPs = true;
        Destroy(Vest1);
        KevinFace.enabled = false; DanFace.enabled = false;
    }

}
