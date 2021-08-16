using UnityEngine;
namespace AI.Monsters
{
    public class EnemyAI_Shoot : MonoBehaviour
    {
        [SerializeField] private GameObject muzzleFlareProjectile;
        [SerializeField] private GameObject shootProjectile;
        [SerializeField] private float maxHeight;
        [SerializeField] private Transform spawnPosition;
        private Transform target;
        private float initialMaxHeight;
        private void Start()
        {
            initialMaxHeight = maxHeight;
            target = GameObject.FindGameObjectWithTag("Player_ProjectileHitLoc").transform;
        }
        public void Launch()
        {
            if (muzzleFlareProjectile)
            {
                Instantiate(muzzleFlareProjectile, spawnPosition.position, Quaternion.identity);
            }
            GameObject projectile = Instantiate(shootProjectile, spawnPosition.position, Quaternion.identity);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            projectileRb.velocity = Vector3.zero;
            projectileRb.velocity = CalCulateLaunchForce(projectileRb);
        }

        Vector3 CalCulateLaunchForce(Rigidbody rb)
        {
            maxHeight = initialMaxHeight;
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y + Random.Range(-0.1f, 0.1f), target.position.z);
            float displacementY = (targetPosition.y) - rb.position.y;
            Vector3 displacementXZ = new Vector3(targetPosition.x - rb.position.x, 0, targetPosition.z - rb.position.z);
            if (displacementY > maxHeight)
            {
                maxHeight = displacementY;
            }
            Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * Physics.gravity.y * maxHeight);
            Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * maxHeight / Physics.gravity.y) + Mathf.Sqrt(2 * (displacementY - maxHeight) / Physics.gravity.y));
            return velocityXZ + velocityY;
        }
    }
}
