using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        [SetUp]
        public void Setup()
        {
        }

       
        // For Normal Cab Type 

        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }

        [Test]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(3.0, 5), new Ride(0.1, 5) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 41.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }

        [Test]
        public void GivenMultipleRidewithUserIdShouldReturnInvoiceSummaryAccordingtoUserId()
        {
            RideRepository rideRepository = new RideRepository();
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(3.0, 5), new Ride(0.1, 5) };
            rideRepository.AddRide("Pooja", rides);
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rideRepository.getRides("Pooja"));
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 41.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }

        // For Premium Cab Type

        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFareForPremiumTypeCab()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 8.0;
            int time = 20;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 160;
            Assert.AreEqual(expected, fare);
        }


        [Test]
        public void GivenMultipleRideShouldReturnInvoiceSummaryForPremiumTypeCab()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(4.0, 10), new Ride(0.7, 4) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(4, 42.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }

        [Test]
        public void GivenMultipleRidewithUserIdShouldReturnInvoiceSummaryAccordingtoUserIdForPremiumTypecab()
        {
            RideRepository rideRepository = new RideRepository();
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };
            rideRepository.AddRide("Pooja", rides);
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rideRepository.getRides("Pooja"));
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 35.0);
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
        }

    }
}