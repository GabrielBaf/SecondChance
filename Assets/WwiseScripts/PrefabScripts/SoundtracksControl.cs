using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SoundtracksControl : MonoBehaviour {

    public List<string> AllScenes;
    public List<GameObject> PrefabSoundtracks;

    bool DayIsChanged = true;
    int DayThatIsPlaying;
    int DayThatWasPlaying;

    private static SoundtracksControl SoundtracksControlRef;

    void Awake()
    {
        if (SoundtracksControlRef == null)
        {
            SoundtracksControlRef = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (SoundtracksControlRef != this)
            {
                DestroyImmediate(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update () {

        if (DayThatIsPlaying != DayThatWasPlaying)
        {
            DayIsChanged = true;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[0]) || SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[1]) || SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[2]))
        {
            DayThatIsPlaying = 0;

            if (DayIsChanged == true)
            {
                DayThatWasPlaying = DayThatIsPlaying;
                DayIsChanged = false;
                GameObject DaySoundtrack00 = Instantiate(PrefabSoundtracks[DayThatIsPlaying]);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[3]) || SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[4]) || SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[5]))
        {
            DayThatIsPlaying = 1;

            if (DayIsChanged == true)
            {
                Destroy(GameObject.Find("WwiseSoundtracksDia1(Clone)"), 2.0f);

                DayThatWasPlaying = DayThatIsPlaying;
                DayIsChanged = false;
                GameObject DaySoundtrack01 = Instantiate(PrefabSoundtracks[DayThatIsPlaying]);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[6]) || SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[7]) || SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[8]))
        {
            DayThatIsPlaying = 2;

            if (DayIsChanged == true)
            {
                Destroy(GameObject.Find("WwiseSoundtracksDia2(Clone)"), 2.0f);

                DayThatWasPlaying = DayThatIsPlaying;
                DayIsChanged = false;
                GameObject DaySoundtrack02 = Instantiate(PrefabSoundtracks[DayThatIsPlaying]);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[9]) || SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[10]) || SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[11]))
        {
            DayThatIsPlaying = 3;

            if (DayIsChanged == true)
            {
                Destroy(GameObject.Find("WwiseSoundtracksDia3(Clone)"), 2.0f);

                DayThatWasPlaying = DayThatIsPlaying;
                DayIsChanged = false;
                GameObject DaySoundtrack03 = Instantiate(PrefabSoundtracks[DayThatIsPlaying]);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[12]) || SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[13])
            || SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[14]))
        {
            DayThatIsPlaying = 4;

            if (DayIsChanged == true)
            {
                Destroy(GameObject.Find("WwiseSoundtracksDia4(Clone)"), 2.0f);

                DayThatWasPlaying = DayThatIsPlaying;
                DayIsChanged = false;
                GameObject DaySoundtrack04 = Instantiate(PrefabSoundtracks[DayThatIsPlaying]);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[15]))
        {
            DayThatIsPlaying = 5;

            if (DayIsChanged == true)
            {
                Destroy(GameObject.Find("WwiseSoundtracksDia5(Clone)"), 2.0f);

                DayThatWasPlaying = DayThatIsPlaying;
                DayIsChanged = false;
                GameObject DaySoundtrack05 = Instantiate(PrefabSoundtracks[DayThatIsPlaying]);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[16]))
        {
            DayThatIsPlaying = 0;

            if (DayIsChanged == true)
            {

                Destroy(GameObject.Find("WwiseSoundtracksDia6BadClone)"), 2.0f);

                DayThatWasPlaying = DayThatIsPlaying;
                DayIsChanged = false;
                GameObject DaySoundtrack06 = Instantiate(PrefabSoundtracks[DayThatIsPlaying]);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[17]))
        {
            DayThatIsPlaying = 1;

            if (DayIsChanged == true)
            {
                Destroy(GameObject.Find("WwiseSoundtracksDia1(Clone)"), 2.0f);

                DayThatWasPlaying = DayThatIsPlaying;
                DayIsChanged = false;
                GameObject DaySoundtrack07 = Instantiate(PrefabSoundtracks[DayThatIsPlaying]);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[18]))
        {
            DayThatIsPlaying = 2;

            if (DayIsChanged == true)
            {
                Destroy(GameObject.Find("WwiseSoundtracksDia2(Clone)"), 2.0f);

                DayThatWasPlaying = DayThatIsPlaying;
                DayIsChanged = false;
                GameObject DaySoundtrack08 = Instantiate(PrefabSoundtracks[DayThatIsPlaying]);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[19]) || SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[20]))
        {
            DayThatIsPlaying = 3;

            if (DayIsChanged == true)
            {
                Destroy(GameObject.Find("WwiseSoundtracksDia3(Clone)"), 2.0f);

                DayThatWasPlaying = DayThatIsPlaying;
                DayIsChanged = false;
                GameObject DaySoundtrack09 = Instantiate(PrefabSoundtracks[DayThatIsPlaying]);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[21]) || SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[22]))
        {
            DayThatIsPlaying = 4;

            if (DayIsChanged == true)
            {
                Destroy(GameObject.Find("WwiseSoundtracksDia4(Clone)"), 2.0f);

                DayThatWasPlaying = DayThatIsPlaying;
                DayIsChanged = false;
                GameObject DaySoundtrack10 = Instantiate(PrefabSoundtracks[DayThatIsPlaying]);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[23]))
        {
            DayThatIsPlaying = 6;

            if (DayIsChanged == true)
            {
                Destroy(GameObject.Find("WwiseSoundtracksDia5(Clone)"), 2.0f);

                DayThatWasPlaying = DayThatIsPlaying;
                DayIsChanged = false;
                GameObject DaySoundtrack11 = Instantiate(PrefabSoundtracks[DayThatIsPlaying]);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[24]))
        {
            DayThatIsPlaying = 7;

            if (DayIsChanged == true)
            {
                Destroy(GameObject.Find("WwiseSoundtracksDia5(Clone)"), 2.0f);

                DayThatWasPlaying = DayThatIsPlaying;
                DayIsChanged = false;
                GameObject DaySoundtrack12 = Instantiate(PrefabSoundtracks[DayThatIsPlaying]);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName(AllScenes[25]))
        {
            DayThatIsPlaying = 8;

            if (DayIsChanged == true)
            {
                if (GameObject.Find("WwiseSoundtracksDia1(Clone)") != null)
                {
                    GameObject.Find("WwiseSoundtracksDia1(Clone)").GetComponent<SoundtracksMenuAudio>().AudioStop("Dia1", 2);

                    Destroy(GameObject.Find("WwiseSoundtracksDia1(Clone)"), 2.0f);
                }

                if (GameObject.Find("WwiseSoundtracksDia2(Clone)") != null)
                {
                    GameObject.Find("WwiseSoundtracksDia2(Clone)").GetComponent<SoundtracksMenuAudio>().AudioStop("Dia2", 2);

                    Destroy(GameObject.Find("WwiseSoundtracksDia2(Clone)"), 2.0f);
                }

                if (GameObject.Find("WwiseSoundtracksDia3(Clone)") != null)
                {
                    GameObject.Find("WwiseSoundtracksDia3(Clone)").GetComponent<SoundtracksMenuAudio>().AudioStop("Dia3", 2);

                    Destroy(GameObject.Find("WwiseSoundtracksDia3(Clone)"), 2.0f);
                }

                if (GameObject.Find("WwiseSoundtracksDia4(Clone)") != null)
                {
                    GameObject.Find("WwiseSoundtracksDia4(Clone)").GetComponent<SoundtracksMenuAudio>().AudioStop("Dia4", 2);

                    Destroy(GameObject.Find("WwiseSoundtracksDia4(Clone)"), 2.0f);
                }

                if (GameObject.Find("WwiseSoundtracksDia5(Clone)") != null)
                {
                    GameObject.Find("WwiseSoundtracksDia5(Clone)").GetComponent<SoundtracksMenuAudio>().AudioStop("Dia5", 2);

                    Destroy(GameObject.Find("WwiseSoundtracksDia5(Clone)"), 2.0f);
                }

                if (GameObject.Find("WwiseSoundtracksDia6Bad(Clone)") != null)
                {
                    GameObject.Find("WwiseSoundtracksDia6Bad(Clone)").GetComponent<SoundtracksMenuAudio>().AudioStop("Dia6_Bad", 2);

                    Destroy(GameObject.Find("WwiseSoundtracksDia6Bad(Clone)"), 2.0f);
                }

                if (GameObject.Find("WwiseSoundtracksDia6Soso(Clone)") != null)
                {
                    GameObject.Find("WwiseSoundtracksDia6Soso(Clone)").GetComponent<SoundtracksMenuAudio>().AudioStop("Dia6_Soso", 2);

                    Destroy(GameObject.Find("WwiseSoundtracksDia6Soso(Clone)"), 2.0f);
                }

                if (GameObject.Find("WwiseSoundtracksDia6Good(Clone)") != null)
                {
                    GameObject.Find("WwiseSoundtracksDia6Good(Clone)").GetComponent<SoundtracksMenuAudio>().AudioStop("Dia6_Good", 2);

                    Destroy(GameObject.Find("WwiseSoundtracksDia6Good(Clone)"), 2.0f);
                }





                DayThatWasPlaying = DayThatIsPlaying;
                DayIsChanged = false;
                //GameObject DaySoundtrack12 = Instantiate(PrefabSoundtracks[DayThatIsPlaying]);
            }
        }
    }
}
