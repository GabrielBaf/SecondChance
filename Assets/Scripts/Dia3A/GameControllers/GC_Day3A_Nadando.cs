using UnityEngine;
using System.Collections;

public class GC_Day3A_Nadando : MonoBehaviour {

    public GameObject Steven;
    public GameObject Brian;
    public GameObject Emily;
    public GameObject Kevin;

    public GameObject StevenS;
    public GameObject BrianS;
    public GameObject EmilyS;
    public GameObject KevinS;

    private Waypoints_2_Generic StevenWP;
    private Waypoints_2_Generic BrianWP;
    private Waypoints_2_Generic EmilyWP;
    private Waypoints_2_Generic KevinWP;

    public GameObject SwimUp;
    public GameObject SwimDown;

    private NPCHere_Piscina SUP;
    private NPCHere_Piscina SDOWN;

	// Use this for initialization
	void Start () {

        StevenWP = StevenS.GetComponent<Waypoints_2_Generic>();
        BrianWP = BrianS.GetComponent<Waypoints_2_Generic>();
        EmilyWP = EmilyS.GetComponent<Waypoints_2_Generic>();
        KevinWP = KevinS.GetComponent<Waypoints_2_Generic>();

        SUP = SwimUp.GetComponent<NPCHere_Piscina>();
        SDOWN = SwimDown.GetComponent<NPCHere_Piscina>();


    }
	
	// Update is called once per frame
	void Update () {

        if (SDOWN.Kevin)
        {
          //  KevinWP.ChangeAnimationState(4);
            Kevin.SetActive(false);
            KevinS.SetActive(true);
        }
        if (SDOWN.Emily)
        {
       //     EmilyWP.ChangeAnimationState(4);
            Emily.SetActive(false);
            EmilyS.SetActive(true);
        }
        if (SDOWN.Brian)
        {
      //      BrianWP.ChangeAnimationState(4);
            Brian.SetActive(false);
            BrianS.SetActive(true);
        }
        if (SDOWN.Steven)
        {
       //     StevenWP.ChangeAnimationState(4);
            Steven.SetActive(false);
            StevenS.SetActive(true);
        }

        ///

        if (SUP.Kevin)
        {
            KevinWP.ChangeAnimationState(1);
            KevinWP.secondWPS = true;
            KevinWP.firstWPs = false;
        }
        if (SUP.Emily)
        {
            EmilyWP.ChangeAnimationState(1);
            EmilyWP.secondWPS = true;
            EmilyWP.firstWPs = false;
        }
        if (SUP.Brian)
        {
            BrianWP.ChangeAnimationState(1);
            BrianWP.secondWPS = true;
            BrianWP.firstWPs = false;
        }
        if (SUP.Steven)
        {
            StevenWP.ChangeAnimationState(1);
            StevenWP.secondWPS = true;
            StevenWP.firstWPs = false;
        }

    }
}
