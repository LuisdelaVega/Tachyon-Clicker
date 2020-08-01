using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Date/Simple")]
public class SimpleDate : ScriptableObject
{
    private double dateInMilliseconds;
    private DateTime date; // YYYY/MM/DD H:M:S:m
    public DateTime Date
    {
        get => date;
        set
        {
            date = value;
            dateInMilliseconds = (value - DateTime.MinValue).TotalMilliseconds;
        }
    }

    public bool dateIsBC = false;

    public void AddMilliseconds(double value)
    {
        if (!dateIsBC && dateInMilliseconds + value <= 0)
            dateIsBC = true;

        Date = Date.AddMilliseconds(dateIsBC ? -value : value);
    }
}
