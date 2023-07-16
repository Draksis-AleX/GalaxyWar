using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Save());
    }

    public IEnumerator Save()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Checkpoint Saving");
        SaveManager.Instance.save();
    }
}
