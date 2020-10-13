using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingSample.Entities
{
    public class EditViewModel
    {
        public EditViewModel()
        {
            CarDetails = new List<CarDetailsInfo>();
        }

        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        public string CivilIdNumber { get; set; }
        public List<CarDetailsInfo> CarDetails { get; set; }
    }

    public class CarDetailsInfo
    {
        public int Id { get; set; }
        public string CarNumberPlate { get; set; }

    }
}