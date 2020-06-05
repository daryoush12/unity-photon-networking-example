using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadWantedLevel : MonoBehaviour
{
    [SerializeField] private ScriptableLevel _level;



    public void LoadLevel()
    {
        SceneManager.LoadScene(_level._sceneIndex);
    }
}
