using System;
using UnityEngine;

namespace BonusFeatures._Scripts
{
    public class Projectile : MonoBehaviour
    {
        // Reference to the ScoreManager script.
        [SerializeField] private ScoreManager scoreManager;

        private void Start()
        {
            // Find the ScoreManager script.
            scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        }
        
        // Increase the score when the projectile collides with an animal.
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Animal"))
            {
                scoreManager.IncreaseScore(5);
            }
        }
    }
}