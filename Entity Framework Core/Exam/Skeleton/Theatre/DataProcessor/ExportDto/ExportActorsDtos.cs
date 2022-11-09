using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType]
    public class ExportActorsDtos
    {
        [XmlAttribute("FullName")]
        public string FullName { get; set; }

        [XmlAttribute("MainCharacter")]
        
        public string MainCharacter { get; set; }
    }
}