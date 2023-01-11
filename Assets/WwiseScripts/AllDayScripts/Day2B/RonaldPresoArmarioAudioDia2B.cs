using UnityEngine;
using System.Collections;

public class RonaldPresoArmarioAudioDia2B : MonoBehaviour {

    public GameObject Ronald;

    bool AlreadyPlay = false;

	// Update is called once per frame
	void Update () {
        if (Ronald.activeSelf && AlreadyPlay == false)
        {
            AlreadyPlay = true;

            AudioPlaying("ArmarioFechando");

            Destroy(this);
        }
	}

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }
}
