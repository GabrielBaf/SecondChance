using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_Day3A_InicioCasa : MonoBehaviour {

    public int LevelN;
    public GameObject IntroFade;
    public GameObject Player;
    public GameObject PlayerPijama;
    public GameObject IntroText;
    public GameObject Fade;
	public GameObject FadeInn;

    private PlayerMovement Pmov;
    private bool nada1 = true;
    // Use this for initialization
    void Start () {

        Pmov = Player.GetComponent<PlayerMovement>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (IntroFade.activeSelf == true)
        {
            Pmov.enabled = false;
        }

        if(IntroFade.activeSelf == false && nada1)
        {
            IntroText.SetActive(true); Pmov.enabled = true; nada1 = false;
        }

        
	}

    public void SeTrocou()
    {
        Fade.SetActive(true);
        Player.SetActive(true);
        PlayerPijama.SetActive(false);
    }

	public IEnumerator NextLevel()
    {
		FadeInn.SetActive(true);
		yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(LevelN);
    }

}
