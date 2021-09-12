using UnityEngine;

public static class SmoothDamp
{
    // Thanks to Rory Driscoll
    // http://www.rorydriscoll.com/2016/03/07/frame-rate-independent-damping-using-lerp/

    public static Quaternion Apply(Quaternion a, Quaternion b, float lambda, float dt)
    {
        return Quaternion.Slerp(a, b, 1 - Mathf.Exp(-lambda * dt));
    }
}
