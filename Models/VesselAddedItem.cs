using System;
using System.Collections.Generic;

namespace scorpio.Models
{
    public partial class VesselAddedItem
    {
        public string id { get; set; } = null!;
        public string? item_id { get; set; }
        public string? vessel_id { get; set; }
        public string? id_2 { get; set; }
        public string? name { get; set; }
        public string? unit_id { get; set; }
        public string? filename { get; set; }
        public string? created_date { get; set; }
        public string? modified_date { get; set; }
        public string? deleted_date { get; set; }
        public string? other_names { get; set; }
        public string? timestamp { get; set; }
        public string? category_id { get; set; }
        public string? type_id { get; set; }
        public string? created_by { get; set; }
        public string? modified_by { get; set; }
        public string? deleted_by { get; set; }
        public string? from_shore { get; set; }
    }
}
