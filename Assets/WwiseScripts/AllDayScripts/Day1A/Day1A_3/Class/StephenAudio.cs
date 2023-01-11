using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StephenAudio : MonoBehaviour {

    public GameObject Stephen;
    CircleCollider2D[] StephenColliders;
    public GameObject Player;
    CircleCollider2D[] PlayerColliders;
    public GameObject NPCSubtitlePanel;
    public Text NPCSubtitleLine;
    Button ResponseButton;

    string AtualSpeech;
    string LastSpeech;

    bool IsClick = false;
    bool PlayWhenChange = false;
    bool IsPlaying = false;

    //Identifying Audio
    int AudioSwitch = 0;
    string AudioToStop;

    void Start()
    {
        StephenColliders = Stephen.GetComponents<CircleCollider2D>();
        PlayerColliders = Player.GetComponents<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerColliders[1].IsTouching(StephenColliders[0]) && NPCSubtitlePanel.activeSelf)
        {
            if (IsPlaying == false)
            {
                IsPlaying = true;
                IsClick = false;

                Invoke("FirstText", 0.1f);

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

                Invoke("WaitToPlay", 0.1f);
            }

            if (PlayWhenChange == true)
            {
                PlayWhenChange = false;
                StephenAudioPlay();
            }

        }

        if (IsPlaying == true && NPCSubtitlePanel.activeSelf == false)
        {
            IsPlaying = false;
            AudioSwitch = 0;
        }

    }

    void StephenAudioPlay()
    {
        if (gameObject.GetComponent<DanEKevinAudio>().TryToTalk == true)
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
                    AudioToPlay("CharlieCustom_01", 0.5f);
                    break;
                case 2:
                    AudioLength();
                    AudioSwitch++;
                    AudioToPlay("StephenCustom_02", 1.5f);
                    break;
                case 3:
                    AudioLength();
                    AudioSwitch++;
                    AudioToPlay("CharlieCustom_03", 1.0f);
                    break;
                case 4:
                    AudioLength();
                    AudioSwitch++;
                    AudioToPlay("StephenCustom_03", 2.0f);
                    break;
                case 5:
                    AudioLength();
                    AudioSwitch++;
                    AudioToPlay("CharlieCustom_02", 1.0f);
                    break;
                case 6:
                    AudioLength();
                    AudioSwitch++;
                    AudioToPlay("StephenCustom_01", 2.0f);
                    break;
                case 7:
                    AudioLength();
                    break;
            }
        }
        else
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
                    AudioToPlay("CharlieCustom_01", 0.5f);
                    break;
                case 2:
                    AudioLength();
                    AudioSwitch++;
                    AudioToPlay("StephenCustom_02", 1.5f);
                    break;
                case 3:
                    AudioLength();
                    AudioSwitch++;
                    AudioToPlay("CharlieCustom_03", 1.0f);
                    break;
                case 4:
                    AudioLength();
                    AudioSwitch++;
                    AudioToPlay("StephenCustom_03", 2.0f);
                    break;
                case 5:
                    AudioLength();
                    break;
            }
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