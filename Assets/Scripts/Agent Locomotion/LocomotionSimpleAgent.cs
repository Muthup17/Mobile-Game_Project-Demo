using UnityEngine;
using UnityEngine.AI;
[RequireComponent (typeof (NavMeshAgent))]
public class LocomotionSimpleAgent : MonoBehaviour {
    [SerializeField] private float m_walkSpeed;
    [SerializeField] private float m_runSpeed;

	public Animator anim;
	NavMeshAgent m_agent;
	Vector2 m_smoothDeltaPosition = Vector2.zero;
	Vector2 m_velocity = Vector2.zero;
    public bool pullCharacter;
    
    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }
    void Start () {
		
		m_agent.updatePosition = false;
        m_agent.speed = m_walkSpeed;
	}

    void Update() {

        if (m_agent.enabled == false)
        {
            return;
        }

        Vector3 worldDeltaPosition = m_agent.nextPosition - transform.position;

        // Map 'worldDeltaPosition' to local space
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        // Low-pass filter the deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        m_smoothDeltaPosition = Vector2.Lerp(m_smoothDeltaPosition, deltaPosition, smooth);

        // Update velocity if delta time is safe
        if (Time.deltaTime > 1e-5f)
            m_velocity = m_smoothDeltaPosition / Time.deltaTime;

        bool shouldMove = m_velocity.magnitude > 0.5f && m_agent.remainingDistance > m_agent.radius;

        // Update animation parameters
        anim.SetBool("Walk", shouldMove);

        LookAt lookAt = GetComponent<LookAt>();
        if (lookAt)
            lookAt.lookAtTargetPosition = m_agent.steeringTarget + transform.forward;

        // Pull character towards agent
        if (worldDeltaPosition.magnitude + 0.2f > m_agent.radius && pullCharacter)
        {
            transform.position = m_agent.nextPosition - 0.9f * worldDeltaPosition;
        }
        // Pull agent towards character
        else if ((worldDeltaPosition.magnitude + 0.2f) > m_agent.radius)
        {
            m_agent.nextPosition = transform.position + 0.9f * worldDeltaPosition;
        }
        if(anim.parameters.Length > 1)
        {
            m_agent.speed = anim.GetBool("Run") ? m_runSpeed : m_walkSpeed;
        }
    }

    void OnAnimatorMove()
    {
        // Update postion to agent position
        transform.position = m_agent.nextPosition;

        // Update position based on animation movement using navigation surface height
        /*Vector3 position = anim.rootPosition;*/
        /*position.y = agent.nextPosition.y;*/
        /*transform.position = position;*/
    }
}
