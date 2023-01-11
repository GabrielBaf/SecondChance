using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{

    public class GC_Day2A_School1 : MonoBehaviour
    {

        public GameObject Player;
        private PlayerMovement PMov;

        public GameObject FadeCutscene;

        public bool test;
        public bool test2;
        public bool test3K; public bool test4K;
        private bool nada1 = true;
        private bool nada2 = true;

        public GameObject FalarBoy;
        private FalarcomBoy FalarBoyScript;

        public GameObject Andy;
        private Waypoint_2WPS AndyWP;
        private NPCFacePlayer KevinFace;

        public GameObject Kevin;
        public GameObject Brian;
        public GameObject Dan;
        private Waypoint_3WPS KevinWP;
        private Waypoint_2WPS BrianWP;
        private Waypoint_2WPS DanWP;

        public GameObject KevinfightCol;
        private FalarcomBoy KevinFightScript;

        public GameObject Lose;
        public GameObject WinKevin1;
        public GameObject WinKevin2;
        private FalarcomBoy WinKevin1_Script;
        private FalarcomBoy WinKevin2_Script;
        public GameObject ProfGaragem;
        public GameObject ChamarKevinFora;
        public GameObject ChamarKevinSala;
        private FalarcomBoy ChamarKevinFora_Script;
        private FalarcomBoy ChamarKevinSala_Script;
        public bool IsRunning;
        public bool WonKevin;

        public Vector2 KevinRecepcao;
        public Vector2 KevinFora;
        public Vector2 KevinSala;

        //sumircom objetos quando kevin corre atras de vc
        private SumirQuandoKevin SumirObjKevin;
        public GameObject ParedeWall;

        //cameras
        public GameObject OutCam;
        public GameObject OutBound;
        public GameObject HallCam;
        public GameObject HallBound;

        //triggers
        public GameObject KevinparaRecepcao;
        private PlayerHere KevinRecepcaoScript;

        //tutorial
        public GameObject TutorialKevin;
        public GameObject TitorialKevinBlack;

        /// audio ///

        //public AudioMixerSnapshot Normal;
        //public AudioMixerSnapshot Bully;
        //public AudioSource Source;

        //KevinLook
        public GameObject LookLeft_Hall;
        public GameObject LookLeft_Recep;
        public GameObject LookDown_Recep;

        private KevinLook LookLeft_HallSC;
        private KevinLook LookLeft_RecepSC;
        private KevinLook LookDown_RecepSC;

        //levelselector
        public int LevelN;


        // Use this for initialization
        void Start()
        {

            PMov = Player.GetComponent<PlayerMovement>();
            FalarBoyScript = FalarBoy.GetComponent<FalarcomBoy>();
            AndyWP = Andy.GetComponent<Waypoint_2WPS>();
            KevinFace = Kevin.GetComponent<NPCFacePlayer>();

            KevinWP = Kevin.GetComponent<Waypoint_3WPS>();
            BrianWP = Brian.GetComponent<Waypoint_2WPS>();
            DanWP = Dan.GetComponent<Waypoint_2WPS>();

            KevinFightScript = KevinfightCol.GetComponent<FalarcomBoy>();
            WinKevin1_Script = WinKevin1.GetComponent<FalarcomBoy>();
            WinKevin2_Script = WinKevin2.GetComponent<FalarcomBoy>();
            ChamarKevinFora_Script = ChamarKevinFora.GetComponent<FalarcomBoy>();
            ChamarKevinSala_Script = ChamarKevinSala.GetComponent<FalarcomBoy>();

            KevinRecepcaoScript = KevinparaRecepcao.GetComponent<PlayerHere>();

            SumirObjKevin = GetComponent<SumirQuandoKevin>();

            /// sound
            //Source = Source.GetComponent<AudioSource>();

            //kevin look
            LookLeft_HallSC = LookLeft_Hall.GetComponent<KevinLook>();
            LookLeft_RecepSC = LookLeft_Recep.GetComponent<KevinLook>();
            LookDown_RecepSC = LookDown_Recep.GetComponent<KevinLook>();


        }

        // Update is called once per frame
        void Update()
        {
            //tutorial impedir movimento

            if (TutorialKevin.activeSelf)
            {
                KevinWP.moveSpeed = 0f;
                PMov.speed = 0f;
            }
            else
            {
                KevinWP.moveSpeed = 1.5f;
                PMov.speed = 0.04f;
            }

            //


            if (test || FalarBoyScript.PlayerHere && nada1)
            {
                nada1 = false;
                FalarcomOBoy();
            }

            if (test2 || KevinFightScript.PlayerHere && nada2)
            {

                VemKevin();
            }

            if (WinKevin1_Script.PlayerHere || WinKevin2_Script.PlayerHere)
            {
                WinKevin1.SetActive(false);
                WinKevin2.SetActive(false);
                KevinWP.secondWPS = false; KevinFace.NPCIdlePosition = 1;
            }


            if (ChamarKevinFora_Script.PlayerHere || test3K)
            {
                Kevin.transform.position = KevinFora;
                KevinWP.moveSpeed = 1f;
                KevinWP.secondWPS = false; KevinWP.thirdWPs = true;
                ChamarKevinFora_Script.PlayerHere = false;
                ChamarKevinFora.SetActive(false);
                ChamarKevinSala.SetActive(false);
            }

            if (ChamarKevinSala_Script.PlayerHere || test4K)
            {
                Kevin.transform.position = KevinSala;
                KevinWP.secondWPS = false; KevinFace.NPCIdlePosition = 1;
                ChamarKevinFora_Script.PlayerHere = false;
                ChamarKevinFora.SetActive(false);
                ChamarKevinSala.SetActive(false);
            }


            //tentar faze kevi nolhar pro player enquanto persegue

            //if (KevinWP.secondWPS)
            //{
            //    KevinWP.left = true;
            //    KevinWP.right = false;
            //    KevinWP.up = false;
            //    KevinWP.down = false;
            //}
            //leva o kevin pra recepcao no trigger
            if (KevinRecepcaoScript.PHere)
            {
                Kevin.transform.position = KevinRecepcao;
                KevinWP.currentPoint2 = 1;
            }

            //kevin look
            if (LookLeft_HallSC.KevinHere || LookLeft_RecepSC.KevinHere)
            {
                KevinWP.OutsideControl = true;
                KevinWP.ChangeAnimationState(33);
            }

            else if (LookDown_RecepSC.KevinHere)
            {
                KevinWP.OutsideControl = true;
                KevinWP.ChangeAnimationState(44);

            }
            else
            {
                KevinWP.OutsideControl = false;
            }


        }

        public void FalarcomOBoy()
        {
            AndyWP.firstWPs = true;
            Destroy(FalarBoy);
        }

        public void AndyWalk()
        {
            AndyWP.firstWPs = false;
            AndyWP.secondWPS = true;
        }

        public void VemKevin()
        {
            KevinWP.enabled = true;
            KevinWP.firstWPs = true;
            BrianWP.firstWPs = true;
            DanWP.firstWPs = true;
            KevinWP.left = true;
            KevinWP.right = false;
            nada2 = false;
            
            //audio
            //Bully.TransitionTo(4);
        }

        public void EscapardoKevin()
        {
            StartCoroutine(KevinDelay());
            SumirObjKevin.SumircomTudo = true; //some com os objetos de fora
            TutorialKevin.SetActive(true); //ativa tutorial na tela
            TitorialKevinBlack.SetActive(true);
            ParedeWall.SetActive(true);
        }

        public void Losevoid()
        {
            Lose.SetActive(true);
            KevinparaRecepcao.SetActive(false); //desliga o trigger do kevin aparecer na recepcao, caso o jogador volte
        }

        public void Winvoid()
        {
            FadeCutscene.SetActive(true);
            //Normal.TransitionTo(3);
            //audio


            //trocar isso nas novas builds
            SceneManager.LoadScene(LevelN);
        }

        public void Save()
        {
            PlayerPrefs.SetString("MySavedGame", PersistentDataManager.GetSaveData());
            Debug.Log("Saved");
        }

        public void Load()
        {
            Lose.SetActive(false);
            KevinfightCol.SetActive(true);
            KevinWP.secondWPS = false;
           // KevinWP.enabled = false;
            nada2 = true;
            KevinWP.thirdWPs = false;
            KevinFightScript.PlayerHere = false;

            DanWP.currentPoint1 = 0;
            BrianWP.currentPoint1 = 0;
            KevinWP.currentPoint1 = 0;
            KevinWP.currentPoint2 = 0;
            KevinWP.currentPoint3 = 0;


            OutBound.SetActive(false);
            OutCam.SetActive(false);
            HallBound.SetActive(true);
            HallCam.SetActive(true);

            KevinparaRecepcao.SetActive(false); //desliga o trigger do kevin aparecer na recepcao, caso o jogador volte
            SumirObjKevin.SumircomTudo = false; ParedeWall.SetActive(false);//some com os objetos de fora 

            PersistentDataManager.ApplySaveData(PlayerPrefs.GetString("MySavedGame"), DatabaseResetOptions.KeepAllLoaded);

            //audio
            //Normal.TransitionTo(5);
        }

        //dar um delay pro kevin não vir correndo como um louco
        private IEnumerator KevinDelay()
        {
            yield return new WaitForSeconds(2f);
            KevinfightCol.SetActive(false);
            KevinWP.firstWPs = false;
            KevinWP.secondWPS = true;
            WinKevin1.SetActive(true);
            WinKevin2.SetActive(true); ProfGaragem.SetActive(false);

            ChamarKevinFora.SetActive(true);
            ChamarKevinSala.SetActive(true);
            KevinparaRecepcao.SetActive(true); // trigger pra fazer o kevin aparecer na recepcao
        }

        public IEnumerator VoltarMenu()
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(0);
        }

    }
}