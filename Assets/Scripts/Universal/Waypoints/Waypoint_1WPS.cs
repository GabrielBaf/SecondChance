using UnityEngine;
using System.Collections;

public class Waypoint_1WPS : MonoBehaviour {

    public bool firstWPs;

    public Transform[] patrolPoints;
    public float moveSpeed = 2f;
    private int currentPoint;
    public int lastWP;

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
            distance = Vector3.Distance(gameObject.transform.position, patrolPoints[currentPoint].position);
            if (currentPoint < patrolPoints.Length)
                if (transform.position == patrolPoints[currentPoint].position)
                {
                    currentPoint++;
                }

            if (currentPoint == patrolPoints.Length)
            {
                currentPoint = lastWP;
                firstWPs = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
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
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////        ///////////////////////////////////////////////////////////////

        if (npcXpos > lastXpos)
        {
            ChangeAnimationState(22);
            right = true;
            left = false;
            up = false;
            down = false;
        }
        if (npcXpos < lastXpos)
        {
            ChangeAnimationState(33);
            left = true;
            right = false;
            up = false;
            down = false;
        }
        //idle left right
        if (npcXpos == lastXpos && right)
        {
            ChangeAnimationState(2);
        }
        if (npcXpos == lastXpos && left)
        {
            ChangeAnimationState(3);
        }
        //up down
        if (npcYpos > lastYpos)
        {
            ChangeAnimationState(11);
            up = true;
            down = false;
            left = false;
            right = false;
        }
        if (npcYpos < lastYpos)
        {
            ChangeAnimationState(44);
            down = true;
            up = false;
            left = false;
            right = false;
        }

        //idle up down
        if (npcYpos == lastYpos && up)
        {
            ChangeAnimationState(1);
        }
        if (npcYpos == lastYpos && down)
        {
            ChangeAnimationState(4);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////        ///////////////////////////////////////////////////////////////
    }

    public void ChangeAnimationState(int value)
    {
        animator.SetInteger("AnimState", value);
    }

}

