using UnityEngine;
using System.Collections;

public class NPCDepth : MonoBehaviour {

    public int acima = 0;
    public int abaixo = 0;
    private SpriteRenderer sprite;
    public bool chairCollide;

    //public GameObject Player;
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (sprite)
            //  sprite.sortingOrder = cima;
            //  sprite.sortingOrder = abaixo;

            if (chairCollide)
            {
                sprite.sortingOrder = acima;

            }
            else
            {
                sprite.sortingOrder = abaixo;
            }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "NPC")
        {
            chairCollide = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "NPC")
        {
            chairCollide = false;
        }
    }

}