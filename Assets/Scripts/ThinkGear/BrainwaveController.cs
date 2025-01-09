#region 
//Falta terminar la visualizacion EEG
#endregion


//VERTION 1
/* using UnityEngine;
using System.Collections;

public class BrainwaveController : MonoBehaviour
{
    private int connectionID = -1;

    void Start()
    {
        Debug.Log("Iniciando BrainwaveController...");
        ConnectToThinkGear();
    }

    void ConnectToThinkGear()
    {
        Debug.Log("Intentando conectar a ThinkGear...");
        connectionID = ThinkGear.TG_GetNewConnectionId();

        if (connectionID >= 0)
        {
            Debug.Log("ID de conexión obtenido: " + connectionID);
            int connectStatus = ThinkGear.TG_Connect(connectionID, "COM3", ThinkGear.BAUD_9600, ThinkGear.STREAM_PACKETS);

            if (connectStatus >= 0)
            {
                Debug.Log("Conectado exitosamente a ThinkGear.");
            }
            else
            {
                Debug.LogError("Error al conectar a ThinkGear. Código de estado: " + connectStatus);
            }
        }
        else
        {
            Debug.LogError("No se pudo obtener un ID de conexión válido.");
        }
    }

    void Update()
    {
        ReadBrainwaveData();
    }

    void ReadBrainwaveData()
    {
        if (connectionID >= 0)
        {
            int packetCount = ThinkGear.TG_ReadPackets(connectionID, -1);

            if (packetCount > 0)
            {
                Debug.Log("Paquetes recibidos: " + packetCount);
                float attention = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ATTENTION);
                float meditation = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_MEDITATION);

                Debug.Log("Atención: " + attention);
                Debug.Log("Meditación: " + meditation);
            }
            else
            {
                Debug.LogWarning("No se recibieron paquetes de datos.");
            }
        }
        else
        {
            Debug.LogWarning("ID de conexión no válido. No se pueden leer datos.");
        }
    }
}
 */
//VERTION 2
/*  using UnityEngine;
using System.Collections;

public class BrainwaveController : MonoBehaviour
{
    private int connectionID = -1;
    private const string PORT_NAME = "COM3";

    void Start()
    {
        // Iniciar la conexión al iniciar el juego
        ConnectToThinkGear();
    }

    void ConnectToThinkGear()
    {
        // Generar un identificador para la conexión ThinkGear
        connectionID = ThinkGear.TG_GetNewConnectionId();

        if (connectionID >= 0)
        {
            // Establecer la conexión real usando el puerto COM3
            int connectStatus = ThinkGear.TG_Connect(connectionID, PORT_NAME, ThinkGear.BAUD_9600, ThinkGear.STREAM_PACKETS);

            if (connectStatus >= 0)
            {
                Debug.Log("Conectado exitosamente a ThinkGear.");
            }
            else
            {
                Debug.LogError($"Error al conectar a ThinkGear. Código de estado: {connectStatus}");
                ReconnectToThinkGear();
            }
        }
        else
        {
            Debug.LogError("No se pudo obtener un ID de conexión válido.");
        }
    }

    void Update()
    {
        // Leer datos en cada frame
        ReadBrainwaveData();
    }

    void ReadBrainwaveData()
    {
        if (connectionID >= 0)
        {
            int packetCount = ThinkGear.TG_ReadPackets(connectionID, -1);

            if (packetCount > 0)
            {
                float attention = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ATTENTION);
                float meditation = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_MEDITATION);

                Debug.Log("Atención: " + attention);
                Debug.Log("Meditación: " + meditation);
            }
        }
    }

    public void ReconnectToThinkGear()
    {
        // Si ya estamos conectados, desconectamos primero
        if (connectionID >= 0)
        {
            ThinkGear.TG_FreeConnection(connectionID);
            Debug.Log("Desconectado de ThinkGear para reiniciar la conexión.");
        }

        // Espera un momento antes de intentar reconectar
        StartCoroutine(ReconnectAfterDelay());
    }

    IEnumerator ReconnectAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);  // Espera 1 segundo
        ConnectToThinkGear();
    }
}
 */

 //VERTION 3
