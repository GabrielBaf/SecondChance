using UnityEngine;
using System.Collections;

public class KissAudioDia4A_2 : MonoBehaviour {

    public GameObject AndyCut;
    public GameObject CharlieCut;
    float KissPosition = 1.8f;
    float CharliePos;

    bool AlreadyPlay = false;
    bool AlreadyPlay2 = false;

	// Update is called once per frame
	void Update () {
        if (AndyCut.transform.localPosition.x > KissPosition && AlreadyPlay == false)
        {
            AlreadyPlay = true;
            AudioPlaying("KissSound");

            CharliePos = CharlieCut.transform.localPosition.x;
        }

        if (AlreadyPlay)
        {
            if (CharliePos != CharlieCut.transform.localPosition.x && AlreadyPlay2 == false)
            {
                AlreadyPlay2 = true;
            }
        }

        if (AlreadyPlay2)
        {
            if (CharliePos + 0.001f > CharlieCut.transform.localPosition.x && AlreadyPlay2 == true)
            {
                AlreadyPlay2 = false;
                AudioPlaying("KissSound");
                Destroy(this);
            }
        }


	}

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }
}
