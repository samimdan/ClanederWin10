#region

using System;
using System.Globalization;
using Newtonsoft.Json;

#endregion

namespace Claneder;

public struct MorningHollyTime
{
    public int Hour { get; set; }
    public int Minute { get; set; }
}

public struct EveningHollyTime
{
    public int Hour { get; set; }
    public int Minute { get; set; }
}

public struct AfternoonHollyTime
{
    public int Hour { get; set; }
    public int Minute { get; set; }
}

public class HollyTimes
{
    public MorningHollyTime MorningHollyTime { get; set; }
    public EveningHollyTime EveningHollyTime { get; set; }
    public AfternoonHollyTime AfternoonHollyTime { get; set; }
}

internal class DateInfo
{
    /// <summary>
    ///     Gets or sets the date text.
    /// </summary>
    public required string DateText { get; set; }

    /// <summary>
    ///     Gets or sets the month text.
    /// </summary>
    public required string MonthText { get; set; }

    /// <summary>
    ///     Gets or sets the day text.
    /// </summary>
    public required string DayText { get; set; }
}
// Existing code...

internal class ChrisitianDate
{
    static ChrisitianDate()
    {
        var today = DateTime.Now;
        ChDay = today.Day;
        ChMonth = today.Month;
        ChMonthName = GetMonthName(ChMonth);
    }

    public static int ChDay { get; set; }
    public static int ChMonth { get; set; }
    public static string ChMonthName { get; set; }

    private static string GetMonthName(int month)
    {
        return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
    }
}

internal class SunPosition
{
    public const string AM = "Am";
    public const string PM = "Pm";
    public const string NA = "Na";
}

public class Unix
{
    [JsonProperty("fa")] public string Fa { get; set; }

    [JsonProperty("en")] public long En { get; set; }
}

public class Timestamp
{
    [JsonProperty("fa")] public string Fa { get; set; }

    [JsonProperty("en")] public long En { get; set; }
}

public class Timezone
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("number")] public Number Number { get; set; }
}

public class Number
{
    [JsonProperty("fa")] public string Fa { get; set; }

    [JsonProperty("en")] public string En { get; set; }
}

public class Season
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("number")] public Number Number { get; set; }
}

public class Time12
{
    [JsonProperty("full")] public Full Full { get; set; }

    [JsonProperty("hour")] public Number Hour { get; set; }

    [JsonProperty("minute")] public Number Minute { get; set; }

    [JsonProperty("second")] public Number Second { get; set; }

    [JsonProperty("microsecond")] public Number Microsecond { get; set; }

    [JsonProperty("shift")] public Shift Shift { get; set; }
}

public class Full
{
    [JsonProperty("short")] public Number Short { get; set; }

    [JsonProperty("full")] public Number UFull { get; set; }
}

public class Shift
{
    [JsonProperty("short")] public string Short { get; set; }

    [JsonProperty("full")] public string Full { get; set; }
}

public class Time24
{
    [JsonProperty("full")] public Number Full { get; set; }

    [JsonProperty("hour")] public Number Hour { get; set; }

    [JsonProperty("minute")] public Number Minute { get; set; }

    [JsonProperty("second")] public Number Second { get; set; }
}

public class Date
{
    [JsonProperty("full")] public FullDate Full { get; set; }

    [JsonProperty("other")] public OtherDate Other { get; set; }

    [JsonProperty("year")] public Year Year { get; set; }

    [JsonProperty("month")] public Month Month { get; set; }

    [JsonProperty("day")] public Day Day { get; set; }

    [JsonProperty("weekday")] public Weekday Weekday { get; set; }
}

public class FullDate
{
    [JsonProperty("official")] public Official Official { get; set; }

    [JsonProperty("unofficial")] public Unofficial Unofficial { get; set; }
}

public class Official
{
    [JsonProperty("iso")] public Number Iso { get; set; }

    [JsonProperty("usual")] public Number Usual { get; set; }
}

public class Unofficial
{
    [JsonProperty("iso")] public Number Iso { get; set; }

    [JsonProperty("usual")] public Number Usual { get; set; }
}

public class OtherDate
{
    [JsonProperty("gregorian")] public Gregorian Gregorian { get; set; }

    [JsonProperty("ghamari")] public Ghamari Ghamari { get; set; }
}

public class Gregorian
{
    [JsonProperty("iso")] public Number Iso { get; set; }

    [JsonProperty("usual")] public Number Usual { get; set; }
}

public class Ghamari
{
    [JsonProperty("iso")] public Number Iso { get; set; }

    [JsonProperty("usual")] public Number? Usual { get; set; }
}

public class Year
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("animal")] public string Animal { get; set; }

    [JsonProperty("leapyear")] public string Leapyear { get; set; }

    [JsonProperty("agone")] public Agone Agone { get; set; }

    [JsonProperty("left")] public Left Left { get; set; }

    [JsonProperty("number")] public Number Number { get; set; }
}

public class Agone
{
    [JsonProperty("days")] public Number Days { get; set; }

    [JsonProperty("percent")] public Number Percent { get; set; }
}

public class Left
{
    [JsonProperty("days")] public Number Days { get; set; }

    [JsonProperty("percent")] public Number Percent { get; set; }
}

public class Month
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("asterism")] public string Asterism { get; set; }

    [JsonProperty("number")] public Number Number { get; set; }
}

public class Day
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("events")] public Events Events { get; set; }

    [JsonProperty("number")] public Number Number { get; set; }
}

public class Events
{
    [JsonProperty("local")] public Local Local { get; set; }

    [JsonProperty("holy")] public object Holy { get; set; }

    [JsonProperty("global")] public object Global { get; set; }
}

public class Local
{
    [JsonProperty("text")] public string Text { get; set; }

    [JsonProperty("holiday")] public bool Holiday { get; set; }
}

public class Weekday
{
    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("champ")] public string Champ { get; set; }

    [JsonProperty("number")] public Number Number { get; set; }
}

public class ShamsiDate
{
    [JsonProperty("unix")] public Unix Unix { get; set; }

    [JsonProperty("timestamp")] public Timestamp Timestamp { get; set; }

    [JsonProperty("timezone")] public Timezone Timezone { get; set; }

    [JsonProperty("season")] public Season Season { get; set; }

    [JsonProperty("time12")] public Time12 Time12 { get; set; }

    [JsonProperty("time24")] public Time24 Time24 { get; set; }

    [JsonProperty("date")] public Date Date { get; set; }
}

public class Result
{
    [JsonProperty("azan_sobh")]
    public string AzanSobh { get; set; }

    [JsonProperty("tolu_aftab")]
    public string ToluAftab { get; set; }

    [JsonProperty("azan_zohr")]
    public string AzanZohr { get; set; }

    [JsonProperty("ghorub_aftab")]
    public string GhorubAftab { get; set; }

    [JsonProperty("azan_maghreb")]
    public string AzanMaghreb { get; set; }

    [JsonProperty("nimeshab")]
    public string Nimeshab { get; set; }

    [JsonProperty("month")]
    public int Month { get; set; }

    [JsonProperty("day")]
    public int Day { get; set; }
}

public class HollyTimeResult
{
    [JsonProperty("ok")]
    public bool Ok { get; set; }

    [JsonProperty("result")]
    public  Result Result { get; set; }
}
