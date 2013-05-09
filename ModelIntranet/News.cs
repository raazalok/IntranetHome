using System;

namespace Com.Powergrid.Intranet.Model
{
    public class News
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime NewsDate { get; set; }

        public string NewsSource { get; set; }

        public string NewsContent { get; set; }

        public string ImageName { get; set; }

        public string ImagePath { get; set; }

        public double ImageSize { get; set; }

        public string SupportedFile { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string FilePath { get; set; }

        public string FileName { get; set; }

        public string FileType { get; set; }

        public double FileSize { get; set; }

        public string Link { get; set; }

        public bool Active { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
