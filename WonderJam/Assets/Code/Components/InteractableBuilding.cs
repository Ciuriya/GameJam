using UnityEngine;
using UnityEngine.UI;

public class InteractableBuilding : MonoBehaviour
{
    public BoxCollider2D collider;
    public SpriteRenderer tooltipRenderer;
    public Sprite icon;

    public BuildingLevel currentLevel;

    private bool isInteractable = false;


    void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        if (collider != null)
            collider.isTrigger = true;
    }

    void OnEnable()
    {
        tooltipRenderer.sprite = icon;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            tooltipRenderer.enabled = true;
            isInteractable = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            tooltipRenderer.enabled = false;
            isInteractable = false;
        }
    }

    void Update()
    {
        if (isInteractable && (Input.GetKeyDown("up") || Input.GetKeyDown("w"))) Interact();
    }

    public void Interact()
    {

        float currentProduction = currentLevel.ressourceGenTransaction.delta;
        float deltaStrorage = currentLevel.maxStorageIncrement;
        Sprite currentProductionSprite = currentLevel.ressourceGenTransaction.ressourceType.icon;

        float goldCost = currentLevel.upgradeCosts[0].delta;
        Sprite goldSprite = currentLevel.upgradeCosts[0].ressourceType.icon;

        float stoneCost = currentLevel.upgradeCosts[1].delta;
        Sprite stoneSprite = currentLevel.upgradeCosts[1].ressourceType.icon;

        float woodCost = currentLevel.upgradeCosts[2].delta;
        Sprite woodSprite = currentLevel.upgradeCosts[2].ressourceType.icon;

        if (currentLevel.nextLevel != null)
        {
            float productionAfterUpgrade = currentLevel.nextLevel.ressourceGenTransaction.delta;
            currentLevel = currentLevel.nextLevel;
        }


    }
}
