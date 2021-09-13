using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class WindPipe : MonoBehaviour
{
    [Range(0, 1000)]
    public float WindForce = 500.0f;

    [Range(0, 100)]
    public float TunnelWidth = 30.0f;

    public GameObject Marker;

    [Range(0, 100)]
    public int Probability = 50;

    private PathCreator _PathCreator;
    private Transform _MarkerPaths;
    private List<GameObject> _Affected = new List<GameObject>();

    private void Start()
    {
        _PathCreator = transform.Find("Path").gameObject.GetComponent<PathCreator>();
        _MarkerPaths = transform.Find("Particle Paths");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() == null) return;

        _Affected.Add(other.gameObject);
        Debug.Log($"Starting affecting {other.gameObject}");
    }

    private void OnTriggerExit(Collider other)
    {
        if (_Affected.Contains(other.gameObject))
        {
            _Affected.Remove(other.gameObject);
            Debug.Log($"Stopped affecting {other.gameObject}");
        }
    }

    void Apply(GameObject movable)
    {
        var pos = movable.transform.position;
        var closest = _PathCreator.path.GetClosestPointOnPath(pos);
        var dist = Vector2.Distance(pos, closest);

        if (dist < TunnelWidth)
        {
            var strength = (TunnelWidth - dist) / TunnelWidth;

            var time = _PathCreator.path.GetClosestTimeOnPath(pos);
            var dir = _PathCreator.path.GetDirection(time, EndOfPathInstruction.Stop).normalized * WindForce * strength;
            var body = movable.GetComponent<Rigidbody>();

            if (body != null)
            {
                Debug.Log($"Moving {body.gameObject.name} by {dir}");
                body.AddForce(dir, ForceMode.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        if (Random.Range(0, 100) < Probability)
        {
            var child = _MarkerPaths.transform.GetChild(Random.Range(0, _MarkerPaths.transform.childCount));
            var pathCreator = child.gameObject.GetComponent<PathCreator>();

            var marker = Instantiate(Marker, pathCreator.path.GetPointAtTime(0.0f), Quaternion.identity);
            var follower = marker.AddComponent<PathFollower>();
            follower.transform.localScale = Vector3.one * Random.Range(0.2f, 1.0f);
            follower.PathCreator = pathCreator;
            follower.EndStrategy = EndOfPathInstruction.Stop;
            follower.Speed = WindForce / 10.0f;
        }

        foreach (var affected in _Affected)
        {
            Apply(affected);
        }
    }
}
