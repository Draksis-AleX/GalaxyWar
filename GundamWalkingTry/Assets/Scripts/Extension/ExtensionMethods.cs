using UnityEngine;

public static class ExtensionMethods
{
    public static Sprite ConvertToSprite(this Texture2D img)
    {
        return Sprite.Create(img, new Rect(0, 0, img.width, img.height), Vector2.zero);
    }
}
