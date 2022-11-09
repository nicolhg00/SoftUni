﻿using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class ExportEncryptedMessagesDto
    {
        [XmlElement("Description")]
        public string ReversedDescription { get; set; }
    }
}