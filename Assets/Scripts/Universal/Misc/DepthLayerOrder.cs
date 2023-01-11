using UnityEngine;
using System.Collections;

public class DepthLayerOrder : MonoBehaviour {

    public int acima = 0;
    public int abaixo = 0;
    private SpriteRenderer sprite;
    private OrderinLayer_NPC PLayers;
    public bool isTrigger;

    public float npcYpos;
    public float PlayerYpos;

    public GameObject Player;
    void Start()
    {
        sprite = Player.GetComponent<SpriteRenderer>();
        PLayers = Player.GetComponent<OrderinLayer_NPC>();
    }

    void Update()
    {
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
                if (npcYpos > PlayerYpos)
                {
                    sprite.sortingOrder = acima;
                }

            }
        else
        {
            npcYpos = 0;
            PlayerYpos = 0;
            }

        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTrigger = true;
            PLayers.enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTrigger = false;
            PLayers.enabled = true;
        }
    }

}