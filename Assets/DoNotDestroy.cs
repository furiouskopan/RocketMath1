using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Music");
        // if(musicObj.Length != 0)
        // {
        //     Destroy(this.gameObject);
        // }
        DontDestroyOnLoad(this.gameObject);
    }
}
