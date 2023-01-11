using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class ConversaAlunosAudio : MonoBehaviour {

    public ConversationTrigger ConversaAlunos;
    public GameObject NPCSubtitlePanel;
    public Text NPCSubtitleLine;
    Button ResponseButton;

    string AtualSpeech;
    string LastSpeech;

    bool IsClick = false;
    bool PlayWhenChange = false;
    bool AlreadyPlay = false;
    bool StartDialogue = false;

    //Identifying Audio
    int AudioSwitch = 0;
    string AudioToStop;

    // Update is called once per frame
    void Update () {

        if (ConversaAlunos == null)
        {
            if (NPCSubtitlePanel.activeSelf && AlreadyPlay == false)
            {
                AlreadyPlay = true;

                Invoke("FirstText", 0.2f);

                PlayAudio00();
            }

            if (StartDialogue == true)
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
                    PlayAudio01();
                }

            }
        }
    }

    void PlayAudio00()
    {
        StartDialogue = true;
        AudioToPlay("PamelaCustom_01", 2.0f);
    }

    void PlayAudio01()
    {
        switch (AudioSwitch)
        {
            case 0:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("DanCustom_01", 2.0f);
                break;
            case 1:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("BigBCustom_01", 1.0f);
                break;
            case 2:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KevinCustom_02", 2.0f);
                break;
            case 3:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("PamelaCustom_02", 3.0f);
                break;
            case 4:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KevinCustom_03", 2.0f);
                break;
            case 5:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("StevenCustom_03", 2.0f);
                break;
            case 6:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_03", 1.5f);
                break;
            case 7:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KevinCustom_01", 2.5f);
                break;
            case 8:
                AudioLength();
                Destroy(this);
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
            StartDialogue = true;
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
