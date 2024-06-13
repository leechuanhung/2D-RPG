
using UnityEngine;

public class FighterCharacter : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody2d;
    private AudioSource audioSource;

    public AudioClip JumpClip;


    public float Speed = 4f;
    public float JumpPower = 6f;

    private bool isFloor;
    private bool isLadder;
    private bool isClimbing;
    private float inputVertical;

    public GameObject AttackObj;
    public float AttackSpeed = 3f;
    public AudioClip AttackClip;

    private bool justAttack, justJump;
    private bool faceRight = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        Walk();
        AttackCheck();
        JumpCheck();
        ClimbingCheck();
    }

    private void FixedUpdate()
    {
        Jump();
        Kick();
        Climbing();
    }

    private void Walk()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            animator.SetBool("Walk", true);
            if (!faceRight) Flip();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            animator.SetBool("Walk", true);
            if (faceRight) Flip();
        }
        else
        {
            animator.SetBool("Walk", false);
        }

    }

    private void Flip()
    {
        faceRight = !faceRight;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void JumpCheck()
    {
        if (isFloor)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                justJump = true;
            }
        }
    }

    private void Jump()
    {
        if (justJump)
        {
            justJump = false;

            rigidbody2d.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            audioSource.PlayOneShot(JumpClip);
        }
    }

    private void AttackCheck()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            justAttack = true;
        }
    }

    private void Kick()
    {
        if (justAttack)
        {
            justAttack = false;
            animator.SetTrigger("Kick");
            audioSource.PlayOneShot(AttackClip);

            if (gameObject.name == "Warrior(Clone)")
            {
                //AttackObj.SetActive(true);
                AttackObj.GetComponent<Collider2D>().enabled = true;
                Invoke("SetAttackObjInative", 0.5f);
            }

            else
            {
                if (!faceRight)
                {
                    GameObject obj = Instantiate(AttackObj, transform.position, Quaternion.Euler(0, 180f, 0));
                    obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * AttackSpeed, ForceMode2D.Impulse);
                    Destroy(obj, 3f);
                }
                else
                {
                    GameObject obj = Instantiate(AttackObj, transform.position, Quaternion.Euler(0, 0, 0));
                    obj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * AttackSpeed, ForceMode2D.Impulse);
                    Destroy(obj, 3f);
                }

            }
        }
    }

    private void SetAttackObjInative()
    {
        //AttackObj.SetActive(false);
        AttackObj.GetComponent<Collider2D>().enabled = false;
    }

    private void ClimbingCheck()
    {
        inputVertical = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(inputVertical) > 0)
        {
            isClimbing = true;
        }
    }

    private void Climbing()
    {
        if (isClimbing)
        {
            rigidbody2d.gravityScale = 0f;
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, inputVertical * Speed);
        }
        else
        {
            rigidbody2d.gravityScale = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFloor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFloor = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = true;
        }
        if (collision.gameObject.tag == "Coin")
        {
            PlayerUI.coinAmount += 1;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = false;
            isClimbing = false;
        }
    }

}