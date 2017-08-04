using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour
{
    public float speed = 10f;

    public int x = 0;
    public int y = 1;
    public int z = 0;
    
    
    void Update () 
    {
        transform.Rotate (new Vector3(x, y, z) * Time.deltaTime * speed);
    }
}