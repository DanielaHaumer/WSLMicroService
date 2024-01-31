namespace Campus02WebService.Services
{
    public class LieferkostenCalculator : ILieferkostenCalculator
    {
        public double CalculateLieferkosten(double gewicht)
        {
            if (gewicht < 100)
            {
                return 20;
            }
            else
            {
                return 50;
            }
        }
    }
}
