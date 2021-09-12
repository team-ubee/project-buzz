using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public static void Trigger(string trigger)
    {
        Instance.GetComponent<Animator>().SetTrigger(trigger);
    }

    public void Awake()
    {
        Instance = this;
    }
}
