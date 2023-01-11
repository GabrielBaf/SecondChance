using UnityEngine;
using System.Collections;

public class PlayerSwim : MonoBehaviour {

    public Transform[] patrolPoints;
    public float moveSpeed;
    public int currentPoint;


    /// //
    /// 
    private Animator animator;

    public GameObject swimDown;
    public GameObject swimUp;
    private PlayerHere swimDownscr;
    private PlayerHere swimUpscr;
    private Waypoint_2WPS wps;
    /// 
    /// 

    // Use this for initialization
    void Start () {

        transform.position = patrolPoints[0].position;
        currentPoint = 0;
        moveSpeed = 0;

        wps = GetComponent<Waypoint_2WPS>();
        animator = GetComponent<Animator>();
        swimDownscr = swimDown.GetComponent<PlayerHere>();
        swimUpscr = swimUp.GetComponent<PlayerHere>();

    }
	
	// Update is called once per frame
	void Update () {


        if (swimDownscr.PHere)
        {
            ChangeAnimationState(55);
            wps.down = false; 
        }
        if (swimUpscr.PHere)
        {
            ChangeAnimationState(5);
            wps.down = false;
        }
        /////////////////////////////////////////

        if (transform.position == patrolPoints[currentPoint].position)
        {
            currentPoint++;
        }

        if (currentPoint == patrolPoints.Length)
        {
            // currentPoint = 0;
            moveSpeed = 0f;
        }

        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Swim"))
        {
            moveSpeed = moveSpeed + 6 * Time.deltaTime;
        }

        else
        {
            moveSpeed = moveSpeed - 0.2f * Time.deltaTime;
        }
        
        if(moveSpeed >= 2.7f)
        {
            moveSpeed = 2.7f;
        }
        if(moveSpeed <= 0f)
        {
            moveSpeed = 0f;
        }

    }


    public void ChangeAnimationState(int value)
    {
        animator.SetInteger("AnimState", value);
    }

}
