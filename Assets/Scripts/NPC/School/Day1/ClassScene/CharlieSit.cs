using UnityEngine;
using System.Collections;

public class CharlieSit : MonoBehaviour {

    public bool BigB;
    public bool Kevin;
    public bool Dan;
    public bool Charlie;
    public bool Emily;
    public bool Jenna;
    public bool pamela;
    public bool Steven;

    private PlayerMovement pmovement;

    public GameObject playertrans;
    private Animator animator;
    public Camera ClassCam;
    public GameObject Camera;
    public GameObject CutClassCam;

    public GameObject GameController;
    private GC_School1 GC_School;

    public GameObject[] chairSelectors;
    public GameObject LugardoKevinText;
    private bool nada1 = true;
    
    // Use this for initialization
    void Start () {

        pmovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        GC_School = GameController.GetComponent<GC_School1>();
        
    }
	
	// Update is called once per frame
	void Update () {

        
            if (Charlie)
            {
                Vector2 PPosition = new Vector2(6.39f, 4.96f);
                pmovement.enabled = false;
			pmovement.speed = 0;
                playertrans.transform.position = PPosition;
                ChangeAnimationState(1);
            }
            if (BigB)
            {
                Vector2 PPosition = new Vector2(10.41f, 5.04f);
                pmovement.enabled = false;

			pmovement.speed = 0;
                playertrans.transform.position = PPosition;
                ChangeAnimationState(1);
            }
            if (Kevin)
            {
                Vector2 PPosition = new Vector2(8.41f, 4.97f);
			pmovement.enabled = false;
			pmovement.speed = 0;
                playertrans.transform.position = PPosition;
                ChangeAnimationState(1);
                LugardoKevinText.SetActive(true);
            }
            if (Dan)
            {
                Vector2 PPosition = new Vector2(12.39f, 5.04f);
			pmovement.enabled = false;
			pmovement.speed = 0;
                playertrans.transform.position = PPosition;
                ChangeAnimationState(1);
            }
            if (Emily)
            {
                Vector2 PPosition = new Vector2(6.39f, 7.02f);
			pmovement.enabled = false;
			pmovement.speed = 0;
                playertrans.transform.position = PPosition;
                ChangeAnimationState(1);
            }
            if (Jenna)
            {
                Vector2 PPosition = new Vector2(8.4f, 7.02f);
			pmovement.enabled = false;
			pmovement.speed = 0;
                playertrans.transform.position = PPosition;
                ChangeAnimationState(1);
            }
            if (pamela)
            {
                Vector2 PPosition = new Vector2(10.39f, 7.02f);
			pmovement.enabled = false;
			pmovement.speed = 0;
                playertrans.transform.position = PPosition;
                ChangeAnimationState(1);
            }
            if (Steven)
            {
                Vector2 PPosition = new Vector2(12.4f, 7.02f);
			pmovement.enabled = false;
			pmovement.speed = 0;
                playertrans.transform.position = PPosition;
                ChangeAnimationState(1);
            }

        

    }

    public void BigBsit()
    {
        BigB = true;
        DeactivateSelectors();
    }
    public void KevinSit()
    {
        Kevin = true;
        DeactivateSelectors();
    }
    public void DanSit()
    {
        Dan = true;
        DeactivateSelectors();
    }
    public void Charliesit()
    {
        Charlie = true;
        DeactivateSelectors();
    }
    public void EmilySit()
    {
        Emily = true;
        DeactivateSelectors();
    }
    public void JennaSit()
    {
        Jenna = true;
        DeactivateSelectors();
    }
    public void PamelaSit()
    {
        pamela = true;
        DeactivateSelectors();
    }
    public void StevenSit()
    {
        Steven = true;
        DeactivateSelectors();
    }

    public void ChangeAnimationState(int value)
    {
        animator.SetInteger("AnimState", value);
    }

    IEnumerator StartStudents()
    {
        yield return new WaitForSeconds(2);


        Vector3 CamPosition = new Vector3 (9.81f, 8.83f, -8.046875f);

        nada1 = false;
        yield return new WaitForSeconds(2);
        Camera.SetActive(false);
        CutClassCam.SetActive(true);
        GC_School.EmilyEntra = true;
    }

    void DeactivateSelectors()
    {
        foreach (GameObject obj in chairSelectors)
        {
            obj.active = false;
        }
        StartCoroutine(StartStudents());
    }

}
