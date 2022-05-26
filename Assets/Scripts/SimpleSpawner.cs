using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    // Local rigidbody variable to hold a reference to the attached Rigidbody2D component
    public static T Spawner<T>(Vector3 position, T prefab) where T : Object => Instantiate(prefab, position, Quaternion.identity);       

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
