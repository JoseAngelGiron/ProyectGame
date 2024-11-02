using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    [SerializeField] private float velocidad;
    [SerializeField] private BoxCollider2D collSword;

    private Rigidbody2D rigid;
    private Animator animator;

    private float posColX = 1;
    private float posColY = 0;

    private SpriteRenderer spriteCharacter;

    private int vidaPersonaje = 3;
    private bool estoyHablando;

    [SerializeField] UIManage uIManage;

    private void Awake(){
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteCharacter = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update(){

        if(Input.GetMouseButtonDown(0) && estoyHablando == false){
            animator.SetTrigger("Attack");

        }
        /*

        if(Input.GetKeyDown(KeyCode.K)){
            CausarHerida();
        }
        */
    }

    private void FixedUpdate(){
        Movement();
        
    }

    public void ChequearSiHablo(bool hablando){

        estoyHablando = hablando;
    }

    private void Movement(){

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(estoyHablando == false){
            rigid.velocity = new Vector2(horizontal, vertical) * velocidad;
            animator.SetFloat("Walk", Mathf.Abs(rigid.velocity.magnitude));
        }

        

        if(horizontal > 0){
            collSword.offset = new Vector2(posColX, posColY);
            spriteCharacter.flipX = false;

        }else if(horizontal < 0){
            collSword.offset = new Vector2(-posColX, posColY);
            spriteCharacter.flipX = true;
        }
    }

    private void CausarHerida(){

        if(vidaPersonaje>0){
            vidaPersonaje --;
            uIManage.RestaCorazones(vidaPersonaje);
            if(vidaPersonaje == 0){
                animator.SetTrigger("Die");
                Invoke(nameof(Morir), 1f);
            }
        }
    }

    private void Morir(){
        Destroy(this.gameObject);
    }
}
