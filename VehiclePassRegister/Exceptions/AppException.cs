namespace VehiclePassRegister.Exceptions
{
    public class AppException : Exception
    {
        public AppException()
        {

        }

        public AppException(string messege) : base(messege)
        {

        }
        public AppException(string messege, Exception inner) : base(messege, inner)
        {

        }
    }
}
