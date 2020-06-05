using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Levels Resource")]
public class GameLevels : ScriptableObject
{
    [SerializeField] public List<ScriptableLevel> _levels = new List<ScriptableLevel>();
}
