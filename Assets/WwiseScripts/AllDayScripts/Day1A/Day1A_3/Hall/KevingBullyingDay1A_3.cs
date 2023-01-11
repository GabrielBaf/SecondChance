using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class KevingBullyingDay1A_3 : MonoBehaviour {


    public GameObject KevinHall;
    public GameObject Hall_Cam;

    //Change soundtrack
    SoundtracksMenuAudio Soundtrack;

    public GameObject NPCSubtitlePanel;
    public Text NPCSubtitleLine;
    public Text NPCPortraitLine;
    Button ResponseButton;

    string AtualSpeech;
    string LastSpeech;

    bool IsClick = false;
    bool PlayWhenChange = false;

    //Playing Before Closet
    bool IsPlaying = false;
    bool CanProcess = true;

    //Play After Closet
    bool IsPlayingArmario = false;
    bool ContinuePlaying = false;

    //Different Noises
    int NoisesSwitch = 0;

    //Play At Home
    bool PlayAtHome = false;
    bool PlayLastAudio = false;
    public GameObject HallHouse_Cam;

    //DestroyAfterAll
    bool DestroyThisShit = false;

    //Identifying Audio
    int AudioSwitch = 0;
    string AudioToStop;

    void Start()
    {
        //finding soundtrack controller
        Invoke("FindSoundtrackMenuAudio", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

        if (KevinHall.activeSelf && Hall_Cam.activeSelf && NPCSubtitlePanel.activeSelf)
        {
            if (IsPlaying == false)
            {
                IsPlaying = true;
                IsClick = false;

                //Destroying all past Audio
                DestroyAllPastAudio();

                FirstPortrait();

                //changing soundtrack
                Soundtrack.AudioStop("Dia1", 3);
                AudioPlaying("Bullying");

                KevinBullyingAudioPlay();

            }
        }

        if (IsPlaying == true & IsPlayingArmario == false)
        {
            if (CanProcess)
            {
                CanProcess = false;
                WaitToPlayPart01();
            }

            if (PlayWhenChange == true)
            {
                PlayWhenChange = false;
                KevinBullyingAudioPlay();
            }
        }

        if (NPCSubtitlePanel.activeSelf && IsPlayingArmario == true && IsPlaying == true && ContinuePlaying == false)
        {
            ContinuePlaying = true;

            KevinBullyingAudioPlay();

            Invoke("FirstText", 0.1f);
        }

        if (ContinuePlaying == true)
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
                KevinBullyingAudioPlay();
            }

        }

        if (HallHouse_Cam.activeSelf)
        {
            if (PlayLastAudio == false && PlayAtHome == true)
            {
                PlayLastAudio = true;
                IsClick = false;

                //Destroying all past Audio
                DestroyAllPastAudio();

                FirstPortrait();

                KevinBullyingAudioPlay();

            }
        }

        if (PlayLastAudio == true)
        {
            if (CanProcess)
            {
                CanProcess = false;
                WaitToPlayPart01();
            }

            if (PlayWhenChange == true)
            {
                PlayWhenChange = false;
                KevinBullyingAudioPlay();
            }
        }

        if (DestroyThisShit == true && NPCSubtitlePanel.activeSelf == false)
        {
            Destroy(this);
        }

    }

    void FindSoundtrackMenuAudio()
    {
        Soundtrack = FindObjectOfType<SoundtracksMenuAudio>();
    }

    void KevinBullyingAudioPlay()
    {
        switch (AudioSwitch)
        {
            case 0:
                AudioSwitch++;
                break;
            case 1:
                AudioSwitch++;
                break;
            case 2:
                AudioSwitch++;
                AudioToPlay("KevinCustom_02", 0.5f);
                break;
            case 3:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_03", 0.5f);
                break;
            case 4:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KevinCustom_02", 1.0f);
                break;
            case 5:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_01", 1.0f);
                break;
            case 6:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KevinCustom_01", 2.0f);
                break;
            case 7:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_03", 2.0f);
                break;
            case 8:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KevinCustom_02", 0.6f);
                break;
            case 9:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_02", 0.4f);
                break;
            case 10:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KevinCustom_01", 0.5f);
                Invoke("DifferentNoises", 0.8f);
                break;
            case 11:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_03", 0.5f);
                break;
            case 12:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KevinCustom_03", 1.0f);
                break;
            case 13:
                //AfterCloset
                AudioLength();
                AudioSwitch++;
                Invoke("DifferentNoises", 0.5f);
                Invoke("DifferentNoises", 3.5f);
                Invoke("FirstSpeechAndy", 5.0f);
                break;
            case 14:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("AndyCustom_01", 0.5f);
                break;
            case 15:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_03", 1.0f);
                break;
            case 16:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("AndyCustom_02", 0.6f);
                break;
            case 17:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_02", 0.4f);
                break;
            case 18:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("AndyCustom_03", 2.0f);
                break;
            case 19:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_01", 0.6f);
                break;
            case 20:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("AndyCustom_02", 0.4f);
                break;
            case 21:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_03", 0.4f);
                break;
            case 22:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("AndyCustom_01", 0.4f);
                //ChangeToHome
                PlayAtHome = true;
                break;
            case 23:
                AudioSwitch++;
                break;
            case 24:
                AudioSwitch++;
                break;
            case 25:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KateCustom_03", 2.0f);
                break;
            case 26:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_01", 0.6f);
                break;
            case 27:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KateCustom_02", 0.4f);
                break;
            case 28:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("CharlieCustom_03", 0.4f);
                break;
            case 29:
                AudioLength();
                AudioSwitch++;
                AudioToPlay("KateCustom_01", 0.4f);

                //finish
                DestroyThisShit = true;
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

    void FirstPortrait()
    {
            AtualSpeech = NPCPortraitLine.text;
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

    bool FirstSpeechAndy()
    {
        IsPlayingArmario = true;
        return IsPlayingArmario;
    }

    //Different Noises
    void DifferentNoises()
    {
        switch (NoisesSwitch)
        {
            case 0:
                NoisesSwitch++;
                AudioToPlay("BateuCostasNoArmario", 0.5f);
                break;
            case 1:
                NoisesSwitch++;
                AudioToPlay("ArmarioFechando", 0.5f);
                break;
            case 2:
                AudioToPlay("CharlieGrito", 0.5f);
                break;
        }
    }

    void DestroyAllPastAudio()
    {
        Destroy(gameObject.GetComponent<DoorAudioDia1A_3>());
        Destroy(gameObject.GetComponent<InteractionAudio>());
        Destroy(gameObject.GetComponent<RonaldRecepçãoAudio>());

        if (gameObject.GetComponent<JackAudio>() != null)
        {
            Destroy(gameObject.GetComponent<JackAudio>());
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

