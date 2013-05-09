using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Powergrid.Intranet.Model
{
    public enum ImageType
    {
        NEW, UPDATE
    }

    public class Marquee
    {
        public int Id { get; set; }
        public String DisplayText { get; set; }
        public bool HasAttachment { get; set; }
        public ImageType ImageType { get; set; }
        public bool Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String AttachmentLink { get; set; }
        public String UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int SiteId { get; set; }
    }
}
