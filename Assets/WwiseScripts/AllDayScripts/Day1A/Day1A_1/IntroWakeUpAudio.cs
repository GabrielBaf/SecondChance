using UnityEngine;
using System.Collections;

public class IntroWakeUpAudio : MonoBehaviour
{

    bool IsPlayed = false;

    void Update()
    {
        if (IsPlayed == false)
        {
            IsPlayed = true;
            AudioPlaying("Alarm");
        }

        Destroy(this, 3.0f);
    }

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }
}