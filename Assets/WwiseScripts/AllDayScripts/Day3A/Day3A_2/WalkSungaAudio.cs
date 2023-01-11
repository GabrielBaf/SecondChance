using UnityEngine;
using System.Collections;

public class WalkSungaAudio : MonoBehaviour {

    public PlayerMovement PlayerSunga;

    bool IsPlayed = true;

    // Update is called once per frame
    void Update()
    {

        if (PlayerSunga.Up || PlayerSunga.Down || PlayerSunga.Left || PlayerSunga.Right)
        {
            if (IsPlayed)
            {
                PlayingFootstep();
            }
        }

        if (PlayerSunga.gameObject.activeSelf == false && IsPlayed == false)
        {
            PlayerSunga.Up = false;
            PlayerSunga.Down = false;
            PlayerSunga.Left = false;
            PlayerSunga.Right = false;

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
