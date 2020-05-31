using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class LoginForm : MonoBehaviour
{
    [SerializeField] private TMP_InputField _username = null;
    [SerializeField] private TextMeshProUGUI _feedBackText = null;
    [SerializeField] private int _minCharacters = 6;

    public FormEvent onSubmitForm;

    private void Start()
    {
        _feedBackText.text = "";
    }

    public void Submit()
    {
        if (_username.text.Length >= _minCharacters)
        {
            onSubmitForm?.Invoke(_username.text);
        }
        else
        {
            //Develop a validation system with interfaces?
            _feedBackText.text = "Username is too short (6-16)!";
        }
    }
}

[System.Serializable]
public class FormEvent : UnityEvent<string>
{

}
