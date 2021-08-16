using UnityEngine;

namespace AI.Monsters
{
    public class MonsterHealthSystem : MonoBehaviour
    {
        [SerializeField] float monsterMaxHealth;
        [SerializeField] float damageRate;
        [SerializeField] float monsterCurrentHealth;

        [SerializeField] float monsterMaxPoisonAffect;
        [SerializeField] float currentPoisonAffect;

        public float CurrentPoisonAffect
        {
            get => currentPoisonAffect;
            set => currentPoisonAffect = value;
        }
        private void Awake()
        {
            MonsterDamageByMelee.OnSwordHitMonster += TakeDamage;
        }
        // Start is called before the first frame update
        void Start()
        {
            monsterCurrentHealth = monsterMaxHealth;
            currentPoisonAffect = monsterMaxPoisonAffect;
        }

        void TakeDamage(GameObject monster, float amount)
        {
            if (monster.Equals(this.gameObject))
            {
                monsterCurrentHealth -= amount;
            }
        }
        public void TakePoisonDamage(float amount)
        {
            currentPoisonAffect -= amount;
        }

        private void OnDestroy()
        {
            MonsterDamageByMelee.OnSwordHitMonster -= TakeDamage;
        }
    }
}
