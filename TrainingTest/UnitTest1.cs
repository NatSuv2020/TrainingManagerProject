using DataLayer;
using DomainLibrary;
using DomainLibrary.Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace TrainingTest
{
    [TestClass]
    public class UnitTest1
    {
        TrainingManager t ;
        
        [TestMethod]
        public void previousCycling()
        {
            t = new TrainingManager(new UnitOfWork(new TrainingContext()));

            TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));

            var date1 = new DateTime(2020, 4, 21, 16, 00, 00);
            var distance1 = 50;
            var time1 = new TimeSpan(1, 20, 00);
            var averageSpeed1 = 30;
            var averageWatt1 = 200;
            var type1 = TrainingType.Endurance;
            var comment1 = "";
            var bikeType1 = BikeType.RacingBike;

            var date2 = new DateTime(2020, 4, 18, 18, 00, 00);
            var distance2 = 40;
            var time2 = new TimeSpan(1, 42, 00);
           // var averageSpeed2 = ;
            var averageWatt2 = 200;
            var type2 = TrainingType.Recuperation;
            var comment2 = "";
            var bikeType2 = BikeType.RacingBike;

            List<CyclingSession> tranings = t.GetPreviousCyclingSessions(2);
            tranings[0].When.Should().Be(date2);
            tranings[0].Distance.Should().Be(distance2);
            tranings[0].Time.Should().Be(time2);
            tranings[0].AverageSpeed.Should().Be(20);
            tranings[0].AverageWatt.Should().Be(null);
            tranings[0].TrainingType.Should().Be(type2);
            tranings[0].Comments.Should().Be(null);
            tranings[0].BikeType.Should().Be(bikeType2);
            

            tranings[1].When.Should().Be(date1);
            tranings[1].Distance.Should().Be(distance1);
            tranings[1].Time.Should().Be(time1);
            tranings[1].AverageSpeed.Should().Be(30);
            tranings[1].AverageWatt.Should().Be(null);
            tranings[1].TrainingType.Should().Be(type1);
            tranings[1].Comments.Should().Be(null);
            tranings[1].BikeType.Should().Be(bikeType1);

        }
        [TestMethod]
        public void previousRunning()
        { 
            TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
           // m.AddRunningTraining(new DateTime(2020, 4, 17, 12, 30, 00), 5000, new TimeSpan(0, 27, 17), 20, TrainingType.Endurance, null);
            //m.AddRunningTraining(new DateTime(2020, 4, 19, 12, 30, 00), 5000, new TimeSpan(0, 25, 48), 25, TrainingType.Endurance, null);

            var date1 = new DateTime(2020, 4, 17, 12, 30, 00);
            var distance1 = 5000;
            var time1 = new TimeSpan(0, 27, 17);
            var type1 = TrainingType.Endurance;
            var comment1 = "";

            var date2 = new DateTime(2020, 4, 19, 12, 30, 00);
            var distance2 = 5000;
            var time2 = new TimeSpan(0, 25, 48);
            var type2 = TrainingType.Endurance;
            var comment2 = "";

            List<RunningSession> tranings = m.GetPreviousRunningSessions(2);
            tranings[0].When.Should().Be(date1);
            tranings[0].Distance.Should().Be(distance1);
            tranings[0].Time.Should().Be(time1);
            tranings[0].AverageSpeed.Should().Be(20);
            tranings[0].TrainingType.Should().Be(type1);
            tranings[0].Comments.Should().Be(null);


            tranings[1].When.Should().Be(date2);
            tranings[1].Distance.Should().Be(distance2);
            tranings[1].Time.Should().Be(time2);
            tranings[1].AverageSpeed.Should().Be(25);
            tranings[1].TrainingType.Should().Be(type2);
            tranings[1].Comments.Should().Be(null);
        }
        [TestMethod]
        public void MonthlyRunningTrainingTest()
        {
            // t.AddCyclingTraining(new DateTime(2020, 5, 24, 08, 00, 00), 60, new TimeSpan(1, 00, 02), 20, null, TrainingType.Endurance, "comment", BikeType.RacingBike);
            TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
            m.AddRunningTraining(new DateTime(2020, 4, 17, 12, 30, 00), 5000, new TimeSpan(0, 27, 17), 20, TrainingType.Endurance, null);
            m.AddRunningTraining(new DateTime(2020, 4, 19, 12, 30, 00), 5000, new TimeSpan(0, 25, 48), 25, TrainingType.Endurance, null);
            var mt = m.GenerateMonthlyRunningReport(2020, 4);
            mt.TotalRunningDistance.Should().Be(10000);
            mt.TotalRunningTrainingTime.Should().Be(new TimeSpan(0, 52, 65));
            mt.Runs.Select(x => x.When.Month).All(m => m == 4);
            mt.Runs.Count.Should().Be(2);

        }
        [TestMethod]
        public void MonthlyCyclingTrainingTest()
        {
            // t.AddCyclingTraining(new DateTime(2020, 5, 24, 08, 00, 00), 60, new TimeSpan(1, 00, 02), 20, null, TrainingType.Endurance, "comment", BikeType.RacingBike);
            TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
            m.AddCyclingTraining(new DateTime(2020, 4, 21, 16, 00, 00), 50, new TimeSpan(1, 20, 00), 30, null, TrainingType.Endurance, null, BikeType.RacingBike);
            m.AddCyclingTraining(new DateTime(2020, 4, 18, 18, 00, 00), 40, new TimeSpan(1, 42, 00), 20, null, TrainingType.Recuperation, null, BikeType.RacingBike);
            var mt = m.GenerateMonthlyCyclingReport(2020,4);
            mt.TotalCyclingDistance.Should().Be(90);
            mt.TotalCyclingTrainingTime.Should().Be(new TimeSpan(3,02,00));
            mt.Rides.Select(x => x.When.Month).All(m => m == 4);
            mt.Rides.Count.Should().Be(2);


        }
         [TestMethod]
        public void AddRunningDate()
        {
            // Arrange
            TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
            // Act
            Action a = () => m.AddRunningTraining(new DateTime(2021, 01, 01), 200, new TimeSpan(1), 30, TrainingType.Endurance, "test");
            // Assert
            a.Should().Throw<DomainException>().WithMessage("Training is in the future");
        }
        [TestMethod]
        public void AddRunningDistance()
        {
            TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
            Action a = () => m.AddRunningTraining(new DateTime(2020, 01, 01), 100000000, new TimeSpan(1), 30, TrainingType.Endurance, "test");
                a.Should().Throw<DomainException>().WithMessage("Distance invalid value");
        }
        [TestMethod]
        public void AddRunningTime()
        {
            TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
            Action a = () => m.AddRunningTraining(new DateTime(2020, 01, 01), 200, new TimeSpan(-1), 30, TrainingType.Endurance, "test");
                a.Should().Throw<DomainException>().WithMessage("Time invalid value");
        }
        [TestMethod]
        public void AddRunningAverageSpeed()
        {
            TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
          Action a = () => m.AddRunningTraining(new DateTime(2020, 01, 01), 200, new TimeSpan(1), 100000, TrainingType.Endurance, "test");
                a.Should().Throw<DomainException>().WithMessage("Average speed invalid value");
        }
        [TestMethod]
        public void AddCyclingAverageWatt()
        {
            TrainingManager m = new TrainingManager(new UnitOfWork(new TrainingContext("Production")));
            Action a = () => m.AddCyclingTraining(new DateTime(2020, 01, 01), null, new TimeSpan(1), 30, 100000, TrainingType.Endurance, "comment", BikeType.CityBike);
                a.Should().Throw<DomainException>().WithMessage("Average watt invalid value");
        }

    }
}
