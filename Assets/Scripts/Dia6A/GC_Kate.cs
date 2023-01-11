using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_Kate : MonoBehaviour {

    public GameObject Fader;

    public GameObject Kate;
    private PlayerMovement KatePmov;
    public GameObject Foto;
    private PlayerHere FotoPHere;

    public GameObject QuartoCharlie;
    private PlayerHere QuartoPhere;

    public GameObject PicSprite1;
    public GameObject PicSprite2;

    public GameObject DoorJantar;

	public GameObject FadeInn;

    public bool Sprite1Act;
    public int LevelN;

	private bool nada = false;

    // Use this for initialization
    void Start () {

        QuartoPhere = QuartoCharlie.GetComponent<PlayerHere>();
        FotoPHere = Foto.GetComponent<PlayerHere>();
        KatePmov = Kate.GetComponent<PlayerMovement>();


    }
	
	// Update is called once per frame
	void Update () {

        if (FotoPHere.PHere && Input.GetKey(KeyCode.Space))
        {
			PicSprite1.SetActive(true); PicSprite2.SetActive(true); 
			Sprite1Act = true;
        }

		if(PicSprite1.activeSelf && Input.GetKey(KeyCode.Return))
        {
            PicSprite1.SetActive(false); 
			StartCoroutine(TimeToNada());
        }

		if(PicSprite2.activeSelf && Input.GetKey(KeyCode.Return) && nada)
		{
			PicSprite2.SetActive(false); 
			Sprite1Act = false;
		}
			

        if (Sprite1Act)
        {
            KatePmov.enabled = false;

        }
        else
        {
			KatePmov.enabled = true;
			PicSprite1.SetActive(false);
			PicSprite2.SetActive(false);
        }
        
	
	}

	private IEnumerator TimeToNada()
	{
		yield return new WaitForSeconds(2f);
		nada = true;
	}

    public void FadeNextScene()
    {
        StartCoroutine(NExtScene());
    }

    public void EntrarNoQuarto()
    {
        Kate.SetActive(false);
    }

    private IEnumerator NExtScene()
    {
		FadeInn.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(LevelN);
    }

}

