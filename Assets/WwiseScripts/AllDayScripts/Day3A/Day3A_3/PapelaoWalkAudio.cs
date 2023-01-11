using UnityEngine;
using System.Collections;

public class PapelaoWalkAudio : MonoBehaviour {
    public PlayerMovement PlayerPapelao;

    bool IsPlayed = true;

    // Update is called once per frame
    void Update()
    {

        if (PlayerPapelao.Up || PlayerPapelao.Down || PlayerPapelao.Left || PlayerPapelao.Right)
        {
            if (IsPlayed)
            {
                PlayingFootstep();
            }
        }

        if (PlayerPapelao.gameObject.activeSelf == false && IsPlayed == false)
        {
            PlayerPapelao.Up = false;
            PlayerPapelao.Down = false;
            PlayerPapelao.Left = false;
            PlayerPapelao.Right = false;

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
