using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_Dia5A_IntroHome : MonoBehaviour {

    //intro
    public GameObject IntroDay;
    public GameObject IntroText;
    //players
    public GameObject PlayerPijama;
    public GameObject Player;

    private PlayerMovement PPijamaPMov;
    private PlayerMovement PMov;

    //faders
    public GameObject Fader;
    public GameObject FadeTrocar;
    public GameObject FadeIn;

    //portas
    public GameObject DoorCharlieRoom;

    //triggers
    public GameObject Lanche_Empty;
    public int LevelN;

    // Use this for initialization
    void Start () {

        PPijamaPMov = PlayerPijama.GetComponent<PlayerMovement>();
        PMov = Player.GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {

        if (IntroDay.activeSelf) { PPijamaPMov.enabled = false; }
        if(!IntroDay.activeSelf) { IntroText.SetActive(true); }
	
	}

    public void SuitUP()
    {
        FadeTrocar.SetActive(true);  PlayerPijama.SetActive(false);   Player.SetActive(true); DoorCharlieRoom.SetActive(true);
    }

    public IEnumerator Banheiro()
    {
        FadeTrocar.SetActive(true);
        PMov.enabled = false;
        yield return new WaitForSeconds(2);
        PMov.enabled = true;
    }

    public void ComeuLanche()
    {
        Lanche_Empty.SetActive(true);
    }

    public IEnumerator NextScene()
    {
        FadeIn.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(LevelN);
    }

}
