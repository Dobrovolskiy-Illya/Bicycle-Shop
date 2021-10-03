using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models
{
    public class TestData
    {
        public static void Initialize(BicycleContext context)
        {
            if (!context.Bicycle.Any())
            {
                context.Bicycle.AddRange(
                    new Bicycle
                    {
                        BicycleTitle = "Corrado Fortun",
                        BicycleFrameSize = 18.5M,
                        BicycleWheelDiameter = 26,
                        BicycleColor = "Черно-синий",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 16,
                        BicyclePrice = 9274
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Cross Focus",
                        BicycleFrameSize = 15,
                        BicycleWheelDiameter = 26,
                        BicycleColor = "Серо-синий",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 14,
                        BicyclePrice = 5299
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Dorozhnik Obsidian",
                        BicycleFrameSize = 19.5M,
                        BicycleWheelDiameter = 28,
                        BicycleColor = "Голубой",
                        BicycleNumberOfSpeeds = 1,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 17.4M,
                        BicyclePrice = 4799
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Cross Focus",
                        BicycleFrameSize = 12,
                        BicycleWheelDiameter = 24,
                        BicycleColor = "Серо-синий",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 14,
                        BicyclePrice = 5299
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Dorozhnik Topaz",
                        BicycleFrameSize = 19.5M,
                        BicycleWheelDiameter = 28,
                        BicycleColor = "Коричневый",
                        BicycleNumberOfSpeeds = 1,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 17.4M,
                        BicyclePrice = 4846
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Cross Focus",
                        BicycleFrameSize = 15,
                        BicycleWheelDiameter = 26,
                        BicycleColor = "Черно-красный",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 14,
                        BicyclePrice = 5199
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Ardis Vincent",
                        BicycleFrameSize = 19.5M,
                        BicycleWheelDiameter = 26,
                        BicycleColor = "Серый",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 16,
                        BicyclePrice = 8299
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Formula Omega",
                        BicycleFrameSize = 18, 
                        BicycleWheelDiameter = 26,
                        BicycleColor = "Черно-мятный с голубым",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 15,
                        BicyclePrice = 5482
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Dorozhnik RETRO Velosteel",
                        BicycleFrameSize = 19,
                        BicycleWheelDiameter = 28,
                        BicycleColor = "Рубиновый",
                        BicycleNumberOfSpeeds = 1,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 18,
                        BicyclePrice = 5518
                    },
                    new Bicycle
                    {
                        BicycleTitle = "VNC FastRider A5",
                        BicycleFrameSize = 20,
                        BicycleWheelDiameter = 29,
                        BicycleColor = "Черный",
                        BicycleNumberOfSpeeds = 24,
                        BicycleManufactureCountry = "Китай",
                        BicucleWeight = 15,
                        BicyclePrice = 11264
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Dorozhnik ONYX 12.5",
                        BicycleFrameSize = 12.5M,
                        BicycleWheelDiameter = 20,
                        BicycleColor = "Синий",
                        BicycleNumberOfSpeeds = 3,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 13.26M,
                        BicyclePrice = 8299
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Ardis Verona 28",
                        BicycleFrameSize = 19,
                        BicycleWheelDiameter = 28,
                        BicycleColor = "Коричневый",
                        BicycleNumberOfSpeeds = 1,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 17,
                        BicyclePrice = 5012
                    },
                    new Bicycle
                    {
                        BicycleTitle = "TRINX Tempo 1.0 700C",
                        BicycleFrameSize = 21.25M,
                        BicycleWheelDiameter = 28,
                        BicycleColor = "Белый",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Китай",
                        BicucleWeight = 13,
                        BicyclePrice = 8658
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Ardis Titan 29",
                        BicycleFrameSize = 19,
                        BicycleWheelDiameter = 29,
                        BicycleColor = "Серый",
                        BicycleNumberOfSpeeds = 24,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 15,
                        BicyclePrice = 9550
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Ardis City Line 24",
                        BicycleFrameSize = 15,
                        BicycleWheelDiameter = 24,
                        BicycleColor = "Темно-зеленый",
                        BicycleNumberOfSpeeds = 1,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 25,
                        BicyclePrice = 6669
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Formula X-Rover DD 26",
                        BicycleFrameSize = 19,
                        BicycleWheelDiameter = 26,
                        BicycleColor = "Черно-бирюзовый",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 15,
                        BicyclePrice = 5942
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Ardis Titan 27.5",
                        BicycleFrameSize = 17,
                        BicycleWheelDiameter = 27.5M,
                        BicycleColor = "Серый",
                        BicycleNumberOfSpeeds = 8,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 15,
                        BicyclePrice = 9999
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Ardis Lido 26",
                        BicycleFrameSize = 16.5M,
                        BicycleWheelDiameter = 26,
                        BicycleColor = "Черный",
                        BicycleNumberOfSpeeds = 1,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 16,
                        BicyclePrice = 4894
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Ardis Hiland 27.5",
                        BicycleFrameSize = 19,
                        BicycleWheelDiameter = 27.5M,
                        BicycleColor = "Черно-зеленый",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 15,
                        BicyclePrice = 7226
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Dorozhnik LUX Velosteel 26",
                        BicycleFrameSize = 17,
                        BicycleWheelDiameter = 26,
                        BicycleColor = "Сливовый",
                        BicycleNumberOfSpeeds = 1,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 18,
                        BicyclePrice = 5482
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Dorozhnik ONYX 12.5",
                        BicycleFrameSize = 12.5M,
                        BicycleWheelDiameter = 20,
                        BicycleColor = "Синий",
                        BicycleNumberOfSpeeds = 7,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 13.52M,
                        BicyclePrice = 7703
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Orbea Alma 29 H20-Eagle M 2020",
                        BicycleFrameSize = 17,
                        BicycleWheelDiameter = 29,
                        BicycleColor = "Сине-желтый",
                        BicycleNumberOfSpeeds = 12,
                        BicycleManufactureCountry = "Португалия",
                        BicucleWeight = 13.15M,
                        BicyclePrice = 34748
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Atlantic Rekon NS 26",
                        BicycleFrameSize = 14,
                        BicycleWheelDiameter = 26,
                        BicycleColor = "Черный",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Китай",
                        BicucleWeight = 16.5M,
                        BicyclePrice = 4565
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Ardis Silver bike 500",
                        BicycleFrameSize = 14,
                        BicycleWheelDiameter = 24,
                        BicycleColor = "Черно-красный",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 15,
                        BicyclePrice = 5799
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Ardis New Fold",
                        BicycleFrameSize = 15,
                        BicycleWheelDiameter = 24,
                        BicycleColor = "Зеленый",
                        BicycleNumberOfSpeeds = 1,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 13,
                        BicyclePrice = 4699
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Royal Baby Chipmunk Explorer",
                        BicycleFrameSize = 20, 
                        BicycleWheelDiameter = 15,
                        BicycleColor = "Синий",
                        BicycleNumberOfSpeeds = 1,
                        BicycleManufactureCountry = "Китай",
                        BicucleWeight = 14.5M,
                        BicyclePrice = 6020
                    },
                    new Bicycle
                    {
                        BicycleTitle = "TRINX Tempo 1.0 700C",
                        BicycleFrameSize = 21,
                        BicycleWheelDiameter = 28,
                        BicycleColor = "Белый",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Китай",
                        BicucleWeight = 13,
                        BicyclePrice = 8658
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Orbea MX 27 XS XC 2021",
                        BicycleFrameSize = 25,
                        BicycleWheelDiameter = 27.5M,
                        BicycleColor = "Сине-красный",
                        BicycleNumberOfSpeeds = 10,
                        BicycleManufactureCountry = "Испания",
                        BicucleWeight = 15,
                        BicyclePrice = 24864
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Ardis Striker 777",
                        BicycleFrameSize = 17,
                        BicycleWheelDiameter = 24,
                        BicycleColor = "Красный с черным",
                        BicycleNumberOfSpeeds = 18,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 17,
                        BicyclePrice = 4999
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Discovery FLIPPER AM DD",
                        BicycleFrameSize = 13,
                        BicycleWheelDiameter = 24,
                        BicycleColor = "Черно-зелено-синий",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 16.3M,
                        BicyclePrice = 5208
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Formula BlackWood 2.0 DD",
                        BicycleFrameSize = 12.5M,
                        BicycleWheelDiameter = 24,
                        BicycleColor = "Серо-оранжевый",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 15,
                        BicyclePrice = 5897
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Formula Forest",
                        BicycleFrameSize = 12.5M,
                        BicycleWheelDiameter = 24,
                        BicycleColor = "Антрацит",
                        BicycleNumberOfSpeeds = 7,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 15,
                        BicyclePrice = 4740
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Dorozhnik CORAL планет.",
                        BicycleFrameSize = 19,
                        BicycleWheelDiameter = 28,
                        BicycleColor = "Малахитовый",
                        BicycleNumberOfSpeeds = 3,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 18,
                        BicyclePrice =  7958
                    },
                    new Bicycle
                    {
                        BicycleTitle = "VNC FastRider A5",
                        BicycleFrameSize = 18,
                        BicycleWheelDiameter = 29,
                        BicycleColor = "Зеленый",
                        BicycleNumberOfSpeeds = 24,
                        BicycleManufactureCountry = "Китай",
                        BicucleWeight = 15,
                        BicyclePrice = 11264
                    },
                    new Bicycle
                    {
                        BicycleTitle = "Crossride Spider",
                        BicycleFrameSize = 19,
                        BicycleWheelDiameter = 27.5M,
                        BicycleColor = "Черно-синий",
                        BicycleNumberOfSpeeds = 21,
                        BicycleManufactureCountry = "Украина",
                        BicucleWeight = 16,
                        BicyclePrice = 5170
                    });
                context.SaveChanges();
            } 
        }
    }
}
