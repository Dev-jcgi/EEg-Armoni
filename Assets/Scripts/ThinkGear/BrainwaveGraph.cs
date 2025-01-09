using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(LineRenderer))]
public class BrainwaveGraph : MonoBehaviour
{/* VERSION 1    
    public BrainwaveController brainwaveController; // Referencia a tu script BrainwaveController
    public Image meditationImage; // Imagen para meditación
    public Image attentionImage; // Imagen para atención

    public float meditationValue;
    public float attentionValue;

    private void Update()
    {
        // Asumiendo que tienes métodos en BrainwaveController para obtener los valores actuales
        meditationValue = brainwaveController.GetMeditationValue();
        attentionValue = brainwaveController.GetAttentionValue();

        // Normalizar los valores (si están en un rango de 0-100)
        meditationImage.fillAmount = meditationValue / 100f;
        attentionImage.fillAmount = attentionValue / 100f;
    } */

    /* public BrainwaveController brainwaveController;

    public float meditationValue;
    public float attentionValue;
    private LineRenderer lineRenderer;

    public int resolution = 1000; // Cuántos puntos en la gráfica
    public float graphWidth = 10f; // Ancho de la gráfica en unidades de mundo
    public float amplitude = 1f; // Altura máxima de la gráfica

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = resolution;
    }

    void Update()
    {
        float meditationValue = brainwaveController.GetMeditationValue();
        float attentionValue = brainwaveController.GetAttentionValue();

        // Usamos meditationValue y attentionValue para afectar la gráfica
        float frequency = 1f + meditationValue * 0.01f; // Por ejemplo, usamos meditationValue para ajustar la frecuencia
        amplitude = 1f + attentionValue * 0.01f; // Usamos attentionValue para ajustar la amplitud

        DrawSinWave(frequency);
    }

    void DrawSinWave(float frequency)
    {
        for (int i = 0; i < resolution; i++)
        {
            float x = (i / (float)resolution) * graphWidth;
            float y = amplitude * Mathf.Sin(frequency * x);
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    } */



    public BrainwaveController brainwaveController;
    private LineRenderer lineRenderer;

    public int resolution = 1000; // Cuántos puntos en la gráfica
    public float graphWidth = 10f; // Ancho de la gráfica en unidades de mundo
    public float amplitude = 1f; // Altura máxima de la gráfica

    private float meditationValue;
    private float attentionValue;

    void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = resolution;

        // Inicializar los valores de meditation y attention
        meditationValue = brainwaveController.GetMeditationValue();
        attentionValue = brainwaveController.GetAttentionValue();
    }

    void Update() {
        // Actualizar los valores de meditation y attention
        meditationValue = brainwaveController.GetMeditationValue();
        attentionValue = brainwaveController.GetAttentionValue();

        // Usamos meditationValue y attentionValue para afectar la gráfica
        float frequency = 1f + meditationValue * 0.01f; // Por ejemplo, usamos meditationValue para ajustar la frecuencia
        amplitude = 1f + attentionValue * 0.01f; // Usamos attentionValue para ajustar la amplitud

        DrawSinWave(frequency);
    }

    void DrawSinWave(float frequency) {
        for (int i = 0; i < resolution; i++) {
            float x = (i / (float)resolution) * graphWidth;
            float y = amplitude * Mathf.Sin(frequency * x);
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
}

