using UnityEngine;
using System.Collections;

public class WalkingAudio : MonoBehaviour {

	public PlayerMovement Player;

	bool IsPlayed = true;

	// Update is called once per frame
	void Update () {

		if (Player.Up || Player.Down || Player.Left || Player.Right)
		{
			if (IsPlayed)
			{
			    PlayingFootstep();
			}
		}

		if (Player.gameObject.activeSelf == false && IsPlayed == false)
		{
            Player.Up = false;
            Player.Down = false;
            Player.Left = false;
            Player.Right = false;

            AudioStoping("footstep", 0);
			IsPlayed = true;
		}
	}

	void PlayingFootstep()
	{
		IsPlayed = false;

		AudioPlaying("footstep");

		Invoke("IsPlaying", 0.3f);
	}

	bool IsPlaying()
	{
		IsPlayed = true;
		return IsPlayed;
	}

	void AudioPlaying(string playing)
	{
		AkSoundEngine.PostEvent(playing, gameObject);
	}

	void AudioStoping(string playing, int fadeout)
	{
		uint eventID;
		eventID = AkSoundEngine.GetIDFromString(playing);
		AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
	}
}
