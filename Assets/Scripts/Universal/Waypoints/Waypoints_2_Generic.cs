using UnityEngine;
using System.Collections;

public class Waypoints_2_Generic : MonoBehaviour {

    public bool firstWPs;
    public bool secondWPS;

    public Transform[] patrolPoints1;
    public Transform[] patrolPoints2;
    public float moveSpeed = 2f;
    public int currentPoint1;
    public int currentPoint2;
    public int lastWP1;
    public int lastWP2;

    public float distance;
    public float lastXpos;
    public float npcXpos;
    public float lastYpos;
    public float npcYpos;
    private Animator animator;

    public bool up;
    public bool down;
    public bool left;
    public bool right;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (firstWPs)
        {
            distance = Vector3.Distance(gameObject.transform.position, patrolPoints1[currentPoint1].position);
            if (currentPoint1 < patrolPoints1.Length)
                if (transform.position == patrolPoints1[currentPoint1].position)
                {
                    currentPoint1++;
                }

            if (currentPoint1 == patrolPoints1.Length)
            {
                currentPoint1 = lastWP1;
                firstWPs = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints1[currentPoint1].position, moveSpeed * Time.deltaTime);
        }

        if (secondWPS)
        {
            distance = Vector3.Distance(gameObject.transform.position, patrolPoints2[currentPoint2].position);
            if (currentPoint2 < patrolPoints2.Length)
                if (transform.position == patrolPoints2[currentPoint2].position)
                {
                    currentPoint2++;
                }

            if (currentPoint2 == patrolPoints2.Length)
            {
                currentPoint2 = lastWP2;
                secondWPS = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints2[currentPoint2].position, moveSpeed * Time.deltaTime);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////        //////////////////////////////////////////////////////////////
        npcXpos = transform.position.x;
        npcYpos = transform.position.y;

        if (distance == 0)
        {
            lastXpos = transform.position.x;
            lastYpos = transform.position.y;
        }
        else
        {
            lastXpos = lastXpos;
            lastYpos = lastYpos;
        }
    }

        public void ChangeAnimationState(int value)
    {
        animator.SetInteger("AnimState", value);
    }

}
