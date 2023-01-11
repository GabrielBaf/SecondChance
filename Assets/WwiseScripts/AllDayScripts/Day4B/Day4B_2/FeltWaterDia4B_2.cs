using UnityEngine;
using System.Collections;

public class FeltWaterDia4B_2 : MonoBehaviour {

    public GameObject CharlieSwim;

    bool AlreadyPlay = false;


	// Update is called once per frame
	void Update () {
        if (CharlieSwim.activeSelf && AlreadyPlay == false)
        {
            AlreadyPlay = true;
            AudioPlaying("FeltWater");
        }
    }
    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }
}
