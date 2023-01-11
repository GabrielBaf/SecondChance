using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class BigBOutsideQuestAudio : MonoBehaviour {

    public GameObject BigB;
    CircleCollider2D[] BigBColliders;
    public GameObject Player;
    CircleCollider2D[] PlayerColliders;
    public GameObject NPCSubtitlePanel;
    public Text NPCPortraitLine;
    Button ResponseButton;

    string AtualSpeech;
    string LastSpeech;

    bool IsClick = false;
    bool PlayWhenChange = false;
    bool IsPlaying = false;
    bool CanProcess = true;

    //Changing Speech
    bool AlreadyTalked = false;

    //DestroyingPastAudio
    bool DestroyPastAudio = false;

    //Identifying Audio
    int AudioSwitch = 0;
    string AudioToStop;

    void Start()
    {
        BigBColliders = BigB.GetComponents<CircleCollider2D>();
        PlayerColliders = Player.GetComponents<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerColliders[1].IsTouching(BigBColliders[0]) && NPCSubtitlePanel.activeSelf)
        {
            if (IsPlaying == false)
            {
                IsPlaying = true;
                IsClick = false;

                FirstPortrait();

                BigBAudioPlay();

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
                BigBAudioPlay();
            }

        }

        if (IsPlaying == true && NPCSubtitlePanel.activeSelf == false)
        {
            AlreadyTalked = true;
            IsPlaying = false;
            AudioSwitch = 0;
        }

        if (AlreadyTalked == true && DestroyPastAudio == false)
        {
            DestroyPastAudio = true;
            Destroy(gameObject.GetComponent<JennaHallAudio>());
            Destroy(gameObject.GetComponent<StevenHallAudio>());
        }

    }

    void BigBAudioPlay()
    {
        if (AlreadyTalked == false)
        {
            switch (AudioSwitch)
            {
                case 0:
                    AudioSwitch++;
                    AudioToPlay("BigBCustom_01", 0.5f);
                    break;
                case 1:
                    AudioLength();
                    AudioSwitch++;
                    AudioToPlay("CharlieCustom_02", 0.5f);
                    break;
                case 2:
                    AudioLength();
                    AudioSwitch++;
                    AudioToPlay("BigBCustom_02", 1.5f);
                    break;
                case 3:
                    AudioLength();
                    AudioSwitch++;
                    AudioToPlay("CharlieCustom_03", 1.0f);
                    break;
                case 4:
                    AudioLength();
                    AudioSwitch++;
                    AudioToPlay("BigBCustom_03", 1.0f);
                    break;
                case 5:
                    AudioLength();
                    break;
            }
        }
        if (AlreadyTalked == true)
        {
            switch (AudioSwitch)
            {
                case 0:
                    AudioSwitch++;
                    AudioToPlay("BigBCustom_01", 0.5f);
                    break;
                case 1:
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

