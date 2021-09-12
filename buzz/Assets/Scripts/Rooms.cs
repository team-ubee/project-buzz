using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomContainer
{
    [SerializeField]
    public string Name;

    [SerializeField]
    public GameObject[] Rooms;
}

public class Rooms : MonoBehaviour
{
    public static Rooms Instance;

    public void Awake()
    {
        Instance = this;
    }

    public RoomContainer[] Containers;
    private Dictionary<string, GameObject[]> _Containers;

    public void Start()
    {
        _Containers = new Dictionary<string, GameObject[]>();
        foreach (var cnt in Containers)
        {
            _Containers[cnt.Name] = cnt.Rooms;
        }
    }

    public static GameObject[] Get(string name)
    {
        return Instance._Containers[name];
    }
}