/* using UnityEngine;
using System.Collections;

public class BrainwaveController : MonoBehaviour
{
    private int connectionID = -1;
    private const string PORT_NAME = "COM3";

    void Start()
    {
        // Iniciar la conexión al iniciar el juego
        ConnectToThinkGear();
    }

    void ConnectToThinkGear()
    {
        // Generar un identificador para la conexión ThinkGear
        connectionID = ThinkGear.TG_GetNewConnectionId();

        if (connectionID >= 0)
        {
            // Establecer la conexión real usando el puerto COM3
            int connectStatus = ThinkGear.TG_Connect(connectionID, PORT_NAME, ThinkGear.BAUD_9600, ThinkGear.STREAM_PACKETS);

            if (connectStatus >= 0)
            {
                Debug.Log("Conectado exitosamente a ThinkGear.");
            }
            else
            {
                Debug.LogError($"Error al conectar a ThinkGear. Código de estado: {connectStatus}");
                ReconnectToThinkGear();
            }
        }
        else
        {
            Debug.LogError("No se pudo obtener un ID de conexión válido.");
        }
    }

    void Update()
    {
        // Leer datos en cada frame
        ReadBrainwaveData();
    }

    void ReadBrainwaveData()
    {
        if (connectionID >= 0)
        {
            int packetCount = ThinkGear.TG_ReadPackets(connectionID, -1);

            if (packetCount > 0)
            {
                float attention = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ATTENTION);
                float meditation = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_MEDITATION);

                Debug.Log("Atención: " + attention);
                Debug.Log("Meditación: " + meditation);
            }
        }
    }

    public float GetMeditationValue()
    {
        if (connectionID >= 0)
        {
            return ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_MEDITATION);
        }
        else
        {
            Debug.LogError("No se pudo obtener el valor de meditación debido a un ID de conexión no válido.");
            return -1;  // Devuelve -1 para indicar un error
        }
    }

    public float GetAttentionValue()
    {
        if (connectionID >= 0)
        {
            return ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ATTENTION);
        }
        else
        {
            Debug.LogError("No se pudo obtener el valor de atención debido a un ID de conexión no válido.");
            return -1;  // Devuelve -1 para indicar un error
        }
    }

    public void ReconnectToThinkGear()
    {
        // Si ya estamos conectados, desconectamos primero
        if (connectionID >= 0)
        {
            ThinkGear.TG_FreeConnection(connectionID);
            Debug.Log("Desconectado de ThinkGear para reiniciar la conexión.");
        }

        // Espera un momento antes de intentar reconectar
        StartCoroutine(ReconnectAfterDelay());
    }

    IEnumerator ReconnectAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);  // Espera 1 segundo
        ConnectToThinkGear();
    }
}
 */

 //Vertion 4
/* 
using UnityEngine;
using System.Collections;

public class BrainwaveController : MonoBehaviour
{
    private int connectionID = -1;
    [SerializeField] private const string PORT_NAME = "COM3";

    // Variables para almacenar los valores de las ondas cerebrales y otros datos
    private float indexSignalIcons;
    private int PoorSignal;
    private int Attention;
    private int Meditation;
    private float Alpha_1;
    private float Alpha_2;
    private float Beta_1;
    private float Beta_2;
    private float Gamma_1;
    private float Gamma_2;
    private float Delta;
    private float Theta;


    void Start()
    {
        ConnectToThinkGear();
    }

    void ConnectToThinkGear()
    {
        connectionID = ThinkGear.TG_GetNewConnectionId();

        if (connectionID >= 0)
        {
            int connectStatus = ThinkGear.TG_Connect(connectionID, PORT_NAME, ThinkGear.BAUD_9600, ThinkGear.STREAM_PACKETS);

            if (connectStatus >= 0)
            {
                Debug.Log("Conectado exitosamente a ThinkGear.");
            }
            else
            {
                Debug.LogError($"Error al conectar a ThinkGear. Código de estado: {connectStatus}");
                ReconnectToThinkGear();
            }
        }
        else
        {
            Debug.LogError("No se pudo obtener un ID de conexión válido.");
        }
    }

    void Update()
    {
        ReadBrainwaveData();
    }

    void ReadBrainwaveData()
    {
        if (connectionID >= 0)
        {
            int packetCount = ThinkGear.TG_ReadPackets(connectionID, -1);

            if (packetCount > 0)
            {
                // Leer y almacenar los valores de las ondas cerebrales y otros datos
                Attention = (int)ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ATTENTION);
                Meditation = (int)ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_MEDITATION);              
                Delta = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_DELTA);
                Theta = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_THETA);  
                Alpha_1 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ALPHA1);
                Alpha_2 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ALPHA2);
                Beta_1 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_BETA1);
                Beta_2 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_BETA2);
                Gamma_1 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_GAMMA1);
                Gamma_2 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_GAMMA2);
             
                // Imprimir algunos valores para depuración
                Debug.Log($"Atención: {Attention}, Meditación: {Meditation}");
                Debug.Log($"Alpha_1: {Alpha_1}, Alpha_2: {Alpha_2}");
                Debug.Log($"Beta_1: {Beta_1}, Beta_2: {Beta_2}");
                Debug.Log($"Gamma_1: {Gamma_1}, Gamma_2: {Gamma_2}");
                Debug.Log($"Delta: {Delta}, Theta: {Theta}");
            }
        }
    }

    // Funciones para obtener los valores de las ondas cerebrales y otros datos
    public int GetAttentionValue() => Attention;
    public int GetMeditationValue() => Meditation;
    public float GetAlpha1Value() => Alpha_1;
    public float GetAlpha2Value() => Alpha_2;
    public float GetBeta1Value() => Beta_1;
    public float GetBeta2Value() => Beta_2;
    public float GetGamma1Value() => Gamma_1;
    public float GetGamma2Value() => Gamma_2;
    public float GetDeltaValue() => Delta;
    public float GetThetaValue() => Theta;   
    // Aquí puedes agregar más funciones getter si es necesario

    public void ReconnectToThinkGear()
    {
        if (connectionID >= 0)
        {
            ThinkGear.TG_FreeConnection(connectionID);
            Debug.Log("Desconectado de ThinkGear para reiniciar la conexión.");
        }

        StartCoroutine(ReconnectAfterDelay());
    }

    IEnumerator ReconnectAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);
        ConnectToThinkGear();
    }
} */

