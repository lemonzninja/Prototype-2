using System;
using UnityEngine;

namespace BonusFeatures._Scripts
{
    public class Player : MonoBehaviour
    {
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Animal")
            {
                
            }
        }
    }
}