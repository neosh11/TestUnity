using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class NetworkService
{
    // Weather in Perth
    private const string jsonApi = "https://www.metaweather.com/api/location/1098081/";

    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.LogError("network problem: " + request.error);
            }
            else if (request.responseCode != (long)System.Net.HttpStatusCode.OK)
            {
                Debug.LogError("response error: " + request.responseCode);
            }
            else
            {
                callback(request.downloadHandler.text);
            }
        }
    }
    public IEnumerator GetWeatherJSON(Action<string> callback)
    {
        // Yielding cascades
        return CallAPI(jsonApi, callback);
    }
}
