using BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChechEnemyInAttackRange : Node
{
   // private static int _enemyLayerMask = 1 << 6;

    private Transform _transform;
    
    public ChechEnemyInAttackRange(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object t = GetData("taget");
        if(t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform target = (Transform)t;
        if(Vector3.Distance(_transform.position, target.position) <= GuardBT.attackRange)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
