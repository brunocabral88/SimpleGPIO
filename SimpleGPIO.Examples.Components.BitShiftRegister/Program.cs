using System;
using SimpleGPIO.Boards;
using SimpleGPIO.Power;

namespace SimpleGPIO.Examples.Components.BitShiftRegister
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using (var pi = new RaspberryPi())
            {
                var register = new SimpleGPIO.Components.BitShiftRegister(pi.Pin13, pi.Pin11, pi.Pin15, pi.Pin16, pi.Pin18);
                register.SetPowerValues(PowerValue.On, PowerValue.Off, PowerValue.Off, PowerValue.On, PowerValue.Off, PowerValue.Off, PowerValue.On, PowerValue.Off);
                Console.WriteLine("Done");
                Console.ReadKey();
            }
        }
    }
}
