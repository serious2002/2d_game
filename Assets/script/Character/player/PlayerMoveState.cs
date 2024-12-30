using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveState : IState
{
    public StateGraph graph => throw new NotImplementedException();

    public bool isStart { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool canBeSource => throw new NotImplementedException();

    public bool canBeDestination => throw new NotImplementedException();

    public IEnumerable<IStateTransition> outgoingTransitions => throw new NotImplementedException();

    public IEnumerable<IStateTransition> incomingTransitions => throw new NotImplementedException();

    public IEnumerable<IStateTransition> transitions => throw new NotImplementedException();

    public Vector2 position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public float width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public int dependencyOrder => throw new NotImplementedException();

    public Guid guid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public IEnumerable<ISerializationDependency> deserializationDependencies => throw new NotImplementedException();

    IGraph IGraphElement.graph { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    IGraph IGraphItem.graph => throw new NotImplementedException();

    Guid IIdentifiable.guid => throw new NotImplementedException();

    public void AfterAdd()
    {
        throw new NotImplementedException();
    }

    public void AfterRemove()
    {
        throw new NotImplementedException();
    }

    public void BeforeAdd()
    {
        throw new NotImplementedException();
    }

    public void BeforeRemove()
    {
        throw new NotImplementedException();
    }

    public IGraphElementData CreateData()
    {
        throw new NotImplementedException();
    }

    public IGraphElementDebugData CreateDebugData()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public AnalyticsIdentifier GetAnalyticsIdentifier()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<object> GetAotStubs(HashSet<object> visited)
    {
        throw new NotImplementedException();
    }

    public bool HandleDependencies()
    {
        throw new NotImplementedException();
    }

    public void Instantiate(GraphReference instance)
    {
        throw new NotImplementedException();
    }

    public void OnBranchTo(Flow flow, IState destination)
    {
        throw new NotImplementedException();
    }

    public void OnEnter(Flow flow, StateEnterReason reason)
    {
        throw new NotImplementedException();
    }

    public void OnExit(Flow flow, StateExitReason reason)
    {
        throw new NotImplementedException();
    }

    public void Prewarm()
    {
        throw new NotImplementedException();
    }

    public void Uninstantiate(GraphReference instance)
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
