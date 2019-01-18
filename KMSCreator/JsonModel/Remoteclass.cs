namespace KMSCreator
{
    public class Remoteclass
    {
        public string name { get; set; }
        public string doc { get; set; }
        public bool @abstract { get; set; }
        public PropertyInfo[] properties { get; set; }
        public MethodInfo[] methods { get; set; }
        public string[] events { get; set; }
        public string extends { get; set; }
        public Constructor constructor { get; set; }
    }



}
