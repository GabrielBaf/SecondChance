using UnityEngine;
using System.Collections;

public class IntroPlayerAudio : MonoBehaviour {

	bool StartIntro = false;
    public Animator PlayerIntroAnim;
    public GameObject PlayerIntro;

    int isMoving;
    bool isPlayed = false;

    // Update is called once per frame
    void Update()
    {
        if (PlayerIntro.activeSelf && isPlayed == false)
        {
            Invoke("Anima", 0.25f);

            if (isMoving == 11 || isMoving == 22 || isMoving == 33 || isMoving == 44)
            {
                PlayingFootstep();
            }
        }

        if (isMoving == 1)
        {
            Destroy(this);
        }
    }

    void Anima()
    {
        isMoving = PlayerIntroAnim.GetInteger("AnimState");
    }

    void PlayingFootstep()
    {
        isPlayed = true;

        AudioPlaying("footstep");

        Invoke("IsPlaying", 0.33f);
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
