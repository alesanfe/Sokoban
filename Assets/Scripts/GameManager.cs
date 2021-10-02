using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Target> targets;
    public int isFinished;

    public void Update()
    {
        isFinished = 0;
        foreach (var target in targets) isFinished += target.onTarget;
        if (targets.Count == isFinished) print("Fin");
    }
}
