#region 
//Falta terminar la visualizacion EEG
#endregion

using UnityEngine;
using UnityEngine.UI;

public class EEG_UI : MonoBehaviour
{
    public LineRenderer lineRenderer;  // Asigna el objeto LineRenderer en el Inspector
    public BrainwaveController brainwaveController;  // Asigna el controlador de las ondas cerebrales en el Inspector
    public float minLogValue = 0f;  // Asigna el valor mínimo aquí, por ejemplo, 0
    public float maxLogValue = 1f;  // Asigna el valor máximo aquí, por ejemplo, 1

    private void Update()
    {
        // Obtén los valores de las ondas cerebrales
        float attentionValue = brainwaveController.GetAttentionValue();
        float meditationValue = brainwaveController.GetMeditationValue();

        // Calcula la posición vertical de la señal en función de los valores de las ondas cerebrales
        float logValue = Mathf.Log(meditationValue);
        float yOffset = (logValue - minLogValue) / (maxLogValue - minLogValue) * 10;


        // Agrega nuevos puntos a la línea del LineRenderer
        Vector3 newPosition = new Vector3(lineRenderer.positionCount, yOffset, 0f);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);

        // Elimina los puntos más antiguos si la línea es demasiado larga
        if (lineRenderer.positionCount >1000) 
        {
            for (int i = 0; i < lineRenderer.positionCount - 1; i++)
            {
                lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
            }
            lineRenderer.positionCount--;
        }
    }
}