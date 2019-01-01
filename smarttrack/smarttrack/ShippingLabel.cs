namespace smarttrack
{
    public class ShippingLabel
    {
        public string countryIso { get; set; }

        public string serviceCode { get; set; }

        public string hawb { get; set; }

        public string hscode { get; set; }

        public string contact { get; set; }

        public string email { get; set; }

        public string company { get; set; }

        public string sender_name { get; set; }

        public string address_line_1 { get; set; }

        public string address_line_2 { get; set; }

        public string address_line_3 { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string postcode { get; set; }

        public string telephone { get; set; }

        public string fullpallets { get; set; }

        public string halfpallets { get; set; }

        public string qtrpallets { get; set; }

        public string palletlifts { get; set; }

        public int number_pieces { get; set; }

        public float weight { get; set; }

        public float value { get; set; }

        public string currency { get; set; }

        public string itemtype { get; set; }

        public string notes { get; set; }

        public string description { get; set; }
    }
}
