using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeTextos : MonoBehaviour
{
    [SerializeField, TextArea (3,10)] private string [] arrayTextos;

    [SerializeField] private UIManage uIManager;
    [SerializeField] private Player player;

    private int indice;

    private void Awake(){

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnMouseDown(){

        float distancia = Vector2.Distance (this.gameObject.transform.position, player.transform.position);

        if(distancia <= 2){
            uIManager.ActivaDesactivaCajaTextos(true);
            player.ChequearSiHablo(true);
            ActivaCartel();
        }
    }

    private void ActivaCartel(){

        if(indice < arrayTextos.Length){

            uIManager.MostrarTextos(arrayTextos[indice]);
            indice++;
        }else{
            uIManager.ActivaDesactivaCajaTextos(false);
            player.ChequearSiHablo(false);
            indice=0;
        }
    }
}
