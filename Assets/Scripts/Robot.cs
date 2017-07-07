using System.Collections;
using System.Security.AccessControl;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour {
  [SerializeField] private string m_RobotType;
  [SerializeField] private GameObject m_MissilePrefab;
  [SerializeField] private AudioClip m_DeathAudioClip;
  [SerializeField] private AudioClip m_FireAudioClip;
  [SerializeField] private AudioClip m_WeakHitAudioClip;
  public int Health;
  public int Range;
  public float FireRate;
  public Transform MissileFireSpot;
  public Animator RobotAnimator;

  private NavMeshAgent m_NavMeshAgent;
  private Transform m_PlayerTransform;
  private float m_TimeLastFired;
  private bool m_IsDead;

  private void Start() {
    m_IsDead = false;
    m_NavMeshAgent = GetComponent<NavMeshAgent>();
    m_PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
  }

  private void Update() {
    if (m_IsDead) {
      return;
    }
    transform.LookAt(m_PlayerTransform);
    m_NavMeshAgent.SetDestination(m_PlayerTransform.position);
    if (Vector3.Distance(transform.position, m_PlayerTransform.position) < Range && Time.time - m_TimeLastFired > FireRate) {
      m_TimeLastFired = Time.time;
      Fire();
    }
  }

  private void Fire() {
    var missile = Instantiate(m_MissilePrefab);
    missile.transform.position = MissileFireSpot.transform.position;
    missile.transform.rotation = MissileFireSpot.transform.rotation;
    RobotAnimator.Play("Fire");
    GetComponent<AudioSource>().PlayOneShot(m_FireAudioClip);
  }

  public void TakeDamage(int amount) {
    if (m_IsDead) {
      return;
    }

    Health -= amount;
    if (Health <= 0) {
      m_IsDead = true;
      RobotAnimator.Play("Die");
      StartCoroutine(DestroyRobot());
      GetComponent<AudioSource>().PlayOneShot(m_DeathAudioClip);
    } else {
      GetComponent<AudioSource>().PlayOneShot(m_WeakHitAudioClip);
    }
  }

  private IEnumerator DestroyRobot() {
    yield return new WaitForSeconds(1.5f);
    Destroy(gameObject);
  }
}