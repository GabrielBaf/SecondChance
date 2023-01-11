using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KateFirstSpeechAudio : MonoBehaviour {

    public BoxCollider2D Kate;
    public CircleCollider2D Player;
    GameObject NPCSubtitlePanel;
    Text NPCSubtitleLine;
    Button ResponseButton;

    string AtualSpeech;
    string LastSpeech;

    bool IsClick = false;
    bool PlayWhenChange = false;
    bool IsPlaying = false;

    //Identifying Audio
    int AudioSwitch = 0;
    string AudioToStop;

    void Awake()
    {
        NPCSubtitleLine = GameObject.Find("NPC Subtitle Line").GetComponent<Text>();
        NPCSubtitlePanel = GameObject.Find("NPC Subtitle Panel");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.IsTouching(Kate) && NPCSubtitlePanel.activeSelf)
        {
            if (IsPlaying == false)
            {
                IsPlaying = true;

                Invoke("FirstText", 0.2f);

                KateFirstAudioPlay();

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

                Invoke("WaitToPlay", 0.2f);
            }

            if (PlayWhenChange == true)
            {
                PlayWhenChange = false;
                KateFirstAudioPlay();
            }

        }

        if (IsPlaying == true && NPCSubtitlePanel.activeSelf == false)
        {
            Destroy(this);
        }

    }

    void KateFirstAudioPlay()
    {
        switch (AudioSwitch)
        {
            case 0:
                AudioSwitch++;
                AudioToPlay("CharlieCustom_01", 1.5f);
                break;
            case 1:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KateCustom_01", 1.0f);
                break;
            case 2:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_02", 2.0f);
                break;
            case 3:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KateCustom_02", 2.5f);
                break;
            case 4:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_03", 2.0f);
                break;
            case 5:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KateCustom_03", 2.0f);
                break;
            case 6:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KateCustom_01", 1.0f);
                break;
            case 7:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KateCustom_03", 1.0f);
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
        if (NPCSubtitleLine.text.Length > 8)
        {
            AtualSpeech = NPCSubtitleLine.text.Substring(0, 8);
        }
    }

    void WaitToPlay()
    {
        if (NPCSubtitleLine.text.Length > 8)
        {
            AtualSpeech = NPCSubtitleLine.text.Substring(0, 8);
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
