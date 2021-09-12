
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] Pieces;
    public int Depth;

    public void Awake()
    {
        foreach(var piece in Pieces)
        {
            if (piece.transform.Find("Pivot Next") == null)
            {
                throw new System.Exception("Object has to have a transform called 'Pivot Next' within.");
            }
        }
    }

    public void Start()
    {
        Vector3 currentPosition = Vector3.zero;

        for (int i = 0; i < Depth; i++)
        {
            var piece = Pieces[Random.Range(0, Pieces.Length)];
            var nextPart = Instantiate(piece, currentPosition, Quaternion.identity) as GameObject;

            // TODO: nextPart can now be decorated additionally here
            //      so that it gets attached to triggers, other smaller pieces,
            //      light emitters, etc.

            currentPosition += piece.transform.Find("Pivot Next").transform.localPosition;
        }
    }
}

