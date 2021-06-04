using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{

    public Animator animator;
    public SpriteRenderer ruby;
    public Rigidbody2D rigidbody;
    [Header("Balance Variable")]
    [SerializeField]
    private float jumpForce = 1;
    public float moveSpeed;
    public int currentHP = 30;
    public int HP = 30;
    public float impulso = 2;



    private float horizontal;
    private float vertical;
    private Vector3 direction;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0f, vertical);

       if (Input.GetKey(KeyCode.A))
        {
            ruby.flipX = false;
            //animator.SetBool("RunUp", false);
            //animator.SetBool("RunDown", false);
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);

        }
        // D Right
        if (Input.GetKey(KeyCode.D))
        {
            ruby.flipX = true;
            //animator.SetBool("RunUp", false);
            //animator.SetBool("RunDown", false);
            animator.SetBool("RunSide", true); 
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);

        }

        if (direction.magnitude == 0f)
        {
            animator.SetBool("RunSide", false);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }



    }

   private void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.CompareTag("Hazard"))
        {
            if ((currentHP - collision.GetComponent<Hazard>().DamageAmount) < 0)

                currentHP = 0;
           else

                currentHP -= collision.GetComponent<Hazard>().DamageAmount;
                animator.SetTrigger("Damageside");
        
        }

        if (collision.CompareTag("Enemy"))
        {
            if ((currentHP - collision.GetComponent<enemigo>().damageamount) < 0)

                currentHP = 0;
            else

                currentHP -= collision.GetComponent<enemigo>().damageamount;
                 animator.SetTrigger("Damageside");

        }

       if (collision.CompareTag("Heal"))
       {
            if ((currentHP += collision.GetComponent<Heal>().PlusHeal) > HP)
                currentHP = HP;
            else
                currentHP += collision.GetComponent<Heal>().PlusHeal;
       }



   }
      private void OnCollisionEnter2D(Collision2D collision)
      {
        if (collision.gameObject.CompareTag("plataformasaltarina"))
        {
          
            rigidbody.AddForce(new Vector2(0f, impulso), ForceMode2D.Impulse);
        
        }
      }






}
