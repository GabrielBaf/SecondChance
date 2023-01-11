using UnityEngine;
using System.Collections;

public class DepthLayerOrder_ClassChair : MonoBehaviour {


    public float dif;
    public int acima = 0;
    public int abaixo = 0;
    private SpriteRenderer sprite;
    private SpriteRenderer chairsprite;
    public bool isTrigger;
    public bool NPCcollide;


    public float npcYpos;
    public float PlayerYpos;

    public GameObject Player;
    public GameObject Chair;



    void Start()
    {
        sprite = Player.GetComponent<SpriteRenderer>();
        chairsprite = Chair.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        dif = PlayerYpos - npcYpos;

        if (sprite)
            //  sprite.sortingOrder = cima;
            //  sprite.sortingOrder = abaixo;

            if (isTrigger)
            {
                npcYpos = gameObject.transform.position.y;
                PlayerYpos = Player.transform.position.y;

                if (npcYpos < PlayerYpos)
                {
                    sprite.sortingOrder = abaixo;
                }
                if (dif < 0.4)
                {
                    sprite.sortingOrder = acima;
                    chairsprite.sortingOrder = acima + 1;
                }

                if (dif < -0.25)
                {
                    chairsprite.sortingOrder = abaixo - 1;
                }

            }
            else
            {
                npcYpos = 0;
                PlayerYpos = 0;
            }

        if (NPCcollide)
        {
            chairsprite.sortingOrder = acima;
        }
        if (NPCcollide && isTrigger)
        {
            if (dif < 0.4)
            {
                sprite.sortingOrder = acima;
                chairsprite.sortingOrder = acima + 1;
            }

            if (dif < -0.25)
            {
                chairsprite.sortingOrder = abaixo + 3;
            }

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTrigger = true;
        }

        if (other.tag == "NPC")
        {
            NPCcollide = true;
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTrigger = false;
        }

        if (other.tag == "NPC")
        {
            NPCcollide = false;
        }

    }

}