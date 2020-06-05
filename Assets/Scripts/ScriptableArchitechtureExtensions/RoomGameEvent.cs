using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using Photon.Realtime;

[System.Serializable]
[CreateAssetMenu(fileName = "RoomGameEvent", menuName = "Game Events/RoomGameEvent")]
public sealed class RoomGameEvent : GameEventBase<State>
{
  
}
