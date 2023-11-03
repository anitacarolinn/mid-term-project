using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public SoundEffectPlayer SoundEffect;

    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    public Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer sr;

    private bool isGrounded = true;
    private string Ground_Tag = "Ground";
    private string Enemies_Tag = "Enemies";

    private float lastY;
    private float fallTime;
    private float diffY;
    private bool isFalling;

    private bool delayAtk;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        gameManager.NewGame();
        lastY = myBody.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        AnimatePlayer();
        PlayerJump();
        PlayerFall();

        //set the yVelocity in the animator
        anim.SetFloat("yVelocity",myBody.velocity.y);
    }


    void PlayerMove()
    {
        movementX = Input.GetAxisRaw("Horizontal"); //press A or D to move left n right
                                                    // GetAxisRaw return -1, 0 ,-1
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce; //change the player x position
    }

    void AnimatePlayer()
    {
        if (movementX > 0) //move to right
        {
            anim.SetBool("isWalk", true); //set animator "Walk" to true
            sr.flipX = false;
        }

        else if (movementX < 0) //move to left
        {
            anim.SetBool("isWalk", true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool("isWalk", false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("isJump", true);
            SoundEffect.JumpSE();
        }

        if(myBody.velocity.y == 0f)
        {
            isGrounded = true;
            anim.SetBool("isFall", false);
        }
    }
    
    void PlayerFall()
    {
        if (myBody.velocity.y < 0)
        {
            isGrounded = false;
            anim.SetBool("isFall", true);
            diffY = myBody.transform.position.y - lastY;
            if (diffY < -8f) //died if player fall too high
            {
                isFalling = true;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //to make sure the player is on the ground to continously jump
        if (collision.gameObject.CompareTag(Ground_Tag))
        {
            isGrounded = true;
            anim.SetBool("isJump", false);
            anim.SetBool("isFall", false);

            if (isFalling) //died if player fall too high
            {
                HealthManager.health -= 1;
                SoundEffect.hurtSE();
                isFalling = false;
            }

        }


        if (collision.gameObject.CompareTag(Enemies_Tag) && !delayAtk)
        {
            isGrounded = true;
            anim.SetBool("isJump", false);
            anim.SetBool("isFall", false);
            StartCoroutine(delayAttack());

            HealthManager.health -= 1;
            if (HealthManager.health > 0){
                SoundEffect.hurtSE();
            }
            else
            {
                SoundEffect.failedSE();
            }
            
        }

        if (collision.gameObject.CompareTag("TerjunBebas"))
        {
            Destroy(gameObject);
            gameManager.youHaveDied();
            SoundEffect.failedSE();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Ground_Tag))
        {
            lastY = myBody.transform.position.y;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ReachPortal>())
        {
            anim.SetBool("isHome", true);
            gameManager.stageClear();
        }
    }

    private IEnumerator delayAttack()
    {
        delayAtk = true;
        yield return new WaitForSeconds(1f);
        delayAtk = false;

    }
}
