using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{

    public Animator animator;
    public SpriteRenderer ruby;
    [Header("Balance Variable")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private int currentHP = 30;
    [SerializeField]
    private int HP = 30;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // w Up
        if (Input.GetKey(KeyCode.W)) 
        {
            animator.SetBool("RunUp",true);
            animator.SetBool("RunDown",false);
            animator.SetBool("RunSide",false);
            transform.position = new Vector2(transform.position.x,transform.position.y + moveSpeed);

        }
        // S down
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("RunUp", false);
            animator.SetBool("RunDown", true);
            animator.SetBool("RunSide", false);
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed);

        }
        // A Left
        if (Input.GetKey(KeyCode.A))
        {
            ruby.flipX = false;
            animator.SetBool("RunUp", false);
            animator.SetBool("RunDown", false);
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);

        }
        // D Right
        if (Input.GetKey(KeyCode.D))
        {
            ruby.flipX = true;
            animator.SetBool("RunUp", false);
            animator.SetBool("RunDown", false);
            animator.SetBool("RunSide", true); 
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);

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

       if(collision.CompareTag("Heal"))
       {
            if ((currentHP += collision.GetComponent<Heal>().PlusHeal) > HP)
                currentHP = HP;
            else
                currentHP += collision.GetComponent<Heal>().PlusHeal;
                //activar heal particulas
        }



   }




}
