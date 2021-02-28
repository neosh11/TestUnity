using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
public class WeatherManager : MonoBehaviour, IGameManager
{

    public string data;
    public ManagerStatus status { get; private set; }
    // Add cloud value here (listing 10.8)
    private NetworkService _network;
    public void Startup(NetworkService service)
    {
        Debug.Log("Weather manager starting...");
        _network = service;

        StartCoroutine(_network.GetWeatherJSON(OnJSONDataLoaded));

        status = ManagerStatus.Started;
    }


    public void OnJSONDataLoaded(string data)
    {

        Dictionary<string, object> dict;
        dict = Json.Deserialize(data) as Dictionary<string, object>;
        var todayWeather = ((Dictionary<string, object>)((List<object>)dict["consolidated_weather"])[0])["weather_state_name"];

        this.data = dict["title"] + " - " + todayWeather;
        Debug.Log(this.data);
        status = ManagerStatus.Started;

        Messenger.Broadcast(GameEvent.WEATHER_UPDATED);
    }


}