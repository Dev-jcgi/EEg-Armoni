using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
 public int maxDatos = 100; // Número máximo de puntos en el gráfico
    public float valorMaximoY = 10f; // Valor máximo en el eje Y
    public float velocidad = 1f; // Velocidad de actualización del gráfico

    private LineRenderer lineRenderer;
    private float tiempo = 0f;

    void OnEnable()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = maxDatos;
    }

    void LateUpdate()
    {
        // Calcula un nuevo valor para el eje Y (puedes reemplazar esto con tus propios datos)
        float nuevoDatoY = Mathf.Sin(tiempo) * valorMaximoY; // Ejemplo: un valor sinusoidal multiplicado por el valor máximo de Y

        // Calcula la nueva posición en el eje X (movimiento hacia la izquierda)
        float nuevaPosX = tiempo * velocidad;

        // Ajusta la posición para evitar que la línea choque con el final de la pantalla
        Vector3 nuevaPosicion = new Vector3(nuevaPosX, nuevoDatoY, 0f);
        nuevaPosicion = ClampToScreen(nuevaPosicion);

        // Añade un nuevo punto al gráfico
        for (int i = 0; i < lineRenderer.positionCount - 1; i++)
        {
            lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
        }

        // Mantiene la dirección en el eje X para la posición del último punto de la línea
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, nuevaPosicion);

        // Incrementa el tiempo para simular el avance en el eje X
        tiempo += Time.deltaTime;
    }

    Vector3 ClampToScreen(Vector3 posicion)
    {
        // Convierte la posición del mundo a coordenadas de pantalla
        Vector3 posicionPantalla = Camera.main.WorldToScreenPoint(posicion);

        // Obtiene el rayo desde la cámara al plano del canvas
        Ray rayo = Camera.main.ScreenPointToRay(posicionPantalla);
        Plane planoCanvas = new Plane(Vector3.forward, Vector3.zero);
        float distancia;
        planoCanvas.Raycast(rayo, out distancia);

        // Obtiene la posición del punto de intersección
        Vector3 puntoInterseccion = rayo.GetPoint(distancia);

        // Convierte la posición del mundo nuevamente a coordenadas de pantalla
        Vector3 posicionInterseccionPantalla = Camera.main.WorldToScreenPoint(puntoInterseccion);

        // Limita la posición al área visible del canvas
        float canvasWidth = Screen.width;
        float canvasHeight = Screen.height;
        posicionInterseccionPantalla.x = Mathf.Clamp(posicionInterseccionPantalla.x, 0f, canvasWidth);
        posicionInterseccionPantalla.y = Mathf.Clamp(posicionInterseccionPantalla.y, 0f, canvasHeight);

        // Convierte las coordenadas de pantalla nuevamente a posición del mundo
        return Camera.main.ScreenToWorldPoint(posicionInterseccionPantalla);
    }
}
