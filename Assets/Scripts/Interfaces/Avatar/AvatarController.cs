using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Checks the _animator for any Trigger parameters, then creates buttons that trigger each in UI.
/// Add this script to a UI object with a Layout component.
/// </summary>
public class AvatarController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Button _buttonPrefab;

    private void Start()
    {
        // Find all parameters in the Animator
        foreach (var parameter in _animator.parameters)
        {
            // If it's a Trigger, create a button for it
            if (parameter.type == AnimatorControllerParameterType.Trigger)
                AddButton(parameter);
        }
    }

    private void AddButton(AnimatorControllerParameter parameter)
    {
        // Create a new button
        var button = Instantiate(_buttonPrefab, transform);
        // Set the button text to the trigger name
        foreach (var tmpText in button.GetComponentsInChildren<TMP_Text>())
        {
            tmpText.text = parameter.name;
        }
        // Set the button's click behaviour
        button.onClick.AddListener(() => _animator.SetTrigger(parameter.nameHash));
    }
}
