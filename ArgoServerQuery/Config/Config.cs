namespace ArgoServerQuery.Config
{
    public class Config
    {

        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public class configuration
        {

            private object tsAddressField;

            private object userField;

            private object channelIdField;

            public object tsAddress
            {
                get
                {
                    return this.tsAddressField;
                }
                set
                {
                    this.tsAddressField = value;
                }
            }

            public object user
            {
                get
                {
                    return this.userField;
                }
                set
                {
                    this.userField = value;
                }
            }

            public object channelId
            {
                get
                {
                    return this.channelIdField;
                }
                set
                {
                    this.channelIdField = value;
                }
            }
        }
    }
}
