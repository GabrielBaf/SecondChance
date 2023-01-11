using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EscolheuCadeira : MonoBehaviour {

    public CharlieSit Player;
    bool IsPlayed = false;

    //Colaborate with SentouNoLugarDOKevin
    public bool LugarKevin;

    void Update () {

        if (Player.BigB || Player.Kevin || Player.Dan || Player.Charlie || Player.Emily || Player.Jenna || Player.pamela || Player.Steven)
        {
            if (IsPlayed == false)
            {
                AudioPlaying("Cadeira");

                //Send to SentouNoLugarDOKevin
                NaoSentouKevin();

                IsPlayed = true;
            }

        }

        //Destroy with SentouNoLugarDOKevin
        if (gameObject.GetComponent<SentouNoLugarDoKevinAudio>() == null)
        {
            Destroy(this);
        }
	}

    public bool NaoSentouKevin()
    {
        if (Player.Kevin == false)
        {
            LugarKevin = true;
        }

        return LugarKevin;
    }

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);

    }
}
