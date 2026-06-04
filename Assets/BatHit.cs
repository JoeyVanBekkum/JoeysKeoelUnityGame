using UnityEngine;

public class BatHit : MonoBehaviour
{

    public Counter counter;


    
      private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " Collision enter");
        if (collision.transform.tag == "Target")
        {
            Debug.Log("hit the target");
            counter.addPoint();
        }
    }
}
