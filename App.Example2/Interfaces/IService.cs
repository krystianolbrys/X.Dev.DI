namespace App.Example2.Interfaces
{
    public interface IService
    {
        int GetResponseNoExceptionWithTimeMetter();
        int GetResponseNoExceptionWithoutTimeMetter();
        int GetResponseWithException();
    }
}
