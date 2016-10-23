using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public enum Interval
    {
        [EnumMember] Minute = 1,
        [EnumMember] Minute5 = 5,
        [EnumMember] Minute15 = 15,
        [EnumMember] Minute30 = 30,
        [EnumMember] Hour = 60,
        [EnumMember] Hour4 = 240,
        [EnumMember] Day = 24*60,
        [EnumMember] Month = 30*Day,
        [EnumMember] Year = 365*Day
    }
}