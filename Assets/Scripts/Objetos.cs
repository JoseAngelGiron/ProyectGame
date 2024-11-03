using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    public enum ObjetosEquipo{
        SaludPeque,
        SaludMedi,
        Velocidad


    };

    [SerializeField] ObjetosEquipo objetosEquipo;


    public void UsarObjeto(){

        Player player = GameObject.FindObjectOfType<Player>();

        switch(objetosEquipo){

            case ObjetosEquipo.SaludPeque:
                player.SumaVida();
                Debug.Log("Cura un punto de salud");
                break;
            case ObjetosEquipo.SaludMedi:
                player.SumaVida2();
                Debug.Log("Cura dos puntos de salud");
                break;
             case ObjetosEquipo.Velocidad:
                player.UsarPocionVelocidad();
                Debug.Log("Concede velocidad");
                break;
        }

        Destroy(this.gameObject);
    }
}
