using UnityEngine;
using TMPro;
using System;

public class KeyboardManager : MonoBehaviour
{
    public TMP_InputField registerUsernameField;
    public TMP_InputField registerPasswordField;
    public TMP_InputField loginUsernameField;
    public TMP_InputField loginPasswordField;

    private TouchScreenKeyboard keyboard;

    private void OnEnable()
    {
        registerUsernameField.onSelect.AddListener(ShowKeyboard);
        registerPasswordField.onSelect.AddListener(ShowKeyboard);
        loginUsernameField.onSelect.AddListener(ShowKeyboard);
        loginPasswordField.onSelect.AddListener(ShowKeyboard);
    }

    private void OnDisable()
    {
        registerUsernameField.onSelect.RemoveListener(ShowKeyboard);
        registerPasswordField.onSelect.RemoveListener(ShowKeyboard);
        loginUsernameField.onSelect.RemoveListener(ShowKeyboard);
        loginPasswordField.onSelect.RemoveListener(ShowKeyboard);
    }

    private void ShowKeyboard(string arg0)
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}