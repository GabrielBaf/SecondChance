using UnityEngine;
using System.Collections;

public class StevenSwimAudioDia3B : MonoBehaviour {

    public GameObject PlayerCut;
    public GameObject ResponsePanel;
    public GameObject NPCSubtitlePanel;

    bool isPlayed;
    bool PlayNow = false;
    bool StopAudio = false;



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

        if (ResponsePanel.activeSelf == true && PlayNow == false)
        {
            PlayNow = true;
            AudioPlaying("FeltWater");
        }

        if (PlayNow && PlayerCut.activeSelf && isPlayed == false && ResponsePanel.activeSelf == false)
        {
            PlayingFootstep();


            if (NPCSubtitlePanel.activeSelf == false)
            {
                StopAudio = true;
            }
        }

        if (NPCSubtitlePanel.activeSelf && StopAudio)
        {
            Destroy(this);
        }
	}

    void PlayingFootstep()
    {
        isPlayed = true;


        AudioPlaying("SwimAudio");

        Invoke("IsPlaying", 0.5f);
    }

    bool IsPlaying()
    {
        isPlayed = false;
        return isPlayed;
    }

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }
}
