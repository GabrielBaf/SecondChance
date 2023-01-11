using UnityEngine;
using System.Collections;

public class TalkNPCWP1 : MonoBehaviour {

    public bool PHere;
    public bool PlayerInteraction;
    private Waypoint_2WPS Waypoints;
    public float MoveSpeed;

    // Use this for initialization
    void Start () {

        Waypoints = GetComponent<Waypoint_2WPS>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (PHere && Input.GetKey(KeyCode.Space))
        {
            PlayerInteraction = true;
            Waypoints.enabled = false;
        }

        if (!PHere)
        {
            PlayerInteraction = false;
            Waypoints.enabled = true;
        }

        if (PlayerInteraction)
        {
            Waypoints.moveSpeed = 0;

            Waypoints.right = false;
            Waypoints.left = false;
            Waypoints.up = false;
            Waypoints.down = false;
        }
        else
        {
            Waypoints.moveSpeed = MoveSpeed; Waypoints.enabled = true;
        }
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PHere = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PHere = false;
        }
    }

}
