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
            _lives = 3;
UpdateLives();
        }

        public void DecreaseLives()
        {
            _lives -= 1;   
        }

        private void UpdateLives()
        {
            livesText.text = "Lives: " + _lives.ToString();
        }
    }
}