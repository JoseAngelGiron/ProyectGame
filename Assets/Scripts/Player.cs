using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    [SerializeField] private float velocidad;

    private Rigidbody2D rigid;
    private Animator animator;

    private SpriteRenderer spriteCharacter;

    private void Awake(){
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteCharacter = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate(){
        Movement();
        
    }

    private void Movement(){

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rigid.velocity = new Vector2(horizontal, vertical) * velocidad;
        animator.SetFloat("Walk", Mathf.Abs(rigid.velocity.magnitude));

        if(horizontal > 0){
            spriteCharacter.flipX = false;

        }else if(horizontal < 0){

            spriteCharacter.flipX = true;
        }
    }
}
