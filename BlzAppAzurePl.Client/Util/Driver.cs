namespace BlzAppAzurePl.Client.Util
{
    public class Driver : IDrivable
    {
        private readonly Random _rnd = new Random();

        public string Drive(Func<int, int, bool> speedCheck, int currentSpeed = 50, int maxSpeed = 120)
        {
            if (currentSpeed < 10) throw new NotSupportedException("Speed is not mesureable");

            var legalSpeed = speedCheck(currentSpeed, maxSpeed);

            return legalSpeed ? "legal speed" : "The speed limit is cracked";
        }
    }

    public interface IDrivable
    {
        string Drive(Func<int, int, bool> speedCheck, int currentSpeed = 50, int maxSpeed = 120);

    }

}
