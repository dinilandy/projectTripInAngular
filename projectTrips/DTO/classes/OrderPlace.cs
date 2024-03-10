using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.classes
{
    public partial class OrderPlace
    {
        public short IdOrder { get; set; }

        public short? IdUser { get; set; }

        public DateTime? OrderDate { get; set; }

        public TimeSpan? OrderTime { get; set; }

        public short? IdTrip { get; set; }

        public short? NumberPlaces { get; set; }

        //הוספות שלי למסד!!!!!!!!!!!!!!!
        //בנוסף לקוד משתמש
        public string? Name { get; set; }
        //בנוסף לקוד הטיול
        public string? TargetTripe { get; set; }
        //תאריך
        public DateTime? Date { get; set; }
        //public virtual TheTrip? IdTripNavigation { get; set; }

        //public virtual User? IdUserNavigation { get; set; }
    }
}
