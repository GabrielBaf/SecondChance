using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class StephenProfPrimeiraFalaAudio : MonoBehaviour {

    public ConversationTrigger StephenPrimeiraFala;
    public GameObject NPCSubtitlePanel;
    public Text NPCSubtitleLine;
    Button ResponseButton;

    string AtualSpeech;
    string LastSpeech;

    bool IsClick = false;
    bool PlayWhenChange = false;

    bool Isplaying = false;
    bool ContinueSpeech = false;

    //Identifying Audio
    int AudioSwitch = 0;
    string AudioToStop;

    // Update is called once per frame
    void Update () {

        if (StephenPrimeiraFala == null && NPCSubtitlePanel.activeSelf && Isplaying == false)
        {
            Isplaying = true;

            Invoke("FirstText", 0.1f);

            AudioToPlay("StephenCustom_01", 1.5f);

            ContinueSpeech = true;

        }

        if (ContinueSpeech)
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

                Invoke("WaitToPlay", 0.2f);
            }

            if (PlayWhenChange == true)
            {
                PlayWhenChange = false;
                PlayStephen();
            }

        }

        if (NPCSubtitlePanel.activeSelf == false && Isplaying == true)
        {
            AudioStoping("StephenCustom_03", 1);
            Destroy(this, 1.0f);
        }

	}

    void PlayStephen()
    {
        switch (AudioSwitch)
        {
            case 0:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("StephenCustom_02", 2.0f);
                break;
            case 1:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("StephenCustom_03", 1.5f);
                break;
            case 2:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("StephenCustom_01", 1.0f);
                break;
            case 3:
                AudioLength();
                Destroy(this, 1.0f);
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

    void AudioStoping(string playing, int fadeout)
    {
        uint eventID;
        eventID = AkSoundEngine.GetIDFromString(playing);
        AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, gameObject, fadeout * 500, AkCurveInterpolation.AkCurveInterpolation_Sine);
    }
}
