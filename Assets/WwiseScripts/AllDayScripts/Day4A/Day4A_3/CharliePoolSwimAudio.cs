using UnityEngine;
using System.Collections;

public class CharliePoolSwimAudio : MonoBehaviour {

    public PlayerMovement PlayerPool;

    bool IsPlayed = true;
    bool FeltWater = false;

    // Update is called once per frame
    void Update()
    {

        if (FeltWater == false && PlayerPool.gameObject.activeSelf)
        {
            FeltWater = true;

            AudioPlaying("FeltWater");
        }


        if (PlayerPool.Up || PlayerPool.Down || PlayerPool.Left || PlayerPool.Right)
        {
            if (IsPlayed)
            {
                PlayingFootstep();
            }
        }

        if (PlayerPool.gameObject.activeSelf == false && IsPlayed == false)
        {
            PlayerPool.Up = false;
            PlayerPool.Down = false;
            PlayerPool.Left = false;
            PlayerPool.Right = false;

            AudioStoping("SwimAudio", 0);
            IsPlayed = true;
        }
    }

    void PlayingFootstep()
    {
        IsPlayed = false;

        AudioPlaying("SwimAudio");

        Invoke("IsPlaying", 0.5f);
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

