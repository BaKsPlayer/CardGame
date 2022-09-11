using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.Networking;

public class RandByImageParser : Singleton<RandByImageParser>, IImageParser
{
    private const string SITE_URL = "https://api.rand.by/image";

    public IEnumerator ParseImage(Action<byte[]> callback)
    {
        using (UnityWebRequest webRequestToSite = UnityWebRequest.Get(SITE_URL))
        {
            yield return webRequestToSite.SendWebRequest();

            string jsonDataFromSite = webRequestToSite.downloadHandler.text;
            string imageURL = GetImageURL(jsonDataFromSite);

            using (UnityWebRequest webRequestToImage = UnityWebRequest.Get(imageURL))
            {
                yield return webRequestToImage.SendWebRequest();

                byte[] imageBytes = webRequestToImage.downloadHandler.data;
                callback?.Invoke(imageBytes);
                
            }
        }
    }

    private string GetImageURL(string jsonData)
    {
        Dictionary<string, object> jsonDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
        string urls = jsonDictionary["urls"].ToString();

        Dictionary<string, string> imageTypesUrl = JsonConvert.DeserializeObject<Dictionary<string, string>>(urls);
        string imageURL = imageTypesUrl["regular"];

        return imageURL;
    }
}
