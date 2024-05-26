using BehaviourTree;
using System.Collections.Generic;

public class GuardBT : Tree1
{

    public UnityEngine.Transform[] waypoints;

    public static float speed = 3f;
    public static float fovRange = 6f;
    public static float attackRange = 2f;

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new ChechEnemyInAttackRange(transform),
                new TaskAttack(transform),

            }),
            new Sequence(new List<Node>
            {
                new ChechEnemyInFOVRange(transform),
                new TaskGoToTarget(transform),

            }),
            new TaskPatrol(transform, waypoints),
        });

        return root;
    }

}