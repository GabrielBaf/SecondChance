using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KateAudioDay2A_1 : MonoBehaviour {

    public CircleCollider2D Player;
    public BoxCollider2D Kate;

    public GameObject NPCSubtitlePanel;
    public Text NPCPortraitLine;

    string AtualSpeech;
    string LastSpeech;

    bool PlayWhenChange = false;
    bool CanProcess = true;

    bool IsPlaying = false;
    bool PlayFixedAudio = false;

    //Identifying Audio
    int AudioSwitch = 0;
    string AudioToStop;

	// Update is called once per frame
	void Update () {

        if (Player.gameObject.activeSelf)
        {
            if (Player.IsTouching(Kate) && NPCSubtitlePanel.activeSelf)
            {
                    IsPlaying = true;
            }
        }

        if (IsPlaying == true)
        {
            if (CanProcess)
            {
                CanProcess = false;
                WaitToPlayPart01();
            }

            if (PlayWhenChange == true)
            {
                PlayWhenChange = false;
                KateAudioPlay();
            }
        }

        if (NPCSubtitlePanel.activeSelf == false && IsPlaying == true)
        {
            AudioLength();
            PlayFixedAudio = true;
        }

        if (Player.IsTouching(Kate) && PlayFixedAudio && NPCSubtitlePanel.activeSelf)
        {
            PlayFixedAudio = false;
            AudioToPlay("KateCustom_03", 0.5f);
        }
    }

    void KateAudioPlay()
    {
        switch (AudioSwitch)
        {
            case 0:
                AudioSwitch++;
                AudioToPlay("CharlieCustom_02", 0.5f);
                break;
            case 1:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KateCustom_03", 0.5f);
                break;
            case 2:
                AudioSwitch++;
                AudioToPlay("CharlieCustom_02", 0.5f);
                break;
            case 3:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KateCustom_03", 0.5f);
                break;
            case 4:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_02", 1.0f);
                break;
            case 5:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KateCustom_01", 1.0f);
                break;
            case 6:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_01", 2.0f);
                break;
            case 7:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KateCustom_03", 2.0f);
                break;
            case 8:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_02", 0.6f);
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
