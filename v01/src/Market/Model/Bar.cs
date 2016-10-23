using Model.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class Bar
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity), DataMember]
        public int Id { get; set; }

        [Required, NotNullOrWhiteString, DataMember]
        public string Symbol { get; set; }

        [Required, CheckDate, DataMember]
        [Column(TypeName ="datetime2")]
        public DateTime TimeStamp { get; set; }

        [Required, NonZeroPrice, DataMember]
        public float Open { get; set; }

        [Required, NonZeroPrice, DataMember]
        public float Close { get; set; }

        [Required, NonZeroPrice, DataMember]
        public float High { get; set; }

        [Required, NonZeroPrice, DataMember]
        public float Low { get; set; }
    }
}
