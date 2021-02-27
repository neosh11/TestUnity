using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private Vector3 position;
    private string text;

    public void SetText(string text)
    {
        this.text = text;
    }
    public string GetText()
    {
        return text;
    }
    public void SetPosition(Vector3 pos)
    {
        this.position = pos;
    }
    public Vector3 GetPosition()
    {
        return position;
    }
}
