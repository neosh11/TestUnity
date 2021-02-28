using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class WeatherController : MonoBehaviour
{
    void Awake()
    {
        Messenger.AddListener(GameEvent.WEATHER_UPDATED, OnWeatherUpdated);
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.WEATHER_UPDATED, OnWeatherUpdated);
    }

    private void OnWeatherUpdated()
    {
        ShowData(Managers.Weather.data);
    }
    private void ShowData(string value)
    {
        this.GetComponent<Text>().text = value;
        // Debug.Log(value);
    }
}