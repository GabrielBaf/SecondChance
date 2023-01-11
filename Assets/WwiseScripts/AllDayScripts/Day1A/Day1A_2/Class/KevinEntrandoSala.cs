using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KevinEntrandoSala : MonoBehaviour {

    public GameObject NPCSubtitlePanel;
    Button ResponseButton;
    public Text NPCSubtitleLine;

    string AtualSpeech;
    string LastSpeech;

    bool IsClick = false;
    bool PlayWhenChange = false;
    bool AlreadyPlayed = false;
    int PlaySteven = 0;

    //Identifying Audio
    string AudioToStop;

    // Update is called once per frame
    void Update () {


        if (gameObject.GetComponent<EmilyFalouAudio>() == null)
        {


            if (NPCSubtitlePanel.activeSelf && AlreadyPlayed == false)
            {
                AlreadyPlayed = true;
                Invoke("FirstText", 0.2f);

                AudioToPlay("KevinCustom_02", 1.0f);
                PlaySteven = 1;
            }

            if (PlaySteven == 1)
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
                    AudioSteven();
                }
            }

            if (PlaySteven == 2)
            {
                ResponseButton.onClick.AddListener(() => PauseAndDestroy());
            }
        }
	}

    void AudioSteven()
    {
        PlaySteven = 2;
        AudioStoping("KevinCustom_02", 0);
        AudioToPlay("StevenCustom_01", 1.0f);
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

    void PauseAndDestroy()
    {
        AudioStoping("StevenCustom_01", 0);
        Destroy(this);
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
