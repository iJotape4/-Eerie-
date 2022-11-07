using UnityEngine;

public class WaterJetController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer != 9 )      
            Destroy(this.gameObject);             
    }
}
