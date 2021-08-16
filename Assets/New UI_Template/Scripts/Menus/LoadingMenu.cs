using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LevelManagement
{
    public class LoadingMenu : Menu<LoadingMenu>
    {
        [SerializeField] Image filll;
        protected override void Awake()
        {
            base.Awake();
            ResetFillAmount();
        }
        public void ResetFillAmount()
        {
            filll.fillAmount = 0;
        }

        public void StartProgress(string sceneName)
        {
            StartCoroutine(LoadLevelWithProgressBar(sceneName));
        }
        IEnumerator LoadLevelWithProgressBar(string sceneName)
        {
            ResetFillAmount();
            AsyncOperation scene = LevelLoader.LoadLevelAsync(sceneName);
            scene.allowSceneActivation = false;
            while (!scene.isDone)
            {
                Debug.Log("Called");
                filll.fillAmount = Mathf.MoveTowards(filll.fillAmount, scene.progress, 3f * Time.deltaTime);
                if (scene.progress > 0.899f)
                {
                    scene.allowSceneActivation = true;
                }
                yield return null;
            }
            GameMenu.Open();
        }
    }
}