using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Player : MonoBehaviour {
  public int Health;
  public int Armor;
  public GameUI GameUi;
  public GunEquipper GunEquipper;

  private Ammo m_Ammo;

  private void Start() {
    m_Ammo = GetComponent<Ammo>();
    GunEquipper = GetComponent<GunEquipper>();
  }

  public void TakeDamage(int amount) {
    var leftHealth = Health + Armor - amount;
    if (leftHealth <= 0) {
      Debug.Log("GameOver");
      return;
    }
    Health = leftHealth - Health > 0 ? Health : leftHealth;
    Armor = leftHealth - Health > 0 ? leftHealth - Health : 0;
    Debug.Log(string.Format("Health: {0}, Armor: {1}", Health, Armor));
  }

  public void PickupItem(int pickupType) {
    switch (pickupType) {
      case Constants.PickUpArmor:
        PickupArmor();
        break;
      case Constants.PickUpHealth:
        PickupHealth();
        break;
      case Constants.PickUpAssaultRifleAmmo:
        PickupAssaultRifleAmmo();
        break;
      case Constants.PickUpPistolAmmo:
        PickupPistolAmmo();
        break;
      case Constants.PickUpShotgunAmmo:
        PickupShotgunAmmo();
        break;
      default:
        Debug.LogError("Bad pickup type: " + pickupType);
        break;
    }
  }

  private void PickupHealth() {
    Health += 50;
    if (Health > 200) {
      Health = 200;
    }
  }

  private void PickupArmor() {
    Armor += 15;
  }

  private void PickupAssaultRifleAmmo() {
    m_Ammo.AddAmmo(Constants.AssaultRifle, 50);
  }

  private void PickupPistolAmmo() {
    m_Ammo.AddAmmo(Constants.Pistol, 20);
  }

  private void PickupShotgunAmmo() {
    m_Ammo.AddAmmo(Constants.Shotgun, 10);
  }
}