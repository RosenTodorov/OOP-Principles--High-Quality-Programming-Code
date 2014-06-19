namespace EventCodeFormatting
{
    using System;
    using System.Linq;
    using System.Text;

    public class Event : IComparable
    {
        private DateTime date;
        private String title;
        private String location;

        public Event(DateTime date, String title, String location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object obj)
        {
            Event other = obj as Event;
            int compareByDate = this.date.CompareTo(other.date);
            int compareByTitle = this.title.CompareTo(other.title);
            int compareByLocation = this.location.CompareTo(other.location);

            if (compareByDate == 0)
            {
                if (compareByTitle == 0)
                {
                    return compareByLocation;
                }
                else
                {
                    return compareByTitle;
                }
            }
            else
            {
                return compareByDate;
            }
        }

        // Events will appear in the format "DateTTime | Title[ | Location]"
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            stringBuilder.Append(" | " + this.title);
            if (this.location != null && this.location != string.Empty)
            {
                stringBuilder.Append(" | " + this.location);
            }

            return stringBuilder.ToString();
        }
    }
}