using UnityEngine;
using System.Collections;

public class GC_AlunosNadando : MonoBehaviour {

    public GameObject Steven;
    public GameObject Brian;
    public GameObject Emily;
    public GameObject Kevin;

    private Animator StevenAnim;
    private Animator BrianAnim;
    private Animator EmilyAnim;
    private Animator KevinAnim;

    public bool Swim;

    // Use this for initialization
    void Start ()
    {
        StevenAnim = Steven.GetComponent<Animator>();
        BrianAnim = Brian.GetComponent<Animator>();
        EmilyAnim = Emily.GetComponent<Animator>();
        KevinAnim = Kevin.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Swim)
        {
            ChangeAnimationState(55);
        }
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Steven")
        {
            Swim = true;
        }
    }

    public void ChangeAnimationState(int value)
    {
        StevenAnim.SetInteger("AnimState", value);
        BrianAnim.SetInteger("AnimState", value);
        EmilyAnim.SetInteger("AnimState", value);
        KevinAnim.SetInteger("AnimState", value);
    }


}
