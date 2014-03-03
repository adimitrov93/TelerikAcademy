namespace DocumentSystem
{
    using System.Collections.Generic;

    public class PDFDocument : EncryptableDocument
    {
        public uint? NumberOfPages { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "pages")
            {
                this.NumberOfPages = uint.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("pages", this.NumberOfPages));

            base.SaveAllProperties(output);
        }
    }
}
