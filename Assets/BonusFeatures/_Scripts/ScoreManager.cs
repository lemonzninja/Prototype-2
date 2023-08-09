using TMPro;
using UnityEngine;

namespace BonusFeatures._Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private int _score;
        
        private void Start()
        {
            _score = 0;
            UpdateScore();
        }
        
        public void IncreaseScore(int increaseAmount)
        {
            _score += increaseAmount;
            UpdateScore();
        }
	
        void UpdateScore()
        {
            scoreText.text = "Score: " + _score.ToString();
        }
    }
}