using UnityEngine;
using System.Collections;

public class GC_Sad : MonoBehaviour {

    public GameObject DayIntro;
    public GameObject Player;
    private PlayerHere PHere;
	private PlayerMovement PMov;
	public GameObject Kate;
	private PlayerMovement KatePmov;

    public GameObject Fader;
    public GameObject CamCut;
    public GameObject CamRoom;
    public GameObject CamHall;
    public GameObject camJantar;

    public GameObject IntroText;
    public GameObject RoomSprite;
    public GameObject NConsegue;
    public GameObject GunRoom;
    public GameObject GunCharlie;
    public GameObject PegarFoto;
    public GameObject DoorEscada;
    public GameObject DoorCharlie;
    public GameObject Foto;

    public GameObject GrupoGun;
    public GameObject GrupoKatePlay;
    public GameObject Cameras1;
    public GameObject Cameras2;
    public GameObject Doors1;
    public GameObject Doors2;

    public GameObject VoltarParaQuarto;
    private PlayerHere VoltarParaQuartoPHere;

    private bool nada = true;

    // Use this for initialization
    void Start () {

        PHere = Player.GetComponent<PlayerHere>();
        VoltarParaQuartoPHere = VoltarParaQuarto.GetComponent<PlayerHere>();
		PMov = Player.GetComponent<PlayerMovement>();

		KatePmov = Kate.GetComponent<PlayerMovement>();

    }
	
	// Update is called once per frame
	void Update () {

        if (DayIntro.activeSelf)
        {
			PMov.enabled = false;
        }

        if (!DayIntro.activeSelf)
        {
            IntroText.SetActive(true);
        }

        if (VoltarParaQuartoPHere.PHere && Input.GetKey(KeyCode.Space) && nada)
        {
            Fader.SetActive(true);
            Player.SetActive(false);
            Kate.SetActive(true);
			KatePmov.enabled = false;
           // CamHall.SetActive(false);
           // camJantar.SetActive(true);

            Cameras1.SetActive(false);
            Cameras2.SetActive(true);
            Doors1.SetActive(false);
            Doors2.SetActive(true);

            GrupoGun.SetActive(false);
            GrupoKatePlay.SetActive(true);

            nada = false;
        }
	
	}

    public void GetUp()
    {
        CamCut.SetActive(false);
        CamRoom.SetActive(true);
    }


	public void GunQuartoSome(){
		GunRoom.SetActive(false);
	}

    public void GetGun()
    {
        NConsegue.SetActive(false);
        Fader.SetActive(true);
        RoomSprite.SetActive(true);
        PegarFoto.SetActive(true);

    }

    public void PegouFoto()
    {

        DoorEscada.SetActive(true);
        GunCharlie.SetActive(true);
    }

    public void ColocouFoto()
    {
        Foto.SetActive(true);
        VoltarParaQuarto.SetActive(true);
        DoorCharlie.SetActive(false);
    }

}
