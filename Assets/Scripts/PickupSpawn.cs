using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour {
  [SerializeField] private List<GameObject> Pickups;

  private void SpawnPickup() {
    var pickup = Instantiate(Pickups[Random.Range(0, Pickups.Count)]);
    pickup.transform.position = transform.position;
    pickup.transform.parent = transform;
  }

  private IEnumerator RespawnPickup() {
    yield return new WaitForSeconds(20);
    SpawnPickup();
  }

  private void Start() {
    SpawnPickup();
  }

  public void PickupWasPickedUp() {
    StartCoroutine(RespawnPickup());
  }
}