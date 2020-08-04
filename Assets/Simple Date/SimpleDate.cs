using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Date/Simple")]
public class SimpleDate : ScriptableObject
{
    //private double dateInMilliseconds;
    private DateTime date; // YYYY/MM/DD H:M:S:m
    public DateTime Date
    {
        get => date;
        private set
        {
            date = value;
            //dateInMilliseconds = (value - DateTime.MinValue).TotalMilliseconds;
        }
    }

    private DateTime startDate;
    public DateTime StartDate
    {
        get => startDate;
        set => startDate = date = value;
    }
    public DateTime EndDate { get; set; }

    private readonly float dayToMonthConversion = 0.03287667629953f;
    private readonly float dayToYearConversion = 0.0027397260274f;

    private void Awake()
    {
        StartDate = new DateTime(2020, 11, 11, 12, 12, 12, 0);
        EndDate = new DateTime(2000, 7, 27, 12, 12, 12, 0);
    }

    public void AddMilliseconds(double value) => Date = Date.AddMilliseconds(value);

    public TotalTime GetTotalTime(DateTime start, DateTime end)
    {
        TimeSpan timeSpan = (start - end);

        int totalDays = Mathf.FloorToInt((float)timeSpan.TotalDays);
        int totalMonths = Mathf.FloorToInt((float)timeSpan.TotalDays * dayToMonthConversion);
        int totalYears = Mathf.FloorToInt((float)timeSpan.TotalDays * dayToYearConversion);

        return new TotalTime(totalDays, totalMonths, totalYears);
    }
    public TotalTime GetTimeTraveled() => GetTotalTime(StartDate, Date);

    public TotalTime GetTimeUntilEnd() => GetTotalTime(Date, EndDate);
}

public class TotalTime
{
    public int totalDays { get; private set; }
    public int totalMonths { get; private set; }
    public int totalYears { get; private set; }

    public TotalTime(int totalDays, int totalMonths, int totalYears)
    {
        this.totalDays = totalDays;
        this.totalMonths = totalMonths;
        this.totalYears = totalYears;
    }
}
