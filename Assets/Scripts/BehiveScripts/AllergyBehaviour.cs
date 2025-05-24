using UnityEngine;

public class AllergyBehaviour : MonoBehaviour
{
    private int allergyLevel = 0;
    public void Sting(){
        // Implement the logic for what happens when the bee stings the target
        Debug.Log($"{gameObject.name} has been stung!");
        allergyLevel++;
        if (allergyLevel >= 10){
            Debug.Log("You should get to the hospital!");
        }
    }

    public void Epipen(){
        // Implement the logic for what happens when the target uses an epipen
        Debug.Log($"{gameObject.name} has used an epipen!");
        allergyLevel = Mathf.Max(0, allergyLevel - 5); // Reduce allergy level by 5, but not below 0
    }
}
