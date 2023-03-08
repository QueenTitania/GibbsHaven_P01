using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Counter : MonoBehaviour
{
    public int playerCount;
    public System.Action counterUpdate;
    [SerializeField] public Text counterText;

    public bool doneCounting = false;

    public void CounterUpdate()
    {
        counterUpdate?.Invoke();
    }

    public void AddCount()
    {
        playerCount++;
        CounterUpdate();
        Debug.Log(playerCount);
    }

    public void SubtractCount()
    {
        if(playerCount > 0)
            playerCount--;
        CounterUpdate();
        //Debug.Log(playerCount);
    }

    public void CompleteCounting()
    {
        doneCounting = true;
    }

}
