using UnityEngine;
using System.Collections;

public class GC_Day1B_NPCSchool : MonoBehaviour
{

    //Kate
    public GameObject Kate;
    private Waypoint_2WPS KateWPs;
    private NPCFacePlayer_Walker KateFace;
    private TalkNPCWP1 KateTalk;
    //

    private bool SecondWP = false;

    // Use this for initialization
    void Start()
    {

        KateWPs = Kate.GetComponent<Waypoint_2WPS>();
        KateFace = Kate.GetComponent<NPCFacePlayer_Walker>();
        KateTalk = Kate.GetComponent<TalkNPCWP1>();

    }

    // Update is called once per frame
    void Update()
    {
        //Kate



        if (KateTalk.PHere)
        {
            KateFace.enabled = true;

            if (KateTalk.PlayerInteraction)
            {
                if (KateWPs.right)
                {
                    KateWPs.ChangeAnimationState(2);
                }
            }

        }
        else
        {
            KateFace.enabled = false;
            KateFace.PlayerInteraction = false;
            KateFace.Diference = 0;
            KateWPs.enabled = true;
            KateTalk.enabled = true;
        }

    }
}
