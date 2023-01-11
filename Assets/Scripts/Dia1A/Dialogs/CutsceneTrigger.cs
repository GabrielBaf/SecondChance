using UnityEngine;
using System.Collections;

public class CutsceneTrigger : MonoBehaviour {

    public bool AnimationshasEnded;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AnimationEnd()
    {
        AnimationshasEnded = true;   
    }

}
