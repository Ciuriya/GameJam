using UnityEngine;
using UnityEngine.UI;

public class InteractableChest : MonoBehaviour
{
    public BoxCollider2D collider;
    public SpriteRenderer tooltipRenderer;
    public Sprite icon;

    public ChestDropRuntimeSet chestDrops;

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
        chestDrops.m_items.ForEach(d => d.Drop());

        this.transform.parent.gameObject.SetActive(false);
    }
}
