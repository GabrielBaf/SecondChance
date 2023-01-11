using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DanEKevinAudio : MonoBehaviour {

    //Fix bug collider
    public BoxCollider2D EmilyEvent;

    public CircleCollider2D Dan;
    public GameObject Player;
    CircleCollider2D[] PlayerCollider;
    public GameObject NPCSubtitlePanel;
    public Text NPCSubtitleLine;
    Button ResponseButton;

    string AtualSpeech;
    string LastSpeech;

    bool IsClick = false;
    bool PlayWhenChange = false;
    bool IsPlaying = false;
    //emilyFix
    bool EmilyAlreadyTalked = true;
    bool fixingEmily = false;
    //Stephen fix
    public bool TryToTalk = false;

    //Identifying Audio
    int AudioSwitch = 0;
    string AudioToStop;

    void Start()
    {
        PlayerCollider = Player.GetComponents<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Fixing Bug
        if (PlayerCollider[1].IsTouching(EmilyEvent) && fixingEmily == false)
        {
            fixingEmily = true;
            AudioLength();
            EmilyAlreadyTalked = false;
        }
        if (EmilyAlreadyTalked == false)
        {
            Invoke("FixingEmily", 0.5f);
        }


        if (PlayerCollider[1].IsTouching(Dan) && NPCSubtitlePanel.activeSelf && EmilyAlreadyTalked == true)
        {
            if (IsPlaying == false)
            {
                TryToTalk = true;
                IsClick = false;
                IsPlaying = true;

                Invoke("FirstText", 0.1f);

                DanTalkKevinAudioPlay();

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
                DanTalkKevinAudioPlay();
            }

        }

        if (IsPlaying == true && NPCSubtitlePanel.activeSelf == false)
        {
            //Destroy(this);
            IsPlaying = false;
            AudioSwitch = 0;
        }

    }

    void DanTalkKevinAudioPlay()
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
                AudioToPlay("DanCustom_01", 1.0f);
                break;
            case 2:
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

    void FixingEmily()
    {
        if (NPCSubtitlePanel.activeSelf == false)
        {
            EmilyAlreadyTalked = true;
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