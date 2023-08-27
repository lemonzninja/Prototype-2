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
            if (other.gameObject.tag == "Animal")
            {
                livesManager.DecreaseLives();
                Destroy(other.gameObject);
            }
        }
    }
}