using UnityEngine;

public class ObjectOfInterest : MonoBehaviour
{
    public int Mystery = 10;

    public void Start()
    {
        Mystery = Random.Range(20, 50);
    }
}
