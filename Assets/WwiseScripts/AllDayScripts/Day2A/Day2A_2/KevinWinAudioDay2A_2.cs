using UnityEngine;
using System.Collections;

public class KevinWinAudioDay2A_2 : MonoBehaviour {

    public GameObject LoseIMG;
    public GameObject NPCSubtitlePanel;

    bool IsPlaying = false;
    string AudioToStop;

    //RePlace The Soundtrack
    public bool StopAction = false;

    // Update is called once per frame
    void Update () {

        if (LoseIMG.activeSelf && NPCSubtitlePanel.activeSelf)
        {
            if (IsPlaying == false)
            {
                IsPlaying = true;

                StopAction = true;

                AudioToPlay("KevinCustom_01", 1.0f);
            }
        }

        if (LoseIMG.activeSelf == false)
        {
            IsPlaying = false;
        }
    }

    void AudioToPlay(string AudioName, float ForSeconds)
    {
        AudioToStop = AudioName;

        AudioPlaying(AudioName);
        Invoke("AudioLength", ForSeconds);
    }

    void AudioLength()
    {
        AudioStoping(AudioToStop, 1);
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
