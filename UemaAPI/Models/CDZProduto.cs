using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace UemaAPI.Models
{
    public class CDZProduto
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public String Nome { get; set; }

        public string NomeConvidado { get; set; }

        public bool Confirmado { get; set; }        

        public DateTime DataConfirmado { get; set; }

        public string ToXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CDZProduto));
            StringWriter stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                xmlSerializer.Serialize(writer, this);
                return stringWriter.ToString();
            }
        }
    }
}