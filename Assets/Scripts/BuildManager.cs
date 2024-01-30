using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject baseTurrentPrefab;
    public static BuildManager instance;
    
    public GameObject[] turrentList;
    public int currentTurrentId = -1;
    
    void Start()
    {
        instance = this;
    }

    public GameObject GetTurrent()
    {
        if (currentTurrentId == -1) return null;
        return turrentList[currentTurrentId];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
