
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public void Awake()
    {
        Instance = this;

/*        foreach(var piece in Pieces)
        {
            if (piece.Prefab.transform.Find("Pivot Next") == null)
            {
                Debug.LogError("Object has to have a transform called 'Pivot Next' within.");
            }

            // this.gameObject.GetComponent<Animator>().SetTrigger("playerHasSelectedAStory");
        }*/
    }

    private Vector3 _CurrentPosition = Vector3.zero;
  
    public void Generate(GameObject[] pieces, GameObject[] storyElements, int depth)
    {
        // todo: izaberi random story (ili dva)
        // todo: izgenerisi prvih X soba (LOD fazon)

        for (int i = 0; i < depth; i++)
        {
            var piece = pieces[Random.Range(0, pieces.Length)];
            var nextPart = GameObject.Instantiate(piece, _CurrentPosition, Quaternion.identity) as GameObject;
            // TODO: nextPart can now be decorated additionally here
            //      so that it gets attached to triggers, other smaller pieces,
            //      light emitters, etc.

            // nextPart.transform.Find("Hole 1").gameObject

            _CurrentPosition += piece.transform.Find("Pivot Next").transform.localPosition;
        }
    }
}

