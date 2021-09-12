using UnityEngine;

[CreateAssetMenu(fileName = "SubControlConfig", menuName = "Data/SubControlConfig")]
public class SubControlConfigData : ScriptableObject
{
    [Header("Meta")]
    public float ThrottleReactionSpeed = 0.5f;

    [Header("Steering")]
    [SerializeField] public float BankLimit = 35f;
    [SerializeField] public float PitchSensitivity = 2.5f;
    [SerializeField] public float YawSensitivity = 2.5f;
    [SerializeField] public float RollSensitivity = 1f;

    [Header("Inputs")]
    public string StrafeAxis = "Horizontal";
    public string MouseThrottleAxis = "Mouse ScrollWheel";
    public KeyCode IncreaseSpeedKey = KeyCode.W;
    public KeyCode DecreaseSpeedKey = KeyCode.S;
}
