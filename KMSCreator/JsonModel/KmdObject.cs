namespace KMSCreator
{
    public class KmdObject
    {
        public string name { get; set; }
        public string version { get; set; }
        public Remoteclass[] remoteClasses { get; set; }
        public Complextype[] complexTypes { get; set; }
        public Event[] events { get; set; }
    }



}
