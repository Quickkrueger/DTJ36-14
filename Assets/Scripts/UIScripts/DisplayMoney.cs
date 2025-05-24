using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DisplayMoney : MonoBehaviour
{
    private Text moneyText;

    private void Awake()
    {
        moneyText = GetComponent<Text>();
    }
    public void SetMoney(float amount) {
        moneyText.text = amountToDollars(amount);
    }
    private string amountToDollars(float amount)
    {
        return string.Format("{0:C}", amount);
    }
}
