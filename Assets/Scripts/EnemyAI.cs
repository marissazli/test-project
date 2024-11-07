using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform destination;

    AILerp ai;
    // Start is called before the first frame update
    void Awake()
    {
        ai = GetComponent<AILerp>();
    }

    // Update is called once per frame
    void Update()
    {
        ai.destination = destination.position;
    }
}
