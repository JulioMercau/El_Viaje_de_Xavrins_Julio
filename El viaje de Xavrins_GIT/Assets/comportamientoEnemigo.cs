using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class comportamientoEnemigo : MonoBehaviour
{

    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    bool estarAlerta;
    public float velocidad;
    public Transform jugador;
    public Collider colisionadorJugador;
    
    
    
    //variables de animacion

    public Animator animator;
    public string parametroMovimiento;
    public string parametroColision;
    private bool sePuedeMover;
    
    // Start is called before the first frame update
    void Start()
    {
        sePuedeMover = true;
    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta=Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);

        if (estarAlerta == true && sePuedeMover)
        {
            Vector3 posJugador = new Vector3 (jugador.position.x, transform.position.y, jugador.position.z);
            //Vector3 posJugadorReal = new Vector3(jugador.position.x, jugador.position.y, jugador.position.z);

            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidad*Time.deltaTime);
            animator.SetBool(parametroMovimiento, true);
        }
        else
        {
            animator.SetBool(parametroMovimiento, false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "alien")
        {
            sePuedeMover = false;
            animator.SetBool(parametroColision, true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.name == "alien")
        {
            sePuedeMover = true;
            animator.SetBool(parametroColision, false);
            
        }
    }
    
}

