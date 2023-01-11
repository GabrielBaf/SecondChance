using UnityEngine;
using System.Collections;

public class ActionAudioDia2A_2 : MonoBehaviour {

    public GameObject HallCam;
    public GameObject ResponsePanel;
    public GameObject DialoguePanel;

    SoundtracksMenuAudio Soundtrack;

    bool CanPlay = false;
    bool AlreadyPlay = false;

    void Start()
    {
        Invoke("FindSoundtrackMenuAudio", 2.0f);
    }

    // Update is called once per frame
    void Update () {
        if (HallCam.activeSelf && ResponsePanel.activeSelf )
        {

            CanPlay = true;
        }

        if (CanPlay && DialoguePanel.activeSelf == false && AlreadyPlay == false)
        {
            AlreadyPlay = true;

            Soundtrack.AudioStop("Dia2", 3);
            AudioPlaying("Action");
        }

        if (gameObject.GetComponent<StephenAudioDia2A_2>().StopAction == true || gameObject.GetComponent<KevinWinAudioDay2A_2>().StopAction == true)
        {
            AlreadyPlay = false;
            CanPlay = false;

            gameObject.GetComponent<StephenAudioDia2A_2>().StopAction = false;
            gameObject.GetComponent<KevinWinAudioDay2A_2>().StopAction = false;

            Soundtrack.AudioPlaying("Dia2");
            AudioStoping("Action", 1);
        }
    }

    void FindSoundtrackMenuAudio()
    {
        Soundtrack = FindObjectOfType<SoundtracksMenuAudio>();
    }
    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }

    void AudioResume(string playing, int fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Resume, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }

    void AudioPause(string playing, int fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Pause, gameObject, fadeout * 1000, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }

    void AudioStoping(string playing, int fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 500, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }

}
