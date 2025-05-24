using UnityEngine;
public class Money : MonoBehaviour
{
    public float currentMoney = 100f;
    public DisplayMoney displayMoney;

    private void Start()
    {
        UpdateDisplayMoney();   
    }

    public void AddMoney(float amount)
    {
        currentMoney += amount;
        UpdateDisplayMoney();
    }

    public bool RemoveMoney(float amount)
    {
        if (!CanAfford(amount)) return false;
        currentMoney = Mathf.Max(0, currentMoney - amount);
        UpdateDisplayMoney();
        return true;
    }

    private bool CanAfford(float amount)
    {
        return currentMoney >= amount;
    }

    private void UpdateDisplayMoney()
    {
        if (displayMoney != null)
        {
            displayMoney.SetMoney(currentMoney);
        }
    }
}
