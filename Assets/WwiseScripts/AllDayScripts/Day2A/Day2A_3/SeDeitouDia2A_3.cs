using UnityEngine;
using System.Collections;

public class SeDeitouDia2A_3 : MonoBehaviour {

    public GameObject CharlieEscreve;

    bool AlreadyPlayed = false;

	// Update is called once per frame
	void Update () {
        if (CharlieEscreve.activeSelf && AlreadyPlayed == false)
        {
            AlreadyPlayed = true;

            AudioPlaying("SeDeitou");

        }

        if (AlreadyPlayed == true)
        {
            Destroy(this, 0.5f);
        }
	}

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }
}
