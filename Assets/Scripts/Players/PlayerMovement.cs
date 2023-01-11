using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Animator animator;
    public float speed;
    public bool canMove;

    public bool Up;
    public bool Down;
    public bool Left;
    public bool Right;

    private int isMoving = 0;

	private Rigidbody2D rb;
	private Transform trans;


    // Use this for initialization
    void Start()
    {
        canMove = true;
        animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D> ();
		trans = GetComponent<Transform> ();
    }

    // Update is called once per frame
    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
		Vector2 p = new Vector2 (trans.position.x, trans.position.y);

        // movimento
        if (canMove)
        {
            if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !Left && !Right)
            {
				rb.MovePosition (p - Vector2.up * speed);

                //transform.Translate(-Vector2.up * speed);
                ChangeAnimationState(44);
                Down = true;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
				rb.MovePosition (p - Vector2.right * speed);
                //transform.Translate(-Vector2.right * speed);
                ChangeAnimationState(33);
                Left = true;

            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
				rb.MovePosition (p + Vector2.right * speed);
                //transform.Translate(Vector2.right * speed);
                ChangeAnimationState(22);
                Right = true;
            }
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !Left && !Right)
            {
				rb.MovePosition (p + Vector2.up * speed);
                //transform.Translate(Vector2.up * speed);
                ChangeAnimationState(11);
                Up = true;
            }

            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                transform.Translate(-Vector2.up * speed);
                ChangeAnimationState(4);
                Down = false;
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                transform.Translate(-Vector2.right * speed);
                ChangeAnimationState(3);
                Left = false;
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * speed);
                ChangeAnimationState(2);
                Right = false;
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                transform.Translate(Vector2.up * speed);
                ChangeAnimationState(1);
                Up = false;
            }

        }

    }

    public void ChangeAnimationState(int value)
    {
        animator.SetInteger("AnimState", value);
    }
}
