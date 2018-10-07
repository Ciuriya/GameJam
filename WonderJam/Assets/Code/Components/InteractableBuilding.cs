using UnityEngine;
using UnityEngine.UI;

public class InteractableBuilding : MonoBehaviour
{
    public BuildingUpdater updaterUI;
    public BoxCollider2D collider;
    public SpriteRenderer tooltipRenderer;
    public Sprite icon;

    public BuildingLevel currentLevel;

    private bool isInteracting = false;

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
            isInteracting = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            tooltipRenderer.enabled = false;
            isInteracting = false;

            updaterUI.HideForm();
        }
    }

    void Update()
    {
        if (isInteracting && (Input.GetKeyDown("up") || Input.GetKeyDown("w"))) Interact();
    }

    public void Interact()
    {
        updaterUI.Setup(currentLevel);
        updaterUI.ShowForm();
    }

}
