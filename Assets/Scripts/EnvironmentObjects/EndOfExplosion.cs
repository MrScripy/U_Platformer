using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfExplosion : MonoBehaviour
{
    [SerializeField] GameObject explosion; 
   public void OnEndExplosionAnimation()
    {
        Destroy(explosion);
    }
}
