using UnityEngine;
using System.Collections;

public class SecretariaNFalou_Adjust : MonoBehaviour {

    public CircleCollider2D Player;
    public BoxCollider2D Secretaria;
    public GameObject DialogueText;

	// Update is called once per frame
	void Update () {

        if (Player.IsTouching(Secretaria) && DialogueText.activeSelf == true)
        {
            Destroy(gameObject);
        }

	}
}
