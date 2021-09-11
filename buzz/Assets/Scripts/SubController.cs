using UnityEngine;

public class SubController : MonoBehaviour
{
    public SubControlConfigData ControllerConfig;
    private Rigidbody _Rigidbody;

    public void Start()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal") * ControllerConfig.HorizontalSpeed;
        var vertical = Input.GetAxis("Vertical") * ControllerConfig.VerticalSpeed;
        var pitch = Input.GetAxis("Pitch") * ControllerConfig.PitchSpeed;
        // todo: add inertia

        var quat = new Vector3(vertical, horizontal, pitch) * Time.smoothDeltaTime;
        _Rigidbody.AddTorque(quat, ForceMode.Acceleration);

        var isMoving = Input.GetButton("Engine");
        if (isMoving)
        {
//            transform.Translate(0, 0, ControllerConfig.MovementSpeed * Time.smoothDeltaTime, Space.Self);
            _Rigidbody.AddRelativeForce(0, 0, ControllerConfig.MovementSpeed * Time.smoothDeltaTime);
        }
    }
}
