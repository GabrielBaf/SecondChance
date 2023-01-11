using UnityEngine;
using System.Collections;

public class NPCFacePlayer_Inverse : MonoBehaviour {

    private Animator animator;
    public bool PlayerInteraction;
    public bool PlayerHere;

    public float Diference;

    public float npcXpos;
    public float npcYpos;
    public float PlayerXpos;
    public float PlayerYpos;
    public Transform Player;

    public int NPCIdlePosition;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

        npcXpos = 0f;
        npcYpos = 0f;
        PlayerXpos = 0f;
        PlayerYpos = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        npcXpos = transform.position.x;
        npcYpos = transform.position.y;



        if (PlayerHere)
        {
            Diference = PlayerYpos - npcYpos;
            PlayerXpos = Player.transform.position.x;
            PlayerYpos = Player.transform.position.y;
        }
        else
        {
            Diference = 0;
            PlayerXpos = 0;
            PlayerYpos = 0;
        }


        if (PlayerHere && Input.GetKey(KeyCode.Space))
        {
            PlayerInteraction = true;
        }

        if (!PlayerHere)
        {
            PlayerInteraction = false;
        }

        if (PlayerInteraction)
        {

            if (Diference > 0.4f && PlayerYpos > npcYpos)
            {
                ChangeAnimationState(4); //up
            }
            if (Diference < -0.4f && PlayerYpos < npcYpos)
            {
                ChangeAnimationState(1); //down
            }
            if (Diference >= 0f && PlayerXpos > npcXpos)
            {
                ChangeAnimationState(3); //right
            }
            if (Diference <= 0f && PlayerXpos < npcXpos)
            {
                ChangeAnimationState(2); //left
            }
        }

        if (!PlayerInteraction)
        {
            if (NPCIdlePosition == 1)
            {
                ChangeAnimationState(1);
            }
            if (NPCIdlePosition == 2)
            {
                ChangeAnimationState(2);
            }
            if (NPCIdlePosition == 3)
            {
                ChangeAnimationState(3);
            }
            if (NPCIdlePosition == 4)
            {
                ChangeAnimationState(4);
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
