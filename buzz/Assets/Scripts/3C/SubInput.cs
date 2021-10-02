using UnityEngine;

// Thanks to brihernandez/FreelancerFlightExample
public class SubInput : MonoBehaviour
{
    public SubControlConfigData Config;
    
    [Range(-1, 1)]
    [SerializeField] private float _Pitch;
    [Range(-1, 1)]
    [SerializeField] private float _Yaw;
    [Range(-1, 1)]
    [SerializeField] private float _Roll;
    [Range(-1, 1)]
    [SerializeField] private float _Strafe;
    [Range(0, 1)]
    [SerializeField] private float _Throttle;

    public float Pitch { get { return _Pitch; } }
    public float Yaw { get { return _Yaw; } }
    public float Roll { get { return _Roll; } }
    public float Strafe { get { return _Strafe; } }
    public float Throttle { get { return _Throttle; } }

    private void Update()
    {
        _Strafe = Input.GetAxis(Config.StrafeAxis);

        SetStickCommandsUsingAutopilot();

        UpdateMouseWheelThrottle();
        UpdateKeyboardThrottle(Config.IncreaseSpeedKey, Config.DecreaseSpeedKey);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void SetStickCommandsUsingAutopilot()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 1000f;
        Vector3 gotoPos = Camera.main.ScreenToWorldPoint(mousePos);

        TurnTowardsPoint(gotoPos);
        BankShipRelativeToUpVector(mousePos, Camera.main.transform.up);
    }

    private void BankShipRelativeToUpVector(Vector3 mousePos, Vector3 upVector)
    {
        float bankInfluence = (mousePos.x - (Screen.width * 0.5f)) / (Screen.width * 0.5f);
        bankInfluence = Mathf.Clamp(bankInfluence, -1f, 1f);

        bankInfluence *= _Throttle;
        float bankTarget = bankInfluence * Config.BankLimit;

        float bankError = Vector3.SignedAngle(transform.up, upVector, transform.forward);
        bankError -= bankTarget;
        bankError = Mathf.Clamp(bankError * 0.1f, -1f, 1f);

        _Roll = bankError * Config.RollSensitivity;
    }

    private void TurnTowardsPoint(Vector3 gotoPos)
    {
        Vector3 localGotoPos = transform.InverseTransformVector(gotoPos - transform.position).normalized;
        _Pitch = Mathf.Clamp(-localGotoPos.y * Config.PitchSensitivity, -1f, 1f);
        _Yaw = Mathf.Clamp(localGotoPos.x * Config.YawSensitivity, -1f, 1f);
    }

    private void UpdateKeyboardThrottle(KeyCode increaseKey, KeyCode decreaseKey)
    {
        float target = _Throttle;

        if (Input.GetKey(increaseKey))
            target = 1.0f;
        else if (Input.GetKey(decreaseKey))
            target = 0.0f;

        _Throttle = Mathf.MoveTowards(_Throttle, target, 
            Time.deltaTime * Config.ThrottleReactionSpeed);
    }

    private void UpdateMouseWheelThrottle()
    {
        _Throttle += Input.GetAxis("Mouse ScrollWheel");
        _Throttle = Mathf.Clamp(_Throttle, 0.0f, 1.0f);
    }
}
