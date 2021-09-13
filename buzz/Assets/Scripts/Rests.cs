using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RestItem
{
    /*
    Definition: Name of the RestItem.
    Purpose: Used only for better understandig what is data that is used (readability).
    */
    [SerializeField]
    public string Name;

    /*
    Definition: Count how much one rest item has to be randomly choosen to be actuely picked.
    Purpose: It will be used in case we managed to make much more "stories" then 
    there is rest items to cover the part after "finish".
    In that case, we can repeat the one with taking into account how many times it
    already has been used. The more it was used, the harder it will be to be used again.
    */
    public int Count; // NOTE: Miroslav: Mozemo li da podesimo ovo polje da bude nevidljivo iz unity-a?

    /*
    Definition: The data.
    Purpose: This is what will actualy be pleaced in the "room".
    */
    [SerializeField]
    public GameObject RestData;

    /*
    Definition: LevelOfSuccess describes for what amount of success the rest 
    item is suitable for. 
    Purpuse: According to calculated player's success we can get
    suitable rest rooms decoration.
    Example: Lets say player bearly stayed alive in "finish" room,
    then the levelOfSuccess is low, and designers may be wanting to 
    to use some sad music. 
    Lets say that the player was extremly succesfull, collected everything
    and killed every enemy, then designers may want to rest with some joyfull 
    rest items.
    */
    [SerializeField] 
    public int LevelOfSuccess; // NOTE: Miroslav: Je l mozemo ovo da podesimo izmedju 1 i 3?
}

public class Rests : MonoBehaviour
{
    public static Rests Instance;

    public void Awake()
    {
        Instance = this;
    }

    public RestItem[] DecorationForRest;
    public RestItem[] SoundForRest;

    public void Start()
    {
       
    }

    public static GameObject GetMusic(int success)
    {
        // pick suitable items
        List<RestItem> suitableItems = new List<RestItem>();
        foreach (var ri in Instance.SoundForRest)
        {
            if (ri.LevelOfSuccess == success)
                suitableItems.Add(ri);
        }

        // A: choose one random
        // var index = Random.Range(0, suitableItems.Length);

        // B: choose according to count
        int index = -1;
        while (index == -1)
        {
            var maybeIndex = Random.Range(0, suitableItems.Count);
            if (suitableItems[maybeIndex].Count == 0)
            {
                index = maybeIndex;
                suitableItems[maybeIndex].Count++;
            }
            else
            {
                suitableItems[maybeIndex].Count--;
            }
        }

        return suitableItems[index].RestData;
    }

    public static GameObject GetDecoration(int success)
    {
        // pick suitable items
        List<RestItem> suitableItems = new List<RestItem>();
        foreach (var ri in Instance.DecorationForRest)
        {
            if (ri.LevelOfSuccess == success)
                suitableItems.Add(ri);
        }

        // choose one random
        // var index = Random.Range(0, suitableItems.Length);

        // choose according to count
        int index = -1;
        while (index == -1)
        {
            var maybeIndex = Random.Range(0, suitableItems.Count);
            if (suitableItems[maybeIndex].Count == 0)
            {
                index = maybeIndex;
                suitableItems[maybeIndex].Count++;
            }
            else
            {
                suitableItems[maybeIndex].Count--;
            }
        }

        return suitableItems[index].RestData;
    }
}
