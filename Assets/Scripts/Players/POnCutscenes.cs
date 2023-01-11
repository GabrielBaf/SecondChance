using UnityEngine;
using System.Collections;

public class POnCutscenes : MonoBehaviour {

    private PlayerMovement pmov;

	// Use this for initialization
	void Start () {

        pmov = GetComponent<PlayerMovement>();

	}
	
	// Update is called once per frame
	void Update () {

        if (!pmov.isActiveAndEnabled)
        {
            if (pmov.Up)
            {
                pmov.ChangeAnimationState(1); pmov.Up = false;
            }
            if (pmov.Down)
            {
                pmov.ChangeAnimationState(4); pmov.Down = false;
            }
            if (pmov.Left)
            {
                pmov.ChangeAnimationState(3); pmov.Left = false;
            }
            if (pmov.Right)
            {
                pmov.ChangeAnimationState(2); pmov.Right = false;
            }
        }

	}
}
