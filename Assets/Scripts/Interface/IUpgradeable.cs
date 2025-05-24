using UnityEngine;

public interface IUpgradeable
{
    int BaseCost { get; set; }
    int MaxUpgradeLevel {  get; set; }
    int CurrentUpgradeLevel {  get; set; }

    int GetCost();
    void Upgrade();
    void SetActive();
}
