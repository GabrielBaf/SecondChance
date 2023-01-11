using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WalkingSound : MonoBehaviour {

    public GameObject Player;
	public Animator PlayerAnim;

	int isMoving;
	bool CanPlay = true;
	bool isPlayed = false;
    bool StopPlaying = false;

	void Update()
	{

        //Dia1A_2 fix
		if (GameObject.Find("Player_Intro") != null)
		{
			if (GameObject.Find("Player_Intro").GetComponent<Waypoint_1WPS>().firstWPs == true)
			{
				CanPlay = false;
			}
			else
			{
				Invoke("PlayAudio", 3.0f);
			}
		}

        //Dia3_1 fix
        //if (Player == GameObject.Find("PlayerPiscina"))
        //{
        //    if (Player.activeSelf == false)
        //    {
        //        StopPlaying = true;
        //    }
        //}

        //Normal Flow
        if (Player.activeSelf && CanPlay == true) //StopPlaying == false
        {
                Anima();
        }

		if (isPlayed == false)
		{
			if (isMoving == 11 || isMoving == 22 || isMoving == 33 || isMoving == 44)
			{
				PlayingFootstep();
			}
		}
	}

	void Anima()
	{
		isMoving = PlayerAnim.GetInteger("AnimState");
	}

	void PlayingFootstep()
	{
		isPlayed = true;

		AudioPlaying("footstep");

        Invoke("IsPlaying", 0.3f);
	}

    bool IsPlaying()
    {
        isPlayed = false;
        return isPlayed;
    }

	bool PlayAudio()
	{
		CanPlay = true;
		return CanPlay;
	}

	void AudioPlaying(string playing)
	{
		AkSoundEngine.PostEvent(playing, gameObject);
	}

	void AudioStoping(string playing)
	{
		uint eventID;
		eventID = AkSoundEngine.GetIDFromString(playing);
		AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject);
	}

}
