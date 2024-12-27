using System;

static class LogLine
{
    private const int StartIndex = 0;
    private const string InfoLvlWord = "[INFO]: ";
    private const string WarningLvlWord = "[WARNING]: ";
    private const string ErrorLvlWord = "[ERROR]: ";

    private enum ErrorLevelType
    {
        Info = 1,
        Warning = 2,
        Error = 3,
        Unknown = 99
    }

    public static string Message(string logLine)
    {
        var result = logLine.GetErrorType() switch
        {
            ErrorLevelType.Info => logLine.ExtractMessage(InfoLvlWord).Trim(),
            ErrorLevelType.Warning => logLine.ExtractMessage(WarningLvlWord).Trim(),
            ErrorLevelType.Error => logLine.ExtractMessage(ErrorLvlWord).Trim(),
            ErrorLevelType.Unknown => throw new ArgumentException("Unrecognized level type!"),
            _ => throw new Exception("Unexpected Error!")
        };
        return result;
    }

    public static string LogLevel(string logLine)
    {
        var result = logLine.GetErrorType() switch
        {
            ErrorLevelType.Info => "info",
            ErrorLevelType.Warning => "warning",
            ErrorLevelType.Error => "error",
            ErrorLevelType.Unknown => throw new ArgumentException("Unrecognized level type!"),
            _ => throw new Exception("Unexpected Error!")
        };
        return result;
    }

    public static string Reformat(string logLine)
    {
        var errorLevelType = logLine.GetErrorType();

        return errorLevelType switch
        {
            ErrorLevelType.Unknown => throw new ArgumentException("Unrecognized level type!"),
            ErrorLevelType.Info or ErrorLevelType.Warning or ErrorLevelType.Error =>
                $"{Message(logLine)} ({errorLevelType.ToString().ToLower()})",
            _ => throw new Exception("Unexpected Error!")
        };
    }

    private static ErrorLevelType GetErrorType(this string logLine)
    {
        if (logLine.StartsWith(InfoLvlWord)) return ErrorLevelType.Info;
        else if (logLine.StartsWith(WarningLvlWord)) return ErrorLevelType.Warning;
        else if (logLine.StartsWith(ErrorLvlWord)) return ErrorLevelType.Error;
        else return ErrorLevelType.Unknown;
    }

    private static string ExtractMessage(this string logLine, string wordToRemove) =>
        logLine.Remove(StartIndex, wordToRemove.Length);
}
