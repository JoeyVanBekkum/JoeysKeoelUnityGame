using UnityEngine;

public class collision_check : MonoBehaviour
{

private void OnTriggerEnter(Collider other)
    { 
        Debug.Log("Object Detected: " + other.name + " at frame:" + Time.frameCount);
    }    
private void OnCollisionEnter(Collision other)
    { 
        Debug.Log("Object Detected: " + other.gameObject.name + " at frame:" + Time.frameCount);
    }    
}
