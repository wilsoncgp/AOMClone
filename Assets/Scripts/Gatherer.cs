using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum ResourceType
{
    None,
    Food,
    Wood,
    Gold
}

public class Gatherer : MonoBehaviour
{
    public Text resourceText;
    public Text resourceTypeText;
    public Text isGatheringText;

    public int maxResource = 10;
    public float timeBetweenFoodGather = 1.0f;
    public float timeBetweenWoodGather = 1.0f;
    public float timeBetweenGoldGather = 1.0f;

    int resource;
    ResourceType resourceType;
    bool gathering;
    float timeSinceGather;

    private ResourceManager resourceManager;

    // Use this for initialization
    void Start()
    {
        resource = 0;
        resourceType = ResourceType.None;
        gathering = false;
        timeSinceGather = 0.0f;
        resourceManager = GameObject.FindObjectOfType<ResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchGather(ResourceType.Food);
            UpdateResourceText();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SwitchGather(ResourceType.Wood);
            UpdateResourceText();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SwitchGather(ResourceType.Gold);
            UpdateResourceText();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gathering = false;
            UpdateResourceText();
        }

        if (gathering && resourceType != ResourceType.None && resource < maxResource)
        {
            timeSinceGather += Time.deltaTime;
            if((resourceType == ResourceType.Food && timeSinceGather > timeBetweenFoodGather) ||
               (resourceType == ResourceType.Wood && timeSinceGather > timeBetweenWoodGather) ||
               (resourceType == ResourceType.Gold && timeSinceGather > timeBetweenGoldGather))
            {
                IncreaseResource();
                timeSinceGather = 0.0f;
            }
        }
        else
        {
            timeSinceGather = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            gathering = false;
            BankResource();
            UpdateResourceText();
        }
    }

    void SwitchGather(ResourceType type)
    {
        if (resourceType == type)
        {
            gathering = !gathering;
        }
        else
        {
            gathering = true;
            resource = 0;
            timeSinceGather = 0.0f;
            resourceType = type;
        }
    }

    void IncreaseResource()
    {
        resource++;
        UpdateResourceText();
    }

    void UpdateResourceText()
    {
        resourceText.text = resource.ToString();
        switch (resourceType)
        {
            case ResourceType.Food:
                resourceTypeText.text = "Food";
                break;
            case ResourceType.Wood:
                resourceTypeText.text = "Wood";
                break;
            case ResourceType.Gold:
                resourceTypeText.text = "Gold";
                break;
            default:
                resourceTypeText.text = "None";
                break;
        }
        isGatheringText.text = gathering ? "Yes" : "No";
    }

    void BankResource()
    {
        switch(resourceType)
        {
            case ResourceType.Food:
                resourceManager.IncreaseFood(resource);
                break;
            case ResourceType.Wood:
                resourceManager.IncreaseWood(resource);
                break;
            case ResourceType.Gold:
                resourceManager.IncreaseGold(resource);
                break;
        }

        resource = 0;
    }
}