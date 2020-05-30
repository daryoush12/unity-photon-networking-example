using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FormHandler : MonoBehaviour
{
    [SerializeField] private InputField _username = null;
    [SerializeField] private Text _feedBackText = null;
    [SerializeField] private int _minCharacters = 6;

    public FormEvent onSubmitForm;

    private void Start()
    {
        _feedBackText.text = "";
    }

    public void Submit()
    {
        if(_username.text.Length >= _minCharacters)
        {
            onSubmitForm?.Invoke(_username.text);
            _feedBackText.text = "Connecting...";
        }
        else
        {
            _feedBackText.text = "Not enough characters in given username!";
        }
    }
}

[System.Serializable]
public class FormEvent : UnityEvent<string>
{

}
