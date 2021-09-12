using UnityEngine;

// Thanks to brihernandez/FreelancerFlightExample
public class CameraRig : MonoBehaviour
{
    [Header("Rigs and Targets")]
    [SerializeField] private Transform _Sub = null;
    [SerializeField] private Camera _Cam = null;
    [SerializeField] private Transform _LookAheadRig = null;

    [SerializeField] private float _SmoothSpeed = 10f;

    [Header("Lookahead Values")]
    [SerializeField] private float _HorizontalTurnAngle = 15f;
    [SerializeField] private float _VerticalTurnUpAngle = 5.0f;
    [SerializeField] private float _VerticalTurnDownAngle = 15.0f;

    const float SPEED_SLOPE = 0.0002f;

    private void Update()
    {
            MoveCamera();
    }

    private void FixedUpdate()
    {
            MoveCamera();
    }

    private void MoveCamera()
    {
        if (_Sub == null)
            return;

        transform.position = _Sub.position;

        var targetRigRotation = Quaternion.LookRotation(_Sub.forward, transform.up);
        transform.rotation = SmoothDamp.Apply(transform.rotation, targetRigRotation, _SmoothSpeed, Time.deltaTime);

        RotateRigAndCameraForLookahead();
    }

    private void RotateRigAndCameraForLookahead()
    {
        var mousePos = Input.mousePosition;

        var mouseScreenX = (mousePos.x - (Screen.width * 0.5f)) / (Screen.width * 0.5f);
        var mouseScreenY = -(mousePos.y - (Screen.height * 0.5f)) / (Screen.height * 0.5f);

        mouseScreenX = Mathf.Clamp(mouseScreenX, -1f, 1f);
        mouseScreenY = Mathf.Clamp(mouseScreenY, -1f, 1f);

        float horizontal = 0f;
        float vertical = 0f;
        horizontal = _HorizontalTurnAngle * mouseScreenX;
        vertical = (mouseScreenY < 0.0f) ? _VerticalTurnUpAngle * mouseScreenY : _VerticalTurnDownAngle * mouseScreenY;

        _LookAheadRig.localRotation = SmoothDamp.Apply(_LookAheadRig.localRotation, Quaternion.Euler(-vertical, -horizontal, 0f), _SmoothSpeed, Time.deltaTime);

        Vector3 lookaheadPosition = _Sub.transform.TransformPoint(Vector3.forward * 100f);
        _Cam.transform.rotation = Quaternion.LookRotation(lookaheadPosition - _LookAheadRig.position, _LookAheadRig.up);
    }
}
