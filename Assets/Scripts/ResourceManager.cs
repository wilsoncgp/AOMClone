using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceManager : MonoBehaviour
{

    public Text foodText;
    public Text woodText;
    public Text goldText;

    int food;
    int wood;
    int gold;

    // Use this for initialization
    void Start()
    {
        food = 0;
        wood = 0;
        gold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseFood(int foodIncrease)
    {
        food += foodIncrease;
        foodText.text = food.ToString();
    }

    public void IncreaseWood(int woodIncrease)
    {
        wood += woodIncrease;
        woodText.text = wood.ToString();
    }

    public void IncreaseGold(int goldIncrease)
    {
        gold += goldIncrease;
        goldText.text = gold.ToString();
    }
}
