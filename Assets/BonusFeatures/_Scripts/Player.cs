using System;
using UnityEngine;

namespace BonusFeatures._Scripts
{
    public class Player : MonoBehaviour
    {
        // Reference to the LivesManager script.
        [SerializeField] private LivesManager livesManager;

        private void Start()
        {
            // Find the LivesManager script.
            livesManager = GameObject.Find("LivesManager").GetComponent<LivesManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            /*
             *  - If the player collides with an animal, decrease the lives by 1.
             */
            
            if (other.gameObject.tag == "Animal")
            {
                // Decrease the lives by 1.
                livesManager.DecreaseLives();
                
                // Destroy the animal.
                Destroy(other.gameObject);
            }
        }
    }
}