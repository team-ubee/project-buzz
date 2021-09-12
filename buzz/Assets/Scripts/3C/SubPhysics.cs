using UnityEngine;

// Thanks to brihernandez/FreelancerFlightExample
public class SubPhysics : MonoBehaviour
{
    public Vector3 LinearForce = new Vector3(100.0f, 100.0f, 100.0f);
    public Vector3 AngularForce = new Vector3(100.0f, 100.0f, 100.0f);

    [Range(0.0f, 1.0f)]
    public float ReverseMultiplier = 1.0f;

    public float GlobalMultiplier = 100.0f;

    public Rigidbody Rigidbody { get; private set; }

    private Vector3 _AppliedLinearForce = Vector3.zero;
    private Vector3 _AppliedAngularForce = Vector3.zero;

    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        if (Rigidbody == null)
        {
            throw new System.Exception(name + ": ShipPhysics has no rigidbody.");
        }
    }

    private void FixedUpdate()
    {
        if (Rigidbody != null)
        {
            Rigidbody.AddRelativeForce(_AppliedLinearForce * GlobalMultiplier, ForceMode.Force);
            Rigidbody.AddRelativeTorque(_AppliedAngularForce * GlobalMultiplier, ForceMode.Force);
        }
    }

    public void SetPhysicsInput(Vector3 linearInput, Vector3 angularInput)
    {
        _AppliedLinearForce = Vector3.Scale(LinearForce, linearInput);
        _AppliedAngularForce = Vector3.Scale(AngularForce, angularInput);
    }
}
