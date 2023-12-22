using UnityEngine;

public class TextureManager : MonoBehaviour
{
    // Define a serialized array of sprites in the Inspector
    [SerializeField]
    private Sprite[] sprites;

    void Start()
    {
        Debug.Log("started");
        // No need to load sprites at runtime, as they are assigned in the Inspector
        AssignRandomTexture(gameObject);
    }

    // Removed the LoadImages method as it's unnecessary in this case

    public void AssignRandomTexture(GameObject obj)
    {
        Debug.Log("started assign");
        if (sprites != null && sprites.Length > 0)
        {
            int randomIndex = Random.Range(0, sprites.Length);
            Sprite randomSprite = sprites[randomIndex];

            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = randomSprite;
            }
            else
            {
                Debug.LogError("SpriteRenderer component not found on the object.");
            }
        }
        else
        {
            Debug.LogError("No sprites assigned. Assign sprites in the Inspector.");
        }
    }
}