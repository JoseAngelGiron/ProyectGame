using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueOrco : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision){

        if(collision.gameObject.CompareTag("Player")){

            Player personaje = collision.gameObject.GetComponent<Player>();
            personaje.CausarHerida();
        }
    }


}
