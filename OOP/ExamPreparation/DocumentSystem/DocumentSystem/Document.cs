namespace DocumentSystem
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Document : IDocument
    {
        public string Name { get; private set; }

        public string Content { get; protected set; }

        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.Name = value;
            }
            else if (key == "content")
            {
                this.Content = value;
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(string.Format("{0}[", this.GetType().Name));

            var attributes = new List<KeyValuePair<string, object>>();

            this.SaveAllProperties(attributes);

            var sortedAttributes = attributes.OrderBy(attrib => attrib.Key);

            foreach (var attribute in sortedAttributes)
            {
                if (attribute.Value != null)
                {
                    result.Append(string.Format("{0}={1};", attribute.Key, attribute.Value));
                }
            }

            result.Length--;

            result.Append("]");

            return result.ToString();
        }
    }
}
