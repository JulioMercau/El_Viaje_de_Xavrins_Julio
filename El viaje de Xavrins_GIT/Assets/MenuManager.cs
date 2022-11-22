using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //retarda una accion los segundos indicados
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds (5);
    }
    
    public void CargaEscena()
    {
        StartCoroutine("Esperar");
        SceneManager.LoadScene("nivel_1");

    }

    public void Salir()
    {
        StartCoroutine("Esperar");
        Application.Quit();
    }
}
