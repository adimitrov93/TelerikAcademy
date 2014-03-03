namespace DocumentSystem
{
    using System.Collections.Generic;

    public class ExcelDocument : OfficeDocument
    {
        public ulong? Rows { get; private set; }

        public ulong? Columns { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "rows")
            {
                this.Rows = ulong.Parse(value);
            }
            else if (key == "cols")
            {
                this.Columns = ulong.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("rows", this.Rows));
            output.Add(new KeyValuePair<string, object>("cols", this.Columns));

            base.SaveAllProperties(output);
        }
    }
}
