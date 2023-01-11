using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_SoSo : MonoBehaviour {

    public GameObject Player;
    private PlayerMovement PlayerMov;
    public GameObject DayIntro;
    public GameObject Kate;
    public GameObject Fader;
    public GameObject IntroText;

    public GameObject CamCut;
    public GameObject CamRoom;
    public GameObject CamHall;
    public GameObject CamKitchen;

    public GameObject Subir;
    public GameObject Katetalk;

    private bool nada = true;
    public int LevelN;

    // Use this for initialization
    void Start ()
    {
        PlayerMov = Player.GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (DayIntro.activeSelf)
        {
            PlayerMov.enabled = false;
        }

        if (!DayIntro.activeSelf && nada)
        {
            IntroText.SetActive(true);
            CamCut.SetActive(false);
            CamRoom.SetActive(true);
            nada = false;
        }

    }

    public void FalouMae()
    {
        Subir.SetActive(true);
    }

    public void irPraMae()
    {
        Fader.SetActive(true);
        CamHall.SetActive(false);
        CamKitchen.SetActive(true);
        Katetalk.SetActive(true);
    }

    public void FadeNextScene()
    {
        StartCoroutine(NExtScene());
    }

    private IEnumerator NExtScene()
    {
        Fader.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(LevelN);
    }

}
