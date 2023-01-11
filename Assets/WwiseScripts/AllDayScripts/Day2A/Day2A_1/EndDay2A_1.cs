using UnityEngine;
using System.Collections;

public class EndDay2A_1 : MonoBehaviour {

    public Waypoint_1WPS PlayerWPS;

    bool IsPlayed = true;
    bool AlreadyPlayed = false;

    // Update is called once per frame
    void Update()
    {

        if (PlayerWPS.up || PlayerWPS.down || PlayerWPS.left || PlayerWPS.right)
        {
            if (IsPlayed)
            {
                AlreadyPlayed = true;
                PlayingFootstep();
            }
        }

        if (PlayerWPS.enabled == false && AlreadyPlayed == true)
        {
            AudioStoping("footstep", 0);

            Destroy(this);

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
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 500, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }
}
