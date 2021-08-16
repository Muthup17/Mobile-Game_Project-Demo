using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace LevelManagement
{
    public class WinScreen : Menu<WinScreen>
    {
        [SerializeField] PlayerLevelPoints levelPoints;
        [SerializeField] Text blueDiamonds;
        [SerializeField] Text greenDiamonds;
        [SerializeField] Text pinkDiamonds;
        [SerializeField] Text redDiamonds;
        [SerializeField] Text currentGameLevelPoints;

        private void OnEnable()
        {
            if (levelPoints == null)
            {
                levelPoints = Object.FindObjectOfType<PlayerLevelPoints>();
            }
            currentGameLevelPoints.text = 0.ToString();
            SetDiamondValues();
            UpdateGamePoints();
        }
        void SetDiamondValues()
        {
            if(levelPoints != null && levelPoints.BlueDiamonds != null)
            {
                blueDiamonds.text = levelPoints.BlueDiamonds.Count.ToString();
                greenDiamonds.text = levelPoints.GreenDiamonds.Count.ToString();
                pinkDiamonds.text = levelPoints.PinkDiamonds.Count.ToString();
                redDiamonds.text = levelPoints.GoldCoins.Count.ToString();
            }
        }
        void UpdateGamePoints()
        {
            if(GamePointsManager.Instance != null && levelPoints != null)
            {
                int totalLevelPoints = levelPoints.CalculateGamePoints();
                currentGameLevelPoints.text = totalLevelPoints.ToString();
                GamePointsManager.Instance.AddGamePoint(totalLevelPoints);
            }
        }
        public void OnNextLevelPressed()
        {
            base.OnBackPressed();
            LevelLoader.LoadNextLevel();
        }

        public void OnRestartPressed()
        {
            base.OnBackPressed();
            LevelLoader.ReloadLevel();
        }

        public void OnMainMenuPressed()
        {
            LevelLoader.LoadMainMenuLevel();
            MainMenu.Open();
        }
    }
}
