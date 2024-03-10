using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.classes
{
    public partial class TheTrip
    {
        public short IdTrip { get; set; }

        public string TargetTripe { get; set; } = null!;

        public short IdType { get; set; }

        public DateTime? Date { get; set; }

        public TimeSpan? LeavingTime { get; set; }

        public short? DurationTripInHours { get; set; }

        public short? NumberPlacesAvailable { get; set; }

        public short? Price { get; set; }

        public string? Image { get; set; }

        //הוספות למסד שאני הוספתי לי הבקשה!!!!!!!!!!
        public string? NameType { get; set; }   
        //אם יש אחד שיודע עזרה ראשונה לא צריך חובש!!!!!!!!!!!!
        public bool Medic { get; set; }

    }
}
