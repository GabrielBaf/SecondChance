using UnityEngine;
using System.Collections;

public class NPCFacePlayer_Walker : MonoBehaviour {
    private Animator animator;
    public bool PlayerInteraction;
    public bool PlayerHere;

    public float Diference;

    public float npcXpos;
    public float npcYpos;
    public float PlayerXpos;
    public float PlayerYpos;
    public Transform Player;
    

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

        npcXpos = 0f;
        npcYpos = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        npcXpos = transform.position.x;
        npcYpos = transform.position.y;

        PlayerXpos = Player.transform.position.x;
        PlayerYpos = Player.transform.position.y;

        Diference = PlayerYpos - npcYpos;

        if (PlayerHere && Input.GetKey(KeyCode.Space))
        {
            PlayerInteraction = true;
        }

        if (!PlayerHere)
        {
            PlayerInteraction = false;
            Diference = 0;
        }

        if (PlayerInteraction)
        {

            if (Diference > 0.4f && PlayerYpos > npcYpos)
            {
                ChangeAnimationState(1); //up
            }
            if (Diference < -0.4f && PlayerYpos < npcYpos)
            {
                ChangeAnimationState(4); //down
            }
            if (Diference >= 0f && PlayerXpos > npcXpos)
            {
                ChangeAnimationState(2); //right
            }
            if (Diference <= 0f && PlayerXpos < npcXpos)
            {
                ChangeAnimationState(3); //left
            }
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHere = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHere = false;
        }
    }

    public void ChangeAnimationState(int value)
    {
        animator.SetInteger("AnimState", value);
    }

}
