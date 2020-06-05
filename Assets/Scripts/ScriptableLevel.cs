using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "New Level")]
[System.Serializable]
public class ScriptableLevel : ScriptableObject
{
    public string _name;
    public int _sceneIndex;
    public Sprite _levelBanner;
}
