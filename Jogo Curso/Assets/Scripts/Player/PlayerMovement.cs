using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float jumpForce;
	private bool isLookLeft;
    private bool isAttack;
    private bool isGrounded;

    private Rigidbody2D rb;
    private Animator animator;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public GameObject AttackHitBox;
    public Transform HandTransform;
    private GameController gameController;
    
	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator>();

        gameController = FindObjectOfType(typeof(GameController)) as GameController;
        gameController.playerTransform = transform;
    }

	// Update is called once per frame
	void Update() {
		float h = Input.GetAxisRaw ("Horizontal");

        if(isAttack && isGrounded) {
            h = 0;
        }

        animator.SetInteger("H", (int) h);
        float speedY = rb.velocity.y;

        rb.velocity = new Vector2 (h * speed, speedY);

        if (isLookLeft && h > 0)
            Flip();
		else if (!isLookLeft && h < 0)
            Flip ();

		if (Input.GetButtonDown ("Jump") && isGrounded) 
			rb.AddForce (new Vector2 (0, jumpForce));

        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("speedY", speedY);
            
        if(Input.GetButtonDown("Fire1") && !isAttack) {
            isAttack = true;
            animator.SetTrigger("attack");
        }

        animator.SetBool("isAttack", isAttack);
	}

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f, groundLayer);
    }

    void Flip() {
		isLookLeft = !isLookLeft;
		transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
	}

    void OnFinishAtack() {
        isAttack = false;
    }

    void HitBoxAttack() {
        GameObject hitBoxTemp = Instantiate(AttackHitBox, HandTransform);
        Destroy(hitBoxTemp, 0.2f);
    }
}