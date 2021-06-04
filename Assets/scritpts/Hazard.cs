using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public Animator animator;
    public int DamageAmount;
    public ParticleSystem Damage;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("hazardanimation");
            Damage.Play();
        }

    }


}
