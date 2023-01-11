using UnityEngine;
using System.Collections;

public class GC_Day1A_Diario : MonoBehaviour {

    public GameObject Player;
    public GameObject PlayerPijama;
    public GameObject PlayerEscreve;

    private PlayerMovement PlayerPijamaMov;

    public GameObject Fade;

    public GameObject DiarioIM;
    public GameObject MesasemdiarioIM;
    

    public GameObject CamDea;
    public GameObject CamAct;
    
    public bool Diario;
    public bool SeTrocou;

    private bool nada1 = true;

    // Use this for initialization
    void Start () {

        PlayerPijamaMov = PlayerPijama.GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {

        //if(PegouDiarioPH.PHere && Input.GetKey(KeyCode.Space))
        //{
        //    MesasemdiarioIM.SetActive(true);
        //    Diario = true;
        //}

        //if(SetrocouPH.PHere && Input.GetKey(KeyCode.Space) && nada1)
        //{
        //    Fade.SetActive(true);
        //    Setrocou.SetActive(false);
        //    Player.SetActive(false);
        //    PlayerPijama.SetActive(true);
        //    CamDea.SetActive(false);
        //    CamAct.SetActive(true);
        //    SeTrocou = true;
        //    nada1 = false;
        //}
        //if(Diario && SeTrocou)
        //{
        //    VaiDormir.SetActive(true);
            
        //}
	
	}

    public void AndaDeNovo()
    {
        PlayerPijamaMov.enabled = true;
    }

    public void PegaDiario()
    {
        MesasemdiarioIM.SetActive(true);
        Diario = true;
    }

    public void SeTroca()
    {
        Fade.SetActive(true);
        Player.SetActive(false);
        PlayerPijama.SetActive(true);
        CamDea.SetActive(false);
        CamAct.SetActive(true);
        SeTrocou = true;
        nada1 = false;
    }

    public void IrDormir()
    {
        DiarioIM.SetActive(true);
        PlayerPijama.SetActive(false);
        PlayerEscreve.SetActive(true);
    }

}
