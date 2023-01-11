using UnityEngine;
using System.Collections;

public class PauseOnTutorial : MonoBehaviour {

    public GameObject TutorialIMG;
    public GameObject TutorialIMG2;
    public GameObject TutorialIMG3;
    public GameObject TutorialIMG4;

    public int HowManytutorials;


    private bool tutorialOnScreen;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (tutorialOnScreen)
        {
            tutorialOnScreen = false;
            Time.timeScale = 0;
		}

        if (Input.GetKey(KeyCode.Return))
        {
                TutorialIMG.SetActive(false);
                TutorialIMG2.SetActive(false);
                Time.timeScale = 1;
        }
				

        if (TutorialIMG.activeSelf == true)
        {
            tutorialOnScreen = true;
        }
	
	}
}
