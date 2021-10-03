using Bisycles.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models.BicyclesInteraction
{
    public abstract class Filters
    {





        // работа фильтра
        public static FilterBicyclesViewModel FilterBicycles(FilterBicyclesViewModel model, BicycleContext context)
        {
            model.SelectedSpecifications.Bicycles = context.Bicycle.ToList();

            List<Bicycle> bicycles = new List<Bicycle>();

            if (model.SelectedSpecifications.AllFrameSize.Count != 0)
            {
                foreach (var i in model.SelectedSpecifications.AllFrameSize)
                {
                    foreach (var j in model.SelectedSpecifications.Bicycles)
                    {
                        if (i.Equals(j.BicycleFrameSize.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us"))))
                        {
                            bicycles.Add(j);
                        }
                    }
                }
                model.SelectedSpecifications.Bicycles.Clear();
                model.SelectedSpecifications.Bicycles.AddRange(bicycles);
                bicycles.Clear();
            }

            if (model.SelectedSpecifications.AllWheelDiameter.Count != 0)
            {
                foreach (var i in model.SelectedSpecifications.AllWheelDiameter)
                {
                    foreach (var j in model.SelectedSpecifications.Bicycles)
                    {
                        if (i.Equals(j.BicycleWheelDiameter.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us"))))
                        {
                            bicycles.Add(j);
                        }
                    }
                }
                model.SelectedSpecifications.Bicycles.Clear();
                model.SelectedSpecifications.Bicycles.AddRange(bicycles);
                bicycles.Clear();
            }

            if (model.SelectedSpecifications.AllColor.Count != 0)
            {
                foreach (var i in model.SelectedSpecifications.AllColor)
                {
                    foreach (var j in model.SelectedSpecifications.Bicycles)
                    {
                        if (i.Equals(j.BicycleColor))
                        {
                            bicycles.Add(j);
                        }
                    }
                }
                model.SelectedSpecifications.Bicycles.Clear();
                model.SelectedSpecifications.Bicycles.AddRange(bicycles);
                bicycles.Clear();
            }

            if (model.SelectedSpecifications.AllNumberOfSpeeds.Count != 0)
            {
                foreach (var i in model.SelectedSpecifications.AllNumberOfSpeeds)
                {
                    foreach (var j in model.SelectedSpecifications.Bicycles)
                    {
                        if (i.Equals(j.BicycleNumberOfSpeeds.ToString()))
                        {
                            bicycles.Add(j);
                        }
                    }
                }
                model.SelectedSpecifications.Bicycles.Clear();
                model.SelectedSpecifications.Bicycles.AddRange(bicycles);
                bicycles.Clear();
            }

            if (model.SelectedSpecifications.AllManufactureCountry.Count != 0)
            {
                foreach (var i in model.SelectedSpecifications.AllManufactureCountry)
                {
                    foreach (var j in model.SelectedSpecifications.Bicycles)
                    {
                        if (i.Equals(j.BicycleManufactureCountry))
                        {
                            bicycles.Add(j);
                        }
                    }
                }
                model.SelectedSpecifications.Bicycles.Clear();
                model.SelectedSpecifications.Bicycles.AddRange(bicycles);
                bicycles.Clear();
            }

            return model;
        }




        public static FilterBicyclesViewModel FilterConstantSpecificationsCount(FilterBicyclesViewModel model)
        {
            for (int i = 0; i < model.SelectedSpecifications.AllBicycles.Count(); i++)
            {
                //запись словаря Manufacture Country - Count из всего списка товаров
                {
                    if (model.SelectedSpecifications.AllBicycles[i].BicycleManufactureCountry != null)
                    {
                        if (model.Specifications.ManufacturersAndCount
                            .ContainsKey(model.SelectedSpecifications.AllBicycles[i].BicycleManufactureCountry))
                        {
                            foreach (var item in model.Specifications.ManufacturersAndCount)
                            {
                                if (item.Key == model.SelectedSpecifications.AllBicycles[i].BicycleManufactureCountry)
                                {
                                    model.Specifications.ManufacturersAndCount[model.SelectedSpecifications.AllBicycles[i].BicycleManufactureCountry] += 1;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            model.Specifications.ManufacturersAndCount
                                    .Add(model.SelectedSpecifications.AllBicycles[i].BicycleManufactureCountry, 1);
                        }
                    }
                }
            }
            return model;
        }




        // подсчет количества товаров на каждую изменяемую подкатегорию
        public static FilterBicyclesViewModel FilterCurrentSpecificationsGroupAndCount(FilterBicyclesViewModel model)
        {

            //обнуление количества товаров каждой подкатегории
            {
                model.Specifications.FrameSizesAndCount.Clear();
                model.Specifications.WheelsDiametrAndCount.Clear();
                model.Specifications.ColorsAndCount.Clear();
                model.Specifications.NumbersOfSpeedsAndCount.Clear();
                model.Specifications.ManufacturersAndCount.Clear();
            }

            for (int i = 0; i < model.SelectedSpecifications.Bicycles.Count(); i++)
            {

                //запись словаря Frame Size - Count из отфильтрованного списка
                {
                    if (model.SelectedSpecifications.Bicycles[i].BicycleFrameSize != 0)
                    {
                        if (model.Specifications.FrameSizesAndCount
                            .ContainsKey(model.SelectedSpecifications.Bicycles[i].BicycleFrameSize.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us"))))
                        {
                            foreach (var item in model.Specifications.FrameSizesAndCount)
                            {
                                if (item.Key == model.SelectedSpecifications.Bicycles[i].BicycleFrameSize.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us")))
                                {
                                    model.Specifications.FrameSizesAndCount[model.SelectedSpecifications.Bicycles[i].BicycleFrameSize.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us"))] += 1;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            model.Specifications.FrameSizesAndCount
                                    .Add(model.SelectedSpecifications.Bicycles[i].BicycleFrameSize.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us")), 1);
                        }
                    }
                }

                //запись словаря Wheel Diameter - Count из отфильтрованного списка
                {
                    if (model.SelectedSpecifications.Bicycles[i].BicycleWheelDiameter != 0)
                    {
                        if (model.Specifications.WheelsDiametrAndCount
                            .ContainsKey(model.SelectedSpecifications.Bicycles[i].BicycleWheelDiameter.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us"))))
                        {
                            foreach (var item in model.Specifications.WheelsDiametrAndCount)
                            {
                                if (item.Key == model.SelectedSpecifications.Bicycles[i].BicycleWheelDiameter.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us")))
                                {
                                    model.Specifications.WheelsDiametrAndCount[model.SelectedSpecifications.Bicycles[i].BicycleWheelDiameter.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us"))] += 1;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            model.Specifications.WheelsDiametrAndCount
                                    .Add(model.SelectedSpecifications.Bicycles[i].BicycleWheelDiameter.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us")), 1);
                        }
                    }
                }

                //запись словаря Color - Count из отфильтрованного списка
                {
                    if (model.SelectedSpecifications.Bicycles[i].BicycleColor != null)
                    {
                        if (model.Specifications.ColorsAndCount
                            .ContainsKey(model.SelectedSpecifications.Bicycles[i].BicycleColor))
                        {
                            foreach (var item in model.Specifications.ColorsAndCount)
                            {
                                if (item.Key == model.SelectedSpecifications.Bicycles[i].BicycleColor)
                                {
                                    model.Specifications.ColorsAndCount[model.SelectedSpecifications.Bicycles[i].BicycleColor] += 1;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            model.Specifications.ColorsAndCount
                                    .Add(model.SelectedSpecifications.Bicycles[i].BicycleColor, 1);
                        }
                    }
                }

                //запись словаря Number Of Speeds - Count из отфильтрованного списка
                {
                    if (model.SelectedSpecifications.Bicycles[i].BicycleNumberOfSpeeds != 0)
                    {
                        if (model.Specifications.NumbersOfSpeedsAndCount
                            .ContainsKey(model.SelectedSpecifications.Bicycles[i].BicycleNumberOfSpeeds.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us"))))
                        {
                            foreach (var item in model.Specifications.NumbersOfSpeedsAndCount)
                            {
                                if (item.Key == model.SelectedSpecifications.Bicycles[i].BicycleNumberOfSpeeds.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us")))
                                {
                                    model.Specifications.NumbersOfSpeedsAndCount[model.SelectedSpecifications.Bicycles[i].BicycleNumberOfSpeeds.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us"))] += 1;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            model.Specifications.NumbersOfSpeedsAndCount
                                    .Add(model.SelectedSpecifications.Bicycles[i].BicycleNumberOfSpeeds.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("en-us")), 1);
                        }
                    }
                }

            }

            return model;
        }




        // подсчет количества характеристик
        public static FilterBicyclesViewModel FiltersSpecificationsCount(FilterBicyclesViewModel model)
        {
            model.SelectedSpecifications.CountOfSpecifications =
                model.Specifications.ColorsAndCount.Count() +
                model.Specifications.FrameSizesAndCount.Count() +
                model.Specifications.ManufacturersAndCount.Count() +
                model.Specifications.NumbersOfSpeedsAndCount.Count() +
                model.Specifications.WheelsDiametrAndCount.Count();

            return model;
        }







        // отправка на фильтрацию
        public static FilterBicyclesViewModel Filter(FilterBicyclesViewModel model, BicycleContext context)
        {
            if ((model.SelectedSpecifications.AllFrameSize.Count != 0)
                    || (model.SelectedSpecifications.AllWheelDiameter.Count != 0)
                    || (model.SelectedSpecifications.AllColor.Count != 0)
                    || (model.SelectedSpecifications.AllNumberOfSpeeds.Count != 0)
                    || (model.SelectedSpecifications.AllManufactureCountry.Count != 0))
            {
                //отправка на фильтрацию
                model = FilterBicycles(model, context);
                //количество товаров после прохождения фильтрации
                model.SelectedSpecifications.Bicycles.Count();
            }
            else
            {
                model.SelectedSpecifications.Bicycles = context.Bicycle.ToList();
            }

            return model;
        }



    }
}
