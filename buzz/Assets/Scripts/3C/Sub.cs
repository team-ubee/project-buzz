using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SubPhysics))]
[RequireComponent(typeof(SubInput))]

// Thanks to brihernandez/FreelancerFlightExample

public class Sub : MonoBehaviour
{
    public static Sub Player { get; private set; }
    public Vector3 Velocity { get { return Physics.Rigidbody.velocity; } }

    public SubInput Input { get; private set; }
    public SubPhysics Physics { get; internal set; }

    private void Awake()
    {
        Input = GetComponent<SubInput>();
        Physics = GetComponent<SubPhysics>();
        Player = this;
    }

    private void Update()
    {
        Physics.SetPhysicsInput(
            new Vector3(Input.Strafe, 0.0f, Input.Throttle), 
            new Vector3(Input.Pitch, Input.Yaw, Input.Roll));
    }
}
