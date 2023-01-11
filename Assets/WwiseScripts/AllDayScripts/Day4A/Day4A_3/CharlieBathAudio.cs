using UnityEngine;
using System.Collections;

public class CharlieBathAudio : MonoBehaviour {

    public PlayerMovement PlayerBath;

    bool IsPlayed = true;

    // Update is called once per frame
    void Update()
    {

        if (PlayerBath.Up || PlayerBath.Down || PlayerBath.Left || PlayerBath.Right)
        {
            if (IsPlayed)
            {
                PlayingFootstep();
            }
        }

        if (PlayerBath.gameObject.activeSelf == false && IsPlayed == false)
        {
            PlayerBath.Up = false;
            PlayerBath.Down = false;
            PlayerBath.Left = false;
            PlayerBath.Right = false;

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
