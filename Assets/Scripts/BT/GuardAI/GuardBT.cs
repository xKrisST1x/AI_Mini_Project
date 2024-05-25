using BehaviourTree;
using System.Collections.Generic;

public class GuardBT : Tree1
{
    // Kommet til xxxx https://www.youtube.com/watch?v=aR6wt5BlE-E&ab_channel=MinaP%C3%AAcheux

    public UnityEngine.Transform[] waypoints;

    public static float speed = 2f;
    public static float fovRange = 6f;
    public static float attackRange = 1f;

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