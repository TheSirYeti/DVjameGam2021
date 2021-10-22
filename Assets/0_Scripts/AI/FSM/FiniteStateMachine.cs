using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    IState _currentState = new NullState();
    Dictionary<MachineState, IState> _allStates = new Dictionary<MachineState, IState>();


    public void OnUpdate()
    {
        _currentState.OnUpdate();
    }

    public void AddState(MachineState id, IState state)
    {
        if (_allStates.ContainsKey(id)) return;

        _allStates.Add(id, state);
    }

    public void ChangeState(MachineState id)
    {
        if (!_allStates.ContainsKey(id)) return;
        _currentState.OnExit();
        _currentState = _allStates[id]; 
        _currentState.OnStart();
    }
}

public enum MachineState
{
    CHASE,
    IDLE
}
