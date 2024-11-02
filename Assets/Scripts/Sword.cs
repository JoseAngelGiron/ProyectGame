using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private BoxCollider2D swordCollision;

    private void Awake(){

        swordCollision = GetComponent<BoxCollider2D>(); 


    }

    private void OnTriggerEnter2D(Collider2D other){

         //if(other.CompareTag("Orc")){
           // Destroy(other.gameObject);
        //}

    }


}
