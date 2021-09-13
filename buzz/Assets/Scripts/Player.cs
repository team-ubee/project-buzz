using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public void Awake()
    {
        Instance = this;
    }

    public GameObject SubmarineShell; // NOTE: Miroslav: Mozemo li ovo da spojimo sa podmornicom?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private int Success;
    public int GetSuccessRate() 
    {
        return Success;
    }

    /*
    Definition: Callback for events that adds up score.
    Parameter: Score: the number to be added to success.
    Purpose: Increase success by "score" 
    */
    public void OnSuccessfullAct(int score)
    {
        Success += score;
    }


}
