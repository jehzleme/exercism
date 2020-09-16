using System;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new Exception();
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
       if (int.TryParse(input, out int result))
        {
            return result;
        }
        return null;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        result = 0;
        try
        {
            result = int.Parse(input);
            return true;
        }

        catch
        {
            return false;
        }
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        try
        {
            throw new Exception();
        }
        finally
        {
            disposableObject.Dispose();
        }
    }
}
