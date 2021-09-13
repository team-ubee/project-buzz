using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFollower : MonoBehaviour
{
    public PathCreator PathCreator;
    public EndOfPathInstruction EndStrategy = EndOfPathInstruction.Stop;
    public float Speed = 1.0f;

    private float _DstTravelled;

    void Update()
    {
        _DstTravelled += Speed * Time.deltaTime;
        transform.position = PathCreator.path.GetPointAtDistance(_DstTravelled, EndStrategy);
        transform.rotation = PathCreator.path.GetRotationAtDistance(_DstTravelled, EndStrategy);

        if (Vector3.Distance(transform.position, PathCreator.path.GetPointAtTime(1.0f, EndStrategy)) < 1.0f)
        {
            if (EndStrategy == EndOfPathInstruction.Stop)
                DestroyImmediate(this.gameObject);
        }
    }
}
