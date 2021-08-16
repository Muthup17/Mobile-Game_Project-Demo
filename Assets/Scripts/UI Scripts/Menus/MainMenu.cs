using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using SampleGame;

namespace LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {

        [SerializeField] TMP_Text gamePointsText;
        [SerializeField] Text navigationSignText;
        [SerializeField] PowerUp signPower;
        public void OnDungeon1_LevelMenuPressed()
        {
            Dungeon1_LevelMenu.Instance.OnOpen();
        }
        private void OnEnable()
        {
            StartCoroutine(WaitAndCall());
        }
        IEnumerator WaitAndCall()
        {
            yield return null;
            UpdateGamePointUI(GamePointsManager.Instance.GamePoints);
            UpdateNavigationSignCountUI(signPower.currentPowerUpCount);
        }
        public void OnCreditsPressed()
        {
            CreditsScreen.Open();
        }

        public override void OnBackPressed()
        {
            Application.Quit();
        }

        public void UpdateGamePointUI(int point)
        {
            gamePointsText.text = point.ToString();
        }
        public void UpdateNavigationSignCountUI(int count)
        {
            navigationSignText.text = count.ToString();
        }
    }
}