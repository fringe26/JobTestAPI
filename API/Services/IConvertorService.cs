namespace API.Services
{
    public interface IConvertorService
    {
        public object Deserialize(Stream serializationStream,Type obj2);
        public void Serialize(Stream serializationStream,object model);
    }
}