//Vertion 5
/* using UnityEngine;
using System.Collections;

public class BrainwaveController : MonoBehaviour
{
    // Representa el número máximo de conexiones simultáneas permitidas con ThinkGear.
    public const int MAX_CONNECTION_HANDLES = 128;

    // ID de conexión con el dispositivo ThinkGear. Inicialmente se establece en -1, lo que indica que no hay conexión.
    private int connectionID = -1;

    // Nombre del puerto de comunicación. Se establece inicialmente en "COM3", pero puede ser modificado.
    [SerializeField] private string portName = "COM3";

    // Variable para almacenar la tasa de baudios actual.
    [SerializeField] public int currentBaudRate = 9600;

    // Variables para almacenar los valores de las ondas cerebrales y otros datos del EEG.
    private float indexSignalIcons;
    private int PoorSignal;
    private int Attention;
    private int Meditation;
    private float Alpha_1;
    private float Alpha_2;
    private float Beta_1;
    private float Beta_2;
    private float Gamma_1;
    private float Gamma_2;
    private float Delta;
    private float Theta;

    void Start()
    {
        // Intenta conectarse al dispositivo ThinkGear al iniciar el script.
        if (currentConnections < MAX_CONNECTION_HANDLES) 
        {
            ConnectToThinkGear();
        } 
        else 
        {
            Debug.LogError("Se ha alcanzado el número máximo de conexiones permitidas.");
        }
    }

    // Método para cambiar la tasa de baudios.
    public void SetBaudRate(int newBaudRate)
    {
        currentBaudRate = newBaudRate;
        ReconnectToThinkGear();
    }

    // Método para conectarse al dispositivo ThinkGear.
    void ConnectToThinkGear()
    {
        // Solicita un nuevo ID de conexión.
        connectionID = ThinkGear.TG_GetNewConnectionId();

        // Si el ID de conexión es válido (es decir, no es negativo).
        if (connectionID >= 0)
        {
            // Intenta conectar usando el ID de conexión, el nombre del puerto y otros parámetros.
            int connectStatus = ThinkGear.TG_Connect(connectionID, portName, currentBaudRate, ThinkGear.STREAM_PACKETS);

            // Si la conexión es exitosa.
            if (connectStatus >= 0)
            {
                Debug.Log("Conectado exitosamente a ThinkGear.");
            }
            else
            {
                // Si hay un error en la conexión, muestra el código de error y reintenta la conexión.
                Debug.LogError($"Error al conectar a ThinkGear. Código de estado: {connectStatus}");
                ReconnectToThinkGear();
            }
        }
        else
        {
            // Si no se pudo obtener un ID de conexión válido, muestra un mensaje de error.
            Debug.LogError("No se pudo obtener un ID de conexión válido.");
        }
    }

    void Update()
    {
        // Lee los datos de las ondas cerebrales en cada fotograma.
        ReadBrainwaveData();
    }

    // Método para leer y procesar los datos de las ondas cerebrales.
    void ReadBrainwaveData()
    {
        // Si hay una conexión válida.
        if (connectionID >= 0)
        {
            // Lee los paquetes de datos del dispositivo.
            int packetCount = ThinkGear.TG_ReadPackets(connectionID, -1);

            // Si hay paquetes de datos disponibles.
            if (packetCount > 0)
            {
                // Leer y almacenar los valores de las ondas cerebrales y otros datos.
                Attention = (int)ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ATTENTION);
                Meditation = (int)ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_MEDITATION);              
                Delta = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_DELTA);
                Theta = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_THETA);  
                Alpha_1 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ALPHA1);
                Alpha_2 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ALPHA2);
                Beta_1 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_BETA1);
                Beta_2 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_BETA2);
                Gamma_1 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_GAMMA1);
                Gamma_2 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_GAMMA2);
             
                // Imprimir algunos valores para depuración.
                Debug.Log($"Atención: {Attention}, Meditación: {Meditation}");
                Debug.Log($"Alpha_1: {Alpha_1}, Alpha_2: {Alpha_2}");
                Debug.Log($"Beta_1: {Beta_1}, Beta_2: {Beta_2}");
                Debug.Log($"Gamma_1: {Gamma_1}, Gamma_2: {Gamma_2}");
                Debug.Log($"Delta: {Delta}, Theta: {Theta}");
            }
        }
    }

    // Métodos para obtener los valores de las ondas cerebrales y otros datos.
    public int GetAttentionValue() => Attention;
    public int GetMeditationValue() => Meditation;
    public float GetAlpha1Value() => Alpha_1;
    public float GetAlpha2Value() => Alpha_2;
    public float GetBeta1Value() => Beta_1;
    public float GetBeta2Value() => Beta_2;
    public float GetGamma1Value() => Gamma_1;
    public float GetGamma2Value() => Gamma_2;
    public float GetDeltaValue() => Delta;
    public float GetThetaValue() => Theta;   
    // Aquí puedes agregar más funciones getter si es necesario.

    // Método para reconectar al dispositivo ThinkGear en caso de desconexión.
    public void ReconnectToThinkGear()
    {
        if (connectionID >= 0)
        {
            // Libera la conexión actual.
            ThinkGear.TG_FreeConnection(connectionID);
            Debug.Log("Desconectado de ThinkGear para reiniciar la conexión.");
        }

        // Intenta reconectar después de un breve retraso.
        Invoke("ConnectToThinkGear", 2.0f);
    }
}
 */

 //Vertion 6
using UnityEngine;

public class BrainwaveController : MonoBehaviour
{
    // Constantes para diferentes modos de transmisión y tipos de datos.
    public const int STREAM_PACKETS = 0;
    public const int STREAM_5VRAW = 1;
    public const int STREAM_FILE_PACKETS = 2;
    public const int DATA_BATTERY = 0;
    public const int DATA_POOR_SIGNAL = 1;
    public const int DATA_RAW = 4;

    // Representa el número máximo de conexiones simultáneas permitidas con ThinkGear.
    public const int MAX_CONNECTION_HANDLES = 128;

    // ID de conexión con el dispositivo ThinkGear.
    private int connectionID = -1;

    // Nombre del puerto de comunicación.
    [SerializeField] private string portName = "COM3";

    // Variable para almacenar la tasa de baudios actual.
    [SerializeField] public int currentBaudRate = 9600;

    // Variables para almacenar los valores de las ondas cerebrales y otros datos del EEG.
    private int batteryValue;
    private int PoorSignal;
    private int rawValue;
    public int Attention;
    public int Meditation;
    private float Alpha_1;
    private float Alpha_2;
    private float Beta_1;
    private float Beta_2;
    private float Gamma_1;
    private float Gamma_2;
    private float Delta;
    private float Theta;

    //variable para el medidor
    public Medidor medidorA;
    public MedidorM medidorM;
    void Start()
    {
        // Intenta conectarse al dispositivo ThinkGear al iniciar el script.
        ConnectToThinkGear();
    }

    // Método para cambiar la tasa de baudios.
    public void SetBaudRate(int newBaudRate)
    {
        currentBaudRate = newBaudRate;
        ReconnectToThinkGear();
    }

    // Método para conectarse al dispositivo ThinkGear.
    void ConnectToThinkGear()
    {
        // Solicita un nuevo ID de conexión.
        connectionID = ThinkGear.TG_GetNewConnectionId();

        // Si el ID de conexión es válido.
        if (connectionID >= 0)
        {
            // Intenta conectar usando el ID de conexión, el nombre del puerto y otros parámetros.
            int connectStatus = ThinkGear.TG_Connect(connectionID, portName, currentBaudRate, ThinkGear.STREAM_PACKETS);

            // Si la conexión es exitosa.
            if (connectStatus >= 0)
            {
                Debug.Log("Conectado exitosamente a ThinkGear.");
            }
            else
            {
                // Si hay un error en la conexión, muestra el código de error y reintenta la conexión.
                Debug.LogError($"Error al conectar a ThinkGear. Código de estado: {connectStatus}");
                ReconnectToThinkGear();
            }
        }
        else
        {
            // Si no se pudo obtener un ID de conexión válido, muestra un mensaje de error.
            Debug.LogError("No se pudo obtener un ID de conexión válido.");
        }
    }

    void Update()
    {
        // Lee los datos de las ondas cerebrales en cada fotograma.
        ReadBrainwaveData();
         
         //Los valores de Attetion y Meditation se pasan para la interfaz
         //medidorA.SetSpeedFromExternalDataA(Attention);
         //medidorM.SetSpeedFromExternalDataM(Meditation);
         
    }

    // Método para leer y procesar los datos de las ondas cerebrales.
    void ReadBrainwaveData()
    {
        // Si hay una conexión válida.
        if (connectionID >= 0)
        {
            // Lee los paquetes de datos del dispositivo.
            int packetCount = ThinkGear.TG_ReadPackets(connectionID, -1);

            // Si hay paquetes de datos disponibles.
            if (packetCount > 0)
            {
                // Leer y almacenar los valores de las ondas cerebrales y otros datos.
                batteryValue = (int)ThinkGear.TG_GetValue(connectionID, DATA_BATTERY);
                PoorSignal = (int)ThinkGear.TG_GetValue(connectionID, DATA_POOR_SIGNAL);
                rawValue = (int)ThinkGear.TG_GetValue(connectionID, DATA_RAW);
                Attention = (int)ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ATTENTION);
                Meditation = (int)ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_MEDITATION);
                Delta = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_DELTA);
                Theta = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_THETA);
                Alpha_1 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ALPHA1);
                Alpha_2 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_ALPHA2);
                Beta_1 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_BETA1);
                Beta_2 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_BETA2);
                Gamma_1 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_GAMMA1);
                Gamma_2 = ThinkGear.TG_GetValue(connectionID, ThinkGear.DATA_GAMMA2);

                // Imprimir los valores para depuración.
                Debug.Log($"Batería: {batteryValue}, Señal Pobre: {PoorSignal}, Datos en Bruto: {rawValue}");
                Debug.Log($"Atención: {Attention}, Meditación: {Meditation}");
                Debug.Log($"Alpha_1: {Alpha_1}, Alpha_2: {Alpha_2}");
                Debug.Log($"Beta_1: {Beta_1}, Beta_2: {Beta_2}");
                Debug.Log($"Gamma_1: {Gamma_1}, Gamma_2: {Gamma_2}");
                Debug.Log($"Delta: {Delta}, Theta: {Theta}");
            }
        }
    }

    // Métodos para obtener los valores de las ondas cerebrales y otros datos.
    public int GetBatteryValue() => batteryValue;
    public int GetPoorSignalValue() => PoorSignal;
    public int GetRawValue() => rawValue;
    //Datos para la UI
    public int GetAttentionValue() => Attention;
    public int GetMeditationValue() => Meditation;
    public float GetAlpha1Value() => Alpha_1;
    public float GetAlpha2Value() => Alpha_2;
    public float GetBeta1Value() => Beta_1;
    public float GetBeta2Value() => Beta_2;
    public float GetGamma1Value() => Gamma_1;
    public float GetGamma2Value() => Gamma_2;
    public float GetDeltaValue() => Delta;
    public float GetThetaValue() => Theta;

    // Método para reconectar al dispositivo ThinkGear en caso de desconexión.
    public void ReconnectToThinkGear()
    {
        if (connectionID >= 0)
        {
            // Libera la conexión actual.
            ThinkGear.TG_FreeConnection(connectionID);
            Debug.Log("Desconectado de ThinkGear para reiniciar la conexión.");
        }

        // Intenta reconectar después de un breve retraso.
        Invoke("ConnectToThinkGear", 2.0f);
    }
}
