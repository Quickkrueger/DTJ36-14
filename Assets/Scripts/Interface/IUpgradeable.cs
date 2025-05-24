using UnityEngine;

public interface IUpgradeable
{
    float BaseCost { get; set; }
    int MaxUpgradeLevel {  get; set; }
    int CurrentUpgradeLevel {  get; set; }

    float GetCost();
    void Upgrade();
}
