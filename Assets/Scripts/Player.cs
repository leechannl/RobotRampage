using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Player : MonoBehaviour {
  public int Health;
  public int Armor;
  public GameUI GameUi;
  public Game Game;
  public AudioClip PlayerDeadAudioClip;

  private Ammo m_Ammo;
  private GunEquipper m_GunEquipper;

  private void Start() {
    m_Ammo = GetComponent<Ammo>();
    m_GunEquipper = GetComponent<GunEquipper>();
  }

  public void TakeDamage(int amount) {
    var leftHealth = Health + Armor - amount;
    if (leftHealth <= 0) {
      leftHealth = 0;
    }
    Health = leftHealth - Health > 0 ? Health : leftHealth;
    Armor = leftHealth - Health > 0 ? leftHealth - Health : 0;
    GameUi.SetArmorText(Armor);
    GameUi.SetHealthText(Health);
    if (leftHealth <= 0) {
      GetComponent<AudioSource>().PlayOneShot(PlayerDeadAudioClip);
      Game.GameOver();
    }
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
    GameUi.SetPickupText("Health picked up + 50 Health");
    GameUi.SetHealthText(Health);
  }

  private void PickupArmor() {
    Armor += 15;
    GameUi.SetPickupText("Armor picked up + 15 armor");
    GameUi.SetArmorText(Armor);
  }

  private void PickupAssaultRifleAmmo() {
    m_Ammo.AddAmmo(Constants.AssaultRifle, 50);
    GameUi.SetPickupText("Assault rifle ammo picked up + 50 ammo");
    if (m_GunEquipper.GetActiveWeapon().CompareTag(Constants.AssaultRifle)) {
      GameUi.SetAmmoText(m_Ammo.GetAmmoCount(Constants.AssaultRifle));
    }
  }

  private void PickupPistolAmmo() {
    m_Ammo.AddAmmo(Constants.Pistol, 20);
    GameUi.SetPickupText("Pistol ammo picked up + 20 ammo");
    if (m_GunEquipper.GetActiveWeapon().CompareTag(Constants.Pistol)) {
      GameUi.SetAmmoText(m_Ammo.GetAmmoCount(Constants.Pistol));
    }
  }

  private void PickupShotgunAmmo() {
    m_Ammo.AddAmmo(Constants.Shotgun, 10);
    GameUi.SetPickupText("Shotgun ammo picked up + 10 ammo");
    if (m_GunEquipper.GetActiveWeapon().CompareTag(Constants.Shotgun)) {
      GameUi.SetAmmoText(m_Ammo.GetAmmoCount(Constants.Shotgun));
    }
  }
}