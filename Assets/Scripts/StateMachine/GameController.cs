using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public InputBroadcaster Input { get; private set; }

    [SerializeField] public GameObject player1winPanel;
    [SerializeField] public GameObject player2winPanel;
    [SerializeField] public GameObject drawPanel;

    private void Awake()
    {
        Input = this.GetComponent<InputBroadcaster>();
    }
}
