using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControl5BG : MonoBehaviour {

	public GameObject QuartoCharlie;
	public GameObject Mudarfase5BG;
    public int LevelN;

    public GameObject IntroFade;
    public GameObject IntroText;
    private bool nada1 = true;

    public GameObject Player;
    private PlayerMovement PMov;

    // Use this for initialization
    void Start () {
        PMov = Player.GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {

        if (IntroFade.activeSelf == true)
        {
            PMov.enabled = false;
        }

        if (IntroFade.activeSelf == false && nada1)
        {
            PMov.enabled = true; IntroText.SetActive(true); nada1 = false; 
        }

    }
	public void Abrirporta (){
		QuartoCharlie.SetActive(true);
	}
	public void IrFase5B2(){
        StartCoroutine(WaitToChange());
    }

    private IEnumerator WaitToChange()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(LevelN);
    }

}
