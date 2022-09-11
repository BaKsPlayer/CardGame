using UnityEngine;

public class ImageConverter : Singleton<ImageConverter>
{
    public Texture2D ConvertBytesToTexture(int width, int height, byte[] imageBytes)
    {
        Texture2D texture = new Texture2D(width, height);
        ImageConversion.LoadImage(texture, imageBytes);

        return texture;
    }

    public Sprite ConvertBytesToSprite(int width, int height, byte[] imageBytes)
    {
        Texture2D texture = ConvertBytesToTexture(width, height, imageBytes);
        Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), Vector2.one * 0.5f);

        return sprite;
    }
}
