namespace StudyProject.Data.Models
{
    public class KubeConfigFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] ConfigContent { get; set; }
    }
}
