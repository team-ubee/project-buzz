using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    [SerializeField]
    public Vector3 RotationVelocity;

    void FixedUpdate()
    {
        this.transform.Rotate(RotationVelocity * Time.fixedDeltaTime);
    }
}
