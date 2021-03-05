using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHealthPack : MonoBehaviour
{
    public GameObject healthPackPrefab;
    public int numberOfHealthPack = 10;
    public int range = 5;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<numberOfHealthPack;i++)
        {
            GameObject obj = Instantiate(healthPackPrefab) as GameObject;
            obj.transform.position = new Vector3(UnityEngine.Random.Range(-range,range),3,UnityEngine.Random.Range(-range,range));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
