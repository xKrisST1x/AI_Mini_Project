using BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskGoToTarget : Node
{
    private Transform _transform;
    
    public TaskGoToTarget(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if(Vector3.Distance(_transform.position, target.position) > GuardBT.attackRange)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, target.position, GuardBT.speed * Time.deltaTime);
            _transform.LookAt(target.position);

            state = NodeState.RUNNING;
        } else
        {
            state = NodeState.SUCCESS;
        }

        
        return state;
    }

}
