using UnityEngine;
using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class SentouNoLugarDoKevinAudio : MonoBehaviour {

	public ConversationTrigger LugarDoKevin;
	public GameObject NPCSubtitlePanel;
	Button ResponseButton;

	bool PlaySpeech = true;
	bool PlayChair01 = false;
	bool PlayChair02 = false;
	bool PlayChair03 = false;
	bool AlreadyPlayed = false;

    //Identifying Audio
    bool AudioSwitch = false;
    string AudioToStop;

    // Update is called once per frame
    void Update () {

        //NaoSentouNoLugarDOKevin
        if (gameObject.GetComponent<EscolheuCadeira>().LugarKevin)
        {
            PlaySpeech = true;     //Fix the difference between this script and KevinEntrandoSala
            Destroy(this);
        }


        //SentouNoLugarDoKevin
        if (LugarDoKevin == null)
        {
            if (NPCSubtitlePanel.activeSelf && PlaySpeech == true)
            {
                AudioToPlay("KevinCustom_01", 0.5f);
                PlayChair01 = true;
                PlaySpeech = false;
            }


            if (PlayChair01 == true)
            {
                ResponseButton = FindObjectOfType<Button>();

                ResponseButton.onClick.AddListener(() => PlayChair02 = true);
            }

            if (PlayChair02 == true)
            {
                if (AlreadyPlayed == false)
                {
                    PlayCadeira();
                }

                if (ResponseButton != null)
                {
                    ResponseButton.onClick.AddListener(() => PlayChair03 = true);
                }

                PlayChair01 = false;
            }

            if (PlayChair03 == true)
            {
                Invoke("PlayCadeira", 0.7f);
                PlayChair02 = false;
                PlayChair03 = false;
            }

            if (PlayChair01 == false && PlayChair02 == false && PlayChair03 == false && PlaySpeech == false)
            {
                Destroy(this, 2.5f);
            }

        }
	}

	void PlayCadeira()
	{
        AlreadyPlayed = true;

        switch (AudioSwitch)
        {
            case false:
                AudioSwitch = true;
                AudioToPlay("CharlieCustom_03", 0.5f);
                break;
            case true:
                AudioToPlay("MudouDeCadeira", 2.0f);
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
