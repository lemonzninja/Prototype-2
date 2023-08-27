using TMPro;
using UnityEngine;

namespace BonusFeatures._Scripts
{
    public class LivesManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI livesText;
        [SerializeField] private int _lives; 
	
        private void Start()
        {
            // Set the lives to 3.
            _lives = 3;
            
            // Update the lives text.
            UpdateLives();
        }

        public void DecreaseLives()
        {
            // Decrease the lives by 1.
            _lives -= 1;
            
            // Update the lives text.
            UpdateLives();
        }

        private void UpdateLives()
        {
            // The lives text is equal to "Lives: " + the lives.
            livesText.text = "Lives: " + _lives.ToString();
        }
    }
}