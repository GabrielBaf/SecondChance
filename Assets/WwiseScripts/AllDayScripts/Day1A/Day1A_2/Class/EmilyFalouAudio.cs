using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using PixelCrushers.DialogueSystem;
using UnityEngine.UI;

public class EmilyFalouAudio : MonoBehaviour {

	public CircleCollider2D Emily;
	public BoxCollider2D EmilyFalou;
	public GameObject NPCSubtitlePanel;
    public GameObject PcSubtitlePanel;
	Button[] ResponseButtons;

	bool IsPlayed = false;
	bool PlayNow = false;

	// Update is called once per frame
	void Update () {

		if (Emily.IsTouching(EmilyFalou))
		{
			ResponseButtons = FindObjectsOfType<Button>();

			foreach (var responseButton in ResponseButtons)
			{

				if (responseButton.name == "Response Button Template(Clone)")
				{
					ResponseButtons[1].onClick.AddListener(() => PlayNow = true);
					ResponseButtons[0].onClick.AddListener(() => IsPlayed = true);
				}

				if (NPCSubtitlePanel.activeSelf && PlayNow == true && IsPlayed == false)
				{
					IsPlayed = true;
                    AudioToPlay("CharlieCustom_01", 0.3f);
				}

                if (IsPlayed == true)
                {
                    if (PcSubtitlePanel.activeSelf == false)
                    {
                        ResponseButtons[0].onClick.AddListener(() => PauseAndDestroy());
                    }
                }
			}
		}
	}

    void AudioToPlay(string AudioName, float ForSeconds)
    {
        AudioPlaying(AudioName);
        Invoke("AudioLength", ForSeconds);
    }

    void AudioLength()
    {
        AudioStoping("CharlieCustom_01", 1);
    }

    void PauseAndDestroy()
	{
		AudioStoping("CharlieCustom_01", 1);
		Destroy(this);
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
