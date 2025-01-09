using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    public int valor;

    public MedidorM medidorM;

    // Llamado una vez al inicio del script
    void Start()
    {
        // Iniciar el valor con un número aleatorio entre 0 y 100
        valor = Random.Range(0, 100);
    }

    // Llamado en cada frame
    void Update()
    {
        // Simular la actualización en tiempo real
       // ActualizarValor();

        
       
        // Imprimir el valor en la consola
        //Debug.Log("Valor actual: " + valor);
    }

    // Simula la actualización en tiempo real cambiando el valor
    void ActualizarValor()
    {
        // Aquí podrías implementar la lógica de actualización en tiempo real
        // Por ejemplo, podrías modificar el valor basándote en el tiempo transcurrido o eventos del juego.
        // En este caso, simplemente incrementamos el valor en un pequeño incremento constante.
        //valor += Time.deltaTime * 10; // Puedes ajustar la velocidad de actualización según tus necesidades.

        // Asegurarse de que el valor permanezca en el rango de 0 a 100
        //valor = Mathf.Clamp(valor, 0f, 100f);
    }
}