using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class SecretariaFalouOuN_Audio : MonoBehaviour {

    public ConversationTrigger SecretariaFalou;
    public ConversationTrigger SecretariaNFalou;
    public GameObject NPCSubtitlePanel;
    public Text NPCSubtitleLine;
    Button ResponseButton;

    string AtualSpeech;
    string LastSpeech;

    bool IsClick = false;
    bool PlayWhenChange = false;
    bool IsPlayingFalou = false;
    bool IsPlayingNFalou = false;

    //Identifying Audio
    int AudioSwitch = 0;
    string AudioToStop;

    // Update is called once per frame
    void Update()
    {
        //Secretaria Falou

        if (NPCSubtitlePanel.activeSelf && SecretariaFalou == null)
        {
            if (IsPlayingFalou == false)
            {
                IsPlayingFalou = true;

                Invoke("FirstText", 0.1f);

                SecretariaFalouPlay();

            }
        }
        if (IsPlayingFalou == true)
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
                SecretariaFalouPlay();
            }
        }

        //Secretaria Não Falou

        if (NPCSubtitlePanel.activeSelf && SecretariaNFalou == null)
        {
            if (IsPlayingNFalou == false)
            {
                IsPlayingNFalou = true;

                Invoke("FirstText", 0.1f);

                SecretariaNFalouPlay();

            }
        }
        if (IsPlayingNFalou == true)
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
                SecretariaNFalouPlay();
            }
        }

        if (IsPlayingFalou || IsPlayingNFalou)
        {
            if (NPCSubtitlePanel.activeSelf == false)
            {
                AudioLength();
                Destroy(this);
            }
        }

    }

    void SecretariaFalouPlay()
    {
        switch (AudioSwitch)
        {
            case 0:
                AudioSwitch++;
                AudioToPlay("SecretariaCustom_01", 1.0f);
                break;
            case 1:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_01", 2.0f);
                break;
            case 2:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("SecretariaCustom_02", 2.0f);
                break;
            case 3:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_02", 3.0f);
                break;
            case 4:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("SecretariaCustom_03", 2.0f);
                break;
            case 5:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_03", 2.0f);
                break;
        }
    }

    void SecretariaNFalouPlay()
    {
        switch (AudioSwitch)
        {
            case 0:
                AudioSwitch++;
                AudioToPlay("SecretariaCustom_01", 1.0f);
                break;
            case 1:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_01", 2.0f);
                break;
            case 2:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("SecretariaCustom_02", 2.0f);
                break;
            case 3:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_02", 3.0f);
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
