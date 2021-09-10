using UnityEngine;

[CreateAssetMenu(fileName = "SubControlConfig", menuName = "Data/SubControlConfig")]
public class SubControlConfigData : ScriptableObject
{
    [Header("Turning")]
    public float HorizontalSpeed = 1.0f;
    public float VerticalSpeed = 1.0f;
    public float PitchSpeed = 1.0f;

    [Space]
    [Header("Engine")]
    public float MovementSpeed = 1.0f;

    [Space]
    [Header("Physics")]
    public float Inertia = 0.0f;
}
