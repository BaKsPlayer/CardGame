using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CardAvatar : MonoBehaviour
{
    private RawImage avatar;
    
    public void Initialize()
    {
        avatar ??= GetComponent<RawImage>();
        StartCoroutine(RandByImageParser.Instance.ParseImage(SetAvatarSprite));
    }

    private void SetAvatarSprite(byte[] imageBytes)
    {
        Vector2Int textureSize = new Vector2Int((int)avatar.rectTransform.sizeDelta.x, (int)avatar.rectTransform.sizeDelta.y);
        avatar.texture = ImageConverter.Instance.ConvertBytesToTexture(textureSize.x, textureSize.y, imageBytes);
    }
}
