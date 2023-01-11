using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class StephenAudioDia2A_2 : MonoBehaviour {

    public ConversationTrigger CharlieWin;
    public GameObject NPCSubtitlePanel;
    public Text NPCPortraitLine;
    Button ResponseButton;

    string AtualSpeech;
    string LastSpeech;

    bool IsClick = false;
    bool PlayWhenChange = false;
    bool IsPlaying = false;
    bool CanProcess = true;

    //RePlace The Soundtrack
    public bool StopAction = false;

    //Identifying Audio
    int AudioSwitch = 0;
    string AudioToStop;

    // Update is called once per frame
    void Update()
    {

        if (CharlieWin == null && NPCSubtitlePanel.activeSelf)
        {
            if (IsPlaying == false)
            {
                IsPlaying = true;
                IsClick = false;

                StopAction = true;

                FirstPortrait();

                StephenAudioPlay();

            }
        }

        if (IsPlaying == true)
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

                WaitToPlayPart01();
            }

            if (PlayWhenChange == true)
            {
                PlayWhenChange = false;
                StephenAudioPlay();
            }

        }

        if (IsPlaying == true && NPCSubtitlePanel.activeSelf == false)
        {
            AudioLength();
            Destroy(this);
        }

    }

    void StephenAudioPlay()
    {
        switch (AudioSwitch)
        {
            case 0:
                AudioSwitch++;
                AudioToPlay("StephenCustom_01", 0.5f);
                break;
            case 1:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_02", 0.5f);
                break;
            case 2:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KevinCustom_02", 1.5f);
                break;
            case 3:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("StephenCustom_03", 1.0f);
                break;
            case 4:
                AudioLength();
                AudioSwitch++;
                break;
            case 5:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KevinCustom_01", 1.0f);
                break;
            case 6:
                AudioLength();
                break;
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

    void FirstPortrait()
    {
        AtualSpeech = NPCPortraitLine.text;
    }

    void WaitToPlayPart01()
    {
        CanProcess = true;

        AtualSpeech = NPCPortraitLine.text;

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

    void AudioStoping(string playing, int fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 500, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }
}
