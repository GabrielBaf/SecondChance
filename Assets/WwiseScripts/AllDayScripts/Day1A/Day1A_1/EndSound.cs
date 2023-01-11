using UnityEngine;
using System.Collections;

public class EndSound : MonoBehaviour
{
    public Animator PlayerWayAnim;
    public GameObject PlayerWay;

    int isMoving;
    bool isPlayed = false;

    // Update is called once per frame
    void Update()
    {
        if (PlayerWay.activeSelf && isPlayed == false)
        {
            Anima();

                if (isMoving == 11 || isMoving == 22 || isMoving == 33 || isMoving == 44)
                {
                    PlayingFootstep();
                }
        }
    }

    void Anima()
    {
        isMoving = PlayerWayAnim.GetInteger("AnimState");
    }

    void PlayingFootstep()
    {
        isPlayed = true;

        AudioPlaying("footstep");

        Invoke("IsPlaying", 0.3f);
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