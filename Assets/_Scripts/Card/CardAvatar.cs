using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CardAvatar : MonoBehaviour
{
    private Image avatar;
    
    public void Initialize()
    {
        avatar ??= GetComponent<Image>();
        StartCoroutine(RandByImageParser.Instance.ParseImage(SetAvatarSprite));
    }

    private void SetAvatarSprite(byte[] imageBytes)
    {
        Vector2Int textureSize = new Vector2Int((int)avatar.rectTransform.sizeDelta.x, (int)avatar.rectTransform.sizeDelta.y);
        avatar.sprite = ImageConverter.Instance.ConvertBytesToSprite(textureSize.x, textureSize.y, imageBytes);
    }
}
