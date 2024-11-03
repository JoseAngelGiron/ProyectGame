using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Orco : MonoBehaviour
{
    public Transform personaje;  // Asegúrate de asignar el personaje en el inspector
    public Transform[] puntosRuta;
    private int indiceRuta;
    private NavMeshAgent agente;

    private bool objetivoDetectado;
    private SpriteRenderer sprite;
    private Transform objetivo;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        agente = GetComponent<NavMeshAgent>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        agente.updateRotation = false;
        agente.updateUpAxis = false;

        // Verificar si hay puntos de ruta antes de asignar un destino
        if (puntosRuta != null && puntosRuta.Length > 0)
        {
            agente.SetDestination(puntosRuta[indiceRuta].position);
        }
    }

    private void Update()
    {
        // Asegurarse de que la posición z siempre sea 0
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        // Verificar si hay puntos de ruta antes de acceder a ellos
        if (puntosRuta != null && puntosRuta.Length > 0)
        {
            if (this.transform.position == puntosRuta[indiceRuta].position)
            {
                if (indiceRuta < puntosRuta.Length - 1)
                {
                    indiceRuta++;
                }
                else if (indiceRuta == puntosRuta.Length - 1)
                {
                    indiceRuta = 0;
                }
            }
            agente.SetDestination(puntosRuta[indiceRuta].position);
        }

        // Comprobar la distancia con el personaje
        float distancia = Vector3.Distance(personaje.position, this.transform.position);
        objetivoDetectado = distancia < 3;

        MovimientoOrco(objetivoDetectado);
        RotarOrco();
    }

    void MovimientoOrco(bool esDetectado)
    {
        if (esDetectado)
        {
            agente.SetDestination(personaje.position);
            objetivo = personaje;
        }
        else if (puntosRuta != null && puntosRuta.Length > 0)
        {
            agente.SetDestination(puntosRuta[indiceRuta].position);
            objetivo = puntosRuta[indiceRuta];
        }
    }

    void RotarOrco()
    {
        if (objetivo != null)
        {
            if (transform.position.x > objetivo.position.x)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Attack");
        }
    }
}
