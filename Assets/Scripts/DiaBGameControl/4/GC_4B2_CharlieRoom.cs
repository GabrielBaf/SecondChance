using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GC_4B2_CharlieRoom : MonoBehaviour {

    public GameObject Charlie;
    public GameObject CharliePijama;
    public GameObject CharlieEscreve;
    public GameObject Fader;
    public GameObject Livro;
    private PlayerHere PegouLivroPhere;
    
    public GameObject GuardaRoupa;
    private PlayerHere GuardaRoupaPhere;

    public GameObject MesaSemLivro;
    public GameObject Deitar;

    public bool PegouLivro;
    public bool SeTrocou;
    public int LevelN;

    // Use this for initialization
    void Start () {

        PegouLivroPhere = Livro.GetComponent<PlayerHere>();
        GuardaRoupaPhere = GuardaRoupa.GetComponent<PlayerHere>();

    }
	
	// Update is called once per frame
	void Update () {

        if (PegouLivroPhere.PHere && Input.GetKey(KeyCode.Space) && !PegouLivro)
        {
            MesaSemLivro.SetActive(true);
            PegouLivro = true;
        }

        if (GuardaRoupaPhere.PHere && Input.GetKey(KeyCode.Space) && !SeTrocou)
        {
            Fader.SetActive(true);
            Charlie.SetActive(false);
            CharliePijama.SetActive(true);
            SeTrocou = true;
        }

        if(SeTrocou && PegouLivro)
        {
            Deitar.SetActive(true);
        }

    }

    public void IrDeitar()
    {
        CharliePijama.SetActive(false);
        Charlie.SetActive(false);
        CharlieEscreve.SetActive(true);
    }

    public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(LevelN);
    }

}
