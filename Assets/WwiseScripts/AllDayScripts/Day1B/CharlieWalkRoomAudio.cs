using UnityEngine;
using System.Collections;

public class CharlieWalkRoomAudio : MonoBehaviour {

    public PlayerMovement Charlie;

    bool IsPlayed = true;

    // Update is called once per frame
    void Update()
    {

        if (Charlie.Up || Charlie.Down || Charlie.Left || Charlie.Right)
        {
            if (IsPlayed)
            {
                PlayingFootstep();
            }
        }

        if (Charlie.gameObject.activeSelf == false && IsPlayed == false)
        {
            Charlie.Up = false;
            Charlie.Down = false;
            Charlie.Left = false;
            Charlie.Right = false;

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
