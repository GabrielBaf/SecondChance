using UnityEngine;
using System.Collections;

public class AudioDia6Bad : MonoBehaviour {

    public GameObject MovingFurniture;
    public GameObject GettingGun;
    public GameObject DroppingGun;
    public GameObject DroppingPicture;

    public GameObject Kate;
    public GameObject GettingPicture;
    public GameObject HallCam;

    bool Furniture = false;
    bool GetGun = false;
    bool DropGun = false;
    bool DropPicture = false;
    bool GetPicture = false;
    bool GunShot = false;

	// Update is called once per frame
	void Update () {

        if (MovingFurniture.activeSelf == false && Furniture == false)
        {
            Furniture = true;
            AudioPlaying("MovingFurniture");
        }

        if (GettingGun.activeSelf == false && GetGun == false)
        {
            GetGun = true;
            AudioPlaying("GettingGun");
        }

        if (DroppingGun.activeSelf && DropGun == false && GetGun == true)
        {
            DropGun = true;
            AudioPlaying("DroppingGun");
        }

        if (DroppingPicture.activeSelf && DropPicture == false)
        {
            DropPicture = true;
            AudioPlaying("DroppigPicture");
        }

        if (GettingPicture.activeSelf && GetPicture == false)
        {
            GetPicture = true;
            AudioPlaying("GettingPicture");
        }
        else if (GettingPicture.activeSelf == false)
        {
            GetPicture = false;
        }

        if (Kate.activeSelf && HallCam.activeSelf && GunShot == false)
        {
            GunShot = true;
            AudioPlaying("GunShot");
        }



	}

    void AudioPlaying(string playing)
    {
        AkSoundEngine.PostEvent(playing, gameObject);
    }
}
