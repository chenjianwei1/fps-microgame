using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Gameplay;
using Unity.FPS.Game;


public class ObjectiveReward : MonoBehaviour
{
    public RewardType rewardType;
    [Range(0f, 3f)]
    public float increaseRatio;
    [Range(0f, 1f)]
    public float decreaseRatio;

    GameObject player;
    WeaponController weapon;

    public void ApplyReward()
    {
        player = GameObject.Find("Player");
        weapon = player.GetComponent<PlayerWeaponsManager>().WeaponParentSocket.GetComponentInChildren<WeaponController>();

        switch (rewardType)
        {
            case RewardType.maxHealth:
                {
                    player.GetComponent<Health>().MaxHealth *= (1 + increaseRatio);
                    break;
                }
            case RewardType.maxAmmo:
                {
                    player.GetComponent<Damageable>().DamageMultiplier *= (1 + increaseRatio);
                    break;
                }
            case RewardType.armor:
                {
                    weapon.MaxAmmo *= (int)(1 + increaseRatio);
                    break;
                }
            case RewardType.reloadDelay:
                {
                    weapon.AmmoReloadDelay *= (1 + increaseRatio);
                    break;
                }
        }
    }
}


public enum RewardType
{
    maxHealth, maxAmmo, armor, reloadDelay
}

