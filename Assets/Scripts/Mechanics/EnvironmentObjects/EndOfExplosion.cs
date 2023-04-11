using UnityEngine;

public class EndOfExplosion : MonoBehaviour
{
    [SerializeField] GameObject explosion; 

   public void OnEndExplosionAnimation()
    {
        Destroy(explosion);
    }

    public void DisableForceMagnitude()
    {
        GetComponent<PointEffector2D>().forceMagnitude = 0;
    }
}
