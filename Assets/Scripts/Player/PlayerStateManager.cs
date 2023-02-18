using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public Rigidbody rb;

    PlayerBaseState currentState;
    PlayerStateFactory factory;

    public PlayerBaseState CurrentState { get { return currentState; } set { currentState = value; } }

    private void Start()
    {
        
    }

    void Update()
    {
        CurrentState.UpdateState();
    }

    public void Turn(int crrLane, int toLane)
    {
        int Director = toLane - crrLane;
        Debug.Log(Director);
        this.transform.position += this.transform.right * Director * 2f;
    }
}
