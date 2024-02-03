using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UserAuth : MonoBehaviour
{
    public Button registerButton;
    public Button loginButton;
    public TMP_InputField registerUsernameField;
    public TMP_InputField registerPasswordField;
    public TMP_InputField loginUsernameField;
    public TMP_InputField loginPasswordField;
    public TMP_Text messageText;
   
    private string rootDirectory;

    private void Awake()
    {
        rootDirectory = Application.persistentDataPath + "/Users/";
    }

    private void Start()
    {
        registerButton.onClick.AddListener(RegisterButtonOnClick);
        loginButton.onClick.AddListener(LoginButtonOnClick);
    }

    private bool RegisterUser(string username, string password)
    {
        string userDirectory = rootDirectory + username;

        if (Directory.Exists(userDirectory)) return false;

        Directory.CreateDirectory(userDirectory);
        File.WriteAllText(userDirectory + "/auth.csv", password);

        return true;
    }

    private bool LoginUser(string username, string password)
    {
        string userDirectory = rootDirectory + username;

        if (!Directory.Exists(userDirectory)) return false;

        string savedPassword = File.ReadAllText(userDirectory + "/auth.csv");

        if (savedPassword == password) return true;

        return false;
    }

    private void RegisterButtonOnClick()
    {
        string username = registerUsernameField.text;
        string password = registerPasswordField.text;

        if (RegisterUser(username, password))
        {
            messageText.text = "User registered successfully";

            if (LoginUser(username, password))
            {
                UserSession.Instance.LoginUser(username);
                SceneManager.LoadScene(1);
                
                
            }
        }
        else
        {
            messageText.text = "User already exists";
        }
    }

    private void LoginButtonOnClick()
    {
        string username = loginUsernameField.text;
        string password = loginPasswordField.text;

        if (LoginUser(username, password))
        {
            UserSession.Instance.LoginUser(username);
            messageText.text = "Login successful";
            SceneManager.LoadScene(1);
            
            
        }
        else
        {
            messageText.text = "Invalid username or password";
        }
    }

}
