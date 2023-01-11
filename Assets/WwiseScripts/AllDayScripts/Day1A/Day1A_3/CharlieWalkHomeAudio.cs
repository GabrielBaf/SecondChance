using UnityEngine;
using System.Collections;

public class CharlieWalkHomeAudio : MonoBehaviour {

    public Waypoint_3WPS PlayerWalkHome;
    public GameObject HallHome_Cam;

    bool IsPlayed = true;

    // Update is called once per frame
    void Update()
    {

        if (PlayerWalkHome.up || PlayerWalkHome.down || PlayerWalkHome.left || PlayerWalkHome.right)
        {
            if (IsPlayed)
            {
                PlayingFootstep();
            }
        }

        if (HallHome_Cam.activeSelf)
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
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }
}
