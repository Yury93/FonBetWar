using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorGun : MonoBehaviour
{
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        
            transform.Rotate(0, 0, speed * Time.deltaTime);
            
    }
}
