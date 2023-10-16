namespace RWBooks.DataAccess.CustomExceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type type, object key)
            : base($"Entity of type '{type.Name}' with key '{key}' was not found.")
        {
        }
    }
}
