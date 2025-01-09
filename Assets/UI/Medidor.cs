using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medidor : MonoBehaviour
{
    [SerializeField]
    private Image aguja;
    
    public BrainwaveController BV;
    private float currentSpeed = 0;
    private float targetSpeed = 0;
    private float needleSpeed = 100.0f;

    // Update is called once per frame
    void Update()
    {
        if (targetSpeed != currentSpeed)
        {
            UpdateSpeed();
        }
    }

   

    // Método para establecer la velocidad desde un dato externo
    /* public void SetSpeedFromExternalDataA(int externalSpeed)
    {
        BV.Meditation
        targetSpeed = externalSpeed;
    } */
    
    public void SetSpeedFromExternalDataA()
    {
        targetSpeed = BV.Meditation;
    }

    void UpdateSpeed()
    {
        if (targetSpeed > currentSpeed)
        {
            currentSpeed += Time.deltaTime * needleSpeed;
            currentSpeed = Mathf.Clamp(currentSpeed, 0.0f, targetSpeed);
        }
        else if (targetSpeed < currentSpeed)
        {
            currentSpeed -= Time.deltaTime * needleSpeed;
            currentSpeed = Mathf.Clamp(currentSpeed, targetSpeed, 100.0f);
        }
        SetNeedle();
    }

    void SetNeedle()
    {
        aguja.transform.localEulerAngles = new Vector3(0, 0, (currentSpeed / 100.0f * 280.0f - 140.0f) * -1.0f);
    }
}
