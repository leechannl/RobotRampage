using System.Collections;
using UnityEngine;

public class Missile : MonoBehaviour {
  public float Speed = 30.0f;
  public int Damage = 10;

  private void Start() {
    StartCoroutine(DeathTimer());
  }

  private void Update() {
    transform.Translate(Vector3.forward * Speed * Time.deltaTime);
  }

  private IEnumerator DeathTimer() {
    yield return new WaitForSeconds(10);
    Destroy(gameObject);
  }

  private void OnCollisionEnter(Collision other) {
    if (other.gameObject.GetComponent<Player>() != null && other.gameObject.CompareTag("Player")) {
      other.gameObject.GetComponent<Player>().TakeDamage(Damage);
    }
    Destroy(gameObject);
  }
}