using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RandomPositionCube : MonoBehaviour
{

    public GameObject collecttible;
    
    Vector3 position;

    // Start is called before the first frame update

   

    void Start()
    {
        
        int Spawned = 0;
        while (Spawned<9)
        {
           
            position = new Vector3(Random.Range(-20, 24f), 0.5f, Random.Range(9, 30));
            Instantiate(collecttible, position, Quaternion.identity);
            Spawned++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
