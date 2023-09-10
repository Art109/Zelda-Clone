using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DayState { Morning, Evening , Night}

public class WorldTime : MonoBehaviour
{
    enum DayState { Morning, Evening, Night }
    DayState dayState;
    private Queue<DayState> cycleQueue;

    public event EventHandler<TimeSpan> WorldTimeChanged;

    [SerializeField]
    private float _dayLength;

    private TimeSpan _currentTime;
    private float _minuteLength => _dayLength / WorldTimeConstants.MinutesInDay;

    private void Start()
    {
        StartCoroutine(AddMinute());
        WorldTimeChanged += OnWorldTimeChanged;
        cycleQueue= new Queue<DayState>();
        cycleQueue.Enqueue(DayState.Morning);
        cycleQueue.Enqueue(DayState.Evening);
        cycleQueue.Enqueue(DayState.Night);
    }
    private void OnDestroy()
    {
        WorldTimeChanged -= OnWorldTimeChanged;
    }


    private IEnumerator AddMinute()
    {
        _currentTime += TimeSpan.FromMinutes(1);
        WorldTimeChanged?.Invoke(this, _currentTime);
        yield return new WaitForSeconds(_minuteLength);
        StartCoroutine(AddMinute());
    }

    private void OnWorldTimeChanged(object sender, TimeSpan newTime)
    {
        Debug.Log(PercentOfDay(newTime));
        float percentOfDay = PercentOfDay(newTime);
        if(percentOfDay == 0.25 || percentOfDay == 0.50 || percentOfDay == 0.75)
        {
            dayState = cycleQueue.Dequeue();
            cycleQueue.Enqueue(dayState);
            Debug.Log(dayState.ToString());
        }

    }

    private float PercentOfDay(TimeSpan timeSpan)
    {
        return (float)timeSpan.TotalMinutes % WorldTimeConstants.MinutesInDay / WorldTimeConstants.MinutesInDay;
    }
}
