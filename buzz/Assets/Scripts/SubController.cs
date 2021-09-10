using UnityEngine;

public class SubController : MonoBehaviour
{
    public SubControlConfigData ControllerConfig;

    public void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * ControllerConfig.HorizontalSpeed;
        var vertical = Input.GetAxis("Vertical") * ControllerConfig.VerticalSpeed;
        var pitch = Input.GetAxis("Pitch") * ControllerConfig.PitchSpeed;
        // todo: add inertia

        var quat = new Vector3(vertical, horizontal, pitch) * Time.smoothDeltaTime;
        this.transform.Rotate(quat);

        var isMoving = Input.GetButton("Engine");
        if (isMoving)
        {
            transform.Translate(0, 0, ControllerConfig.MovementSpeed * Time.smoothDeltaTime, Space.Self);
        }
    }
}
