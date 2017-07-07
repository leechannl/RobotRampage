using UnityEngine;

public class Pickup : MonoBehaviour {
	public int Type;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<Player>() != null && other.gameObject.CompareTag("Player")) {
			other.gameObject.GetComponent<Player>().PickupItem(Type);
			GetComponentInParent<PickupSpawn>().PickupWasPickedUp();
			Destroy(gameObject);
		}
	}
}
