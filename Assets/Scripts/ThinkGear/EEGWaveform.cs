using UnityEngine;
using System.Collections;

public class EEGWaveform : MonoBehaviour
{
     public BrainwaveController brainwaveController;
    public Texture2D[] signalIcons;

    private float indexSignalIcons = 1;
    private bool enableAnimation = false;
    private float animationInterval = 0.06f;

    ThinkGearController controller;

    //Tommy add 20161020
    private bool showListViewFlag = false;
    private ArrayList deviceList;
    private ArrayList displayedStrArr;
    Vector2 scrollPosition;
    Rect windowRect;

    float rectX = 0;
    float rectY = 0;
    float rectWidth = 0;
    float rectHeight = 0;

    // Use this for initialization
    void Start () {       

        deviceList = new ArrayList();
        displayedStrArr = new ArrayList();
        rectX = Screen.width / 10;
        rectY = Screen.height / 3;
        rectWidth = Screen.width * 8 / 10;
        rectHeight = Screen.height / 4;
    }

    // ... (otros métodos OnUpdateRaw, OnUpdatePoorSignal, etc.)

    void OnGUI(){
        GUILayout.BeginHorizontal();
        GUILayout.Label("Demo App");
        GUILayout.Space(Screen.width-250);
        GUILayout.Label(signalIcons[(int)indexSignalIcons]);
        GUILayout.EndHorizontal();

        // Mostrar información sobre las señales del EEG en la interfaz aquí
        GUILayout.BeginVertical();
        GUILayout.Label("Raw:" + brainwaveController.GetRawValue());
        GUILayout.Label("PoorSignal:" + brainwaveController.GetPoorSignalValue());
        GUILayout.Label("Attention:" + brainwaveController.GetAttentionValue());
        GUILayout.Label("Meditation:" + brainwaveController.GetMeditationValue());
        GUILayout.Label("Delta:" + brainwaveController.GetDeltaValue());
        GUILayout.Label("Theta:" + brainwaveController.GetThetaValue());
        GUILayout.Label("LowAlpha:" + brainwaveController.GetAlpha1Value());
        GUILayout.Label("HighAlpha:" + brainwaveController.GetAlpha2Value());
        GUILayout.Label("LowBeta:" + brainwaveController.GetBeta1Value());
        GUILayout.Label("HighBeta:" + brainwaveController.GetBeta2Value());
        GUILayout.Label("LowGamma:" + brainwaveController.GetGamma1Value());
        GUILayout.Label("HighGamma:" + brainwaveController.GetGamma2Value());
        GUILayout.EndVertical();
    }

    // ... (otros métodos OnAlgo_UpdateXXXEvent, Add2DeviceListArray, clearDataArr, etc.)
}

