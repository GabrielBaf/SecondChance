using UnityEngine;
using System.Collections;

public class ChangingClothesDay3A_2 : MonoBehaviour {

    public GameObject PlayerSunga;

	// Update is called once per frame
	void Update () {
        if (PlayerSunga.activeSelf)
        {
            AudioPlaying("SeTrocarPiscina");
            Destroy(this);
        }
	}

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }
}
