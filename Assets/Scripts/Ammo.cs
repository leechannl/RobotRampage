using System;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
  [SerializeField] private GameUI m_GameUi;
  [SerializeField] private int m_PistolAmmoCount = 20;
  [SerializeField] private int m_ShotgunAmmoCount = 10;
  [SerializeField] private int m_AssaultRifleAmmoCount = 50;

  public Dictionary<String, int> AmmoCountPerGunType;

  private void Awake() {
    AmmoCountPerGunType = new Dictionary<string, int> {
      {Constants.Pistol, m_PistolAmmoCount},
      {Constants.AssaultRifle, m_AssaultRifleAmmoCount},
      {Constants.Shotgun, m_ShotgunAmmoCount}
    };
  }

  public void AddAmmo(string gunType, int count) {
    if (!AmmoCountPerGunType.ContainsKey(gunType)) {
      Debug.LogError("unrecognized gun type passed: " + gunType);
    }

    AmmoCountPerGunType[gunType] += count;
  }

  public bool HasAmmo(string gunType) {
    if (!AmmoCountPerGunType.ContainsKey(gunType)) {
      Debug.LogError("unrecognized gun type passed: " + gunType);
    }

    return AmmoCountPerGunType[gunType] > 0;
  }

  public int GetAmmoCount(string gunType) {
    if (!AmmoCountPerGunType.ContainsKey(gunType)) {
      Debug.LogError("unrecognized gun type passed: " + gunType);
    }

    return AmmoCountPerGunType[gunType];
  }

  public void ConsumeAmmo(string gunType) {
    if (!AmmoCountPerGunType.ContainsKey(gunType)) {
      Debug.LogError("unrecognized gun type passed: " + gunType);
    }

    AmmoCountPerGunType[gunType]--;
  }
}