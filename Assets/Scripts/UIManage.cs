using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManage : MonoBehaviour
{
    private int totalMonedas;

    [SerializeField] private TMP_Text textoMonedas;
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private Sprite corazonDesactivado;

    [SerializeField] private GameObject cajaTexto;
    [SerializeField] private TMP_Text textoDialogo;

    private void Start()
    {
        Moneda.sumaMoneda += SumarMonedas; 
    }



    private void SumarMonedas(int moneda){

        totalMonedas += moneda;
        textoMonedas.text = totalMonedas.ToString();
    }

    public void RestaCorazones(int indice){

        Image imagenCorazon = listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonDesactivado;


    }


    public void ActivaDesactivaCajaTextos(bool activado){

        cajaTexto.SetActive(activado);
    }

    public void MostrarTextos (string texto){

        textoDialogo.text = texto.ToString();
    }
}
