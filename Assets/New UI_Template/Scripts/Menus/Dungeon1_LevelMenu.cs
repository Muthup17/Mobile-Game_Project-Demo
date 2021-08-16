using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using LevelManagement.Missions;
using System.Threading.Tasks;

namespace LevelManagement
{
    public class Dungeon1_LevelMenu : Menu<Dungeon1_LevelMenu>
    {
        [SerializeField] float slideAnimationDuration;
        [SerializeField] GameObject contents;
        [SerializeField] Text gamePoint;

        MissionSelector missionSelector;
        MissionSpecs currentMission;

        [SerializeField] protected Text _nameText;
        [SerializeField] protected Text _descriptionText;
        [SerializeField] protected Image _previewImage;

        [SerializeField] protected float _playDelay = 0.5f;
        [SerializeField] protected TransitionFader _playTransitionPrefab;

        [SerializeField] GameObject PowerUpContainer;

        protected override void Awake()
        {
            base.Awake();
            missionSelector = GetComponent<MissionSelector>();
            UpdateInfo();
        }

        private void OnEnable()
        {
            UpdateInfo();
            UpdateGamePoint(GamePointsManager.Instance.GamePoints);
        }
        public override void OnBackPressed()
        {
            StartCoroutine(MenuManager.Instance.CloseMenuWithAnimation(slideAnimationDuration));
            SlideClose();
        }

        public void OnOpen()
        {
            MenuManager.Instance.OpenMenuWithAnimationPart1(Instance);
            StartCoroutine(OpenWithAnimation(Instance));
        }
        void SlideOpen()
        {
            contents.transform.DOLocalMoveX(0, slideAnimationDuration);
        }
        void SlideClose()
        {
            contents.transform.DOLocalMoveX(-2300, slideAnimationDuration);
        }

        IEnumerator OpenWithAnimation(Menu instance)
        {
            SlideOpen();
            yield return new WaitForSeconds(slideAnimationDuration);
            MenuManager.Instance.OpenMenuWithAnimationPart2(instance);
        }
        public void UpdateInfo()
        {
            foreach(Transform child in PowerUpContainer.transform)
            {
                child.gameObject.SetActive(false);
            }
            currentMission = missionSelector.GetCurrentItem();
            _nameText.text = currentMission?.Name;
            _descriptionText.text = currentMission?.Description;

            for(int i = 0; i < currentMission.NumberOfPowerUps; i++)
            {
                GameObject p = PowerUpContainer.transform.GetChild(i).gameObject;
                p.SetActive(true);
                p.GetComponent<PowerAddition>().power = currentMission.GetPower(i);
            }
             
/*            _previewImage.sprite = currentMission?.Image;
            _previewImage.color = Color.white;*/
        }
        public void OnNextPressed()
        {
            missionSelector.IncrementIndex();
            UpdateInfo();
        }

        public void OnPreviousPressed()
        {
            missionSelector.DecrementIndex();
            UpdateInfo();
        }

        public void OnPlayPressed()
        {
            PlayMission(currentMission.SceneName);
        }

        private IEnumerator PlayMissionRoutine(string sceneName)
        {
/*            TransitionFader.PlayTransition(_playTransitionPrefab);*/
            LevelLoader.LoadLevel(sceneName);
            yield return new WaitForSeconds(_playDelay);
            GameMenu.Open();
        }

        void PlayMission(string sceneName)
        {
            LoadingMenu.Open();
            LoadingMenu.Instance.StartProgress(sceneName);
        }
        public void UpdateGamePoint(int value)
        {
            gamePoint.text = value.ToString();
        }
    }
}
