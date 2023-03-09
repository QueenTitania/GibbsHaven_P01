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

    public void PlayAudio(AudioClip clip)
    {
        GetComponent<AudioHelper>().PlayClip2D(clip, 1f);
    }
}
