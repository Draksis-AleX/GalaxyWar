using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        if(GameManager.Instance.localData == true) Save();
    }

    public void Save()
    {
        SaveManager.Instance.save();
        Debug.Log("Checkpoint Saving");
    }
}
