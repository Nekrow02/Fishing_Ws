using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global
{
    public enum PlayType { START = 0, CONTINUE = 1 };
    public static float date = 0;
    public static float p_date { get { return date; } set { date = p_date; OnValueChanged?.Invoke(); } }
    public static event Action OnValueChanged;
}
