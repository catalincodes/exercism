using System;

public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string input, string after)
    {
		return input.Substring(input.IndexOf(after) + after.Length);
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
   public static string SubstringBetween(this string input, string start, string end) {
	   int startPos = (input.IndexOf(start) + start.Length);
	   return input.Substring(startPos, input.IndexOf(end) - startPos);
   }

   // TODO: define the 'Message()' extension method on the `string` type
   public static string Message(this string input)
   {
	   return input.SubstringAfter("]: ");
   }

    // TODO: define the 'LogLevel()' extension method on the `string` type
	public static string LogLevel(this string input)
	{
		return input.SubstringBetween("[", "]");
	}
}
