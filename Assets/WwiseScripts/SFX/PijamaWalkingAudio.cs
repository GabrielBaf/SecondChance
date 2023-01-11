using UnityEngine;
using System.Collections;

public class PijamaWalkingAudio : MonoBehaviour {

    public PlayerMovement PijamaPlayer;

    bool IsPlayed = true;

    // Update is called once per frame
    void Update()
    {

        if (PijamaPlayer.Up || PijamaPlayer.Down || PijamaPlayer.Left || PijamaPlayer.Right)
        {
             if (IsPlayed)
             {
                    PlayingFootstep();
             }
        }

        if (PijamaPlayer.gameObject.activeSelf == false && IsPlayed == false)
        {
            PijamaPlayer.Up = false;
            PijamaPlayer.Down = false;
            PijamaPlayer.Left = false;
            PijamaPlayer.Right = false;

            AudioStop("footstep", 0);
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

    void AudioStop(string playing, int fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }

}