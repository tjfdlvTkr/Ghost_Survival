using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public float damage =10;
    public int per = 0;
    public float speed =150;
    private float moveSpeed = 10;
   
    void Start()
    {
        Destroy(gameObject,3f);
       
    }
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                break;
                   
        }
    }
    
}
