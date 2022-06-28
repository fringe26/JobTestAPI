using System.Reflection;

namespace API.Services
{
    public class ConvertorService :IConvertorService
    {
      

        public object Deserialize(Stream serializationStream,Type obj2)
        {
            Object obj = Activator.CreateInstance(obj2);

            using (var streamReader = new StreamReader(serializationStream))
            {
                //to read typename
                string typeName = streamReader.ReadLine();

                //read the rest
                string content = streamReader.ReadToEnd();
                List<string> pairs = content.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string key, value;
                foreach (string pair in pairs)
                {
                    string[] keyValue = pair.Split(':');
                    key = keyValue[0];
                    value = keyValue[1];

                    PropertyInfo propertyInfo = _type.GetProperty(key);
                    propertyInfo?.SetValue(obj, value, null);
                }
            }
            return obj;
        }



        public void Serialize(Stream serializationStream, object model)
        {
            List<PropertyInfo> properties = _type.GetProperties().ToList();
            StreamWriter streamWriter = new StreamWriter(serializationStream);
            streamWriter.WriteLine(_type.Name);
            foreach (PropertyInfo propertyInfo in properties)
            {
                streamWriter.WriteLine($"{propertyInfo.Name}:{propertyInfo.GetValue(model)}");

            }
            streamWriter.Flush();

        }

    }
}
