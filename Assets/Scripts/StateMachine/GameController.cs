using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [field: SerializeField] public InputBroadcaster Input { get; private set; }
}
