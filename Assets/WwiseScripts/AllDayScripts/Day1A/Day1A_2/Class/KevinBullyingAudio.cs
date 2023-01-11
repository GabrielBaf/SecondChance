using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem.Examples;

public class KevinBullyingAudio : MonoBehaviour {

    public ConversationTrigger KevingBullying;
    public GameObject NPCSubtitlePanel;
    public Text NPCSubtitleLine;
    Button ResponseButton;

    SoundtracksMenuAudio Soundtrack;

    string AtualSpeech;
    string LastSpeech;

    bool IsClick = false;
    bool PlayWhenChange = false;
    bool IsPlaying = false;
    bool IsPlayed;

    //Identifying Audio
    int AudioSwitch = 0;
    string AudioToStop;

    void Start()
    {
        Invoke("FindSoundtrackMenuAudio", 2.0f);
    }

    // Update is called once per frame
    void Update () {

        if (NPCSubtitlePanel.activeSelf && KevingBullying == null)
        {
            if (IsPlaying == false)
            {
                IsPlaying = true;

                Soundtrack.AudioStop("Dia1", 3);
                AudioPlaying("Bullying");

                Invoke("FirstText", 0.1f);

                KevinBullyingAudioPlay();

            }
            else if (IsPlaying == true)
            {

                ResponseButton = FindObjectOfType<Button>();

                if (ResponseButton != null)
                {
                    ResponseButton.onClick.AddListener(() => IsClick = true);
                }

                if (IsClick)
                {
                    IsClick = false;

                    LastSpeech = AtualSpeech;

                    Invoke("WaitToPlay", 0.1f);
                }

                if (PlayWhenChange == true)
                {
                    PlayWhenChange = false;
                    KevinBullyingAudioPlay();
                }

            }

            if (GameObject.Find("PauseUI") != null && IsPlayed == false)
            {
                AudioPause("Bullying", 2);
                IsPlayed = true;
            }

            if (GameObject.Find("PauseUI") == null && IsPlayed == true)
            {
                AudioResume("Bullying", 3);
                IsPlayed = false;
            }

        }

        if (IsPlaying == true && NPCSubtitlePanel.activeSelf == false)
        {
            AudioStoping("Bullying", 3);

            Soundtrack.AudioPlaying("Dia1");

            Destroy(this);
        }

    }


    void KevinBullyingAudioPlay()
    {
        switch (AudioSwitch)
        {
            case 0:
                AudioSwitch++;
                AudioToPlay("KevinCustom_01", 1.0f);
                break;
            case 1:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("DanCustom_01", 2.0f);
                break;
            case 2:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("DanCustom_02", 2.0f);
                break;
            case 3:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_02", 3.0f);
                break;
            case 4:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("DanCustom_03", 2.0f);
                break;
            case 5:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("BigBCustom_03", 2.0f);
                break;
            case 6:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KevinCustom_01", 1.0f);
                break;
            case 7:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_01", 2.0f);
                break;
            case 8:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KevinCustom_02", 2.0f);
                break;
            case 9:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("StephenCustom_02", 3.0f);
                break;
            case 10:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("StephenCustom_03", 2.0f);
                break;
            case 11:
                AudioLength();
                AudioStoping("Bullying", 3);
                Soundtrack.AudioPlaying("Dia1A");
                Destroy(this);
                break;
        }
    }

    void FindSoundtrackMenuAudio()
    {
        Soundtrack = FindObjectOfType<SoundtracksMenuAudio>();
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

    void FirstText()
    {
        if (NPCSubtitleLine.text.Length > 4)
        {
            AtualSpeech = NPCSubtitleLine.text.Substring(0, 4);
        }
    }

    void WaitToPlay()
    {
        if (NPCSubtitleLine.text.Length > 4)
        {
            AtualSpeech = NPCSubtitleLine.text.Substring(0, 4);
        }

        if (LastSpeech != AtualSpeech)
        {
            PlayWhenChange = true;
            LastSpeech = AtualSpeech;
        }
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

