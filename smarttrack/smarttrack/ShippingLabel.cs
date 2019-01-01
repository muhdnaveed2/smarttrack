namespace smarttrack
{
	public class ShippingLabel
	{
        public string CountryIso { get; set; }

        public string ServiceCode { get; set; }

        public string Hawb { get; set; }

        public string HsCode { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }

        public string SenderName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostCode { get; set; }

        public string Telephone { get; set; }

        public string FullPallets { get; set; }

        public string HalfPallets { get; set; }

        public string QtrPallets { get; set; }

        public string PalletLifts { get; set; }

        public int NumberPieces { get; set; }

        public decimal Weight { get; set; }

        public decimal Value { get; set; }

        public string Currency { get; set; }

        public string ItemType { get; set; }

        public string Notes { get; set; }

        public string Description { get; set; }
    }
}
