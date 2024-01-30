using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject baseTurrentPrefab;
    public static BuildManager instance;
    void Start()
    {
        instance = this;
    }

    public GameObject GetTurrent()
    {
        return baseTurrentPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
