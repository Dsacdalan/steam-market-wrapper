namespace steam_market_model
{
    public class Item
    {
        public bool Success { get; set; }
        public string Lowest_Price { get; set; }
        public string Volume { get; set; }
        public string Median_Price { get; set; }

        public double LowestPriceDouble
        {
            get
            {
                return ConvertDouble(this.Lowest_Price);
            }
        }

        public double MedianPriceDouble
        {
            get
            {
                return ConvertDouble(this.Median_Price);
            }
        }

        private int VolumeInt
        {
            get
            {
                if (int.TryParse(this.Volume, out int result))
                    return result;
                else
                    return 0;
            }
        }

        private double ConvertDouble(string price)
        {
            if (double.TryParse(price, out double result))
                return result;
            else
                return 0.00;
        }
    }
}
