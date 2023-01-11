using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem.Examples;

public class MenuAudio : MonoBehaviour {

	string Audio = "MainMenuSoundtrack";
    public GameObject PauseUI;
    bool IsPlayed = false;

    void Update()
    {
        if (PauseUI.activeSelf == true && IsPlayed == false)
        {
            AudioPlaying(Audio);
            IsPlayed = true;
        }
        else if (PauseUI.activeSelf == false && IsPlayed == true)
        {
            AudioStop(Audio, 2);
            IsPlayed = false;
        }
    }


	void AudioPlaying(string playing)
	{
		AkSoundEngine.PostEvent(playing, gameObject);
	}

    void AudioStop(string playing, int fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }
}
