using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickAudio : MonoBehaviour {

	EventSystem MenuIcons;
    bool IsPlayed = false;

    void Start()
    {
        MenuIcons = FindObjectOfType<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuIcons.currentSelectedGameObject && IsPlayed == false && Input.GetMouseButtonDown(0))
        {
            IsPlayed = true;
            AudioPlaying("Click");

            //Play just one time per trigger
            Invoke("WaitUntilPlay",0.1f);
        }

    }

    bool WaitUntilPlay()
    {
        IsPlayed = false;
        return IsPlayed;
    }

	void AudioPlaying(string playing)
	{
		AkSoundEngine.PostEvent(playing, gameObject);
	}
}
