using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YazLab.Models
{
    public class DataInitilaizer:DropCreateDatabaseIfModelChanges<DataContext>
    {
        //protected override void Seed(DataContext context)
        //{
            


        //    var hoca = new List<Hoca>()
        //    {
        //        new Hoca() {Name="Batuhan",Surname="Aral",EMail="batuhanaral3@gmail.com",Numara="191307033",Telefon="5434579738",Password="123456789",Create_Time=DateTime.Now,Update_Time=DateTime.Now },
        //        new Hoca() { Name="Huseyin Oguz",Surname="Cetinkaya",EMail="oguz@gmail.com",Numara="191307003",Telefon="5434579738",Password="123456789",Create_Time=DateTime.Now,Update_Time=DateTime.Now },
        //        new Hoca() { Name="Omer",Surname="Ayyılmazlar",EMail="omer@gmail.com",Numara="191307000",Telefon="5434579738",Password="123456789",Create_Time=DateTime.Now,Update_Time=DateTime.Now },
        //        new Hoca() { Name="Alperen",Surname="Kuzhan",EMail="alperen@gmail.com",Numara="191307031",Telefon="5434579738",Password="123456789",Create_Time=DateTime.Now,Update_Time=DateTime.Now }
        //    };
        //    foreach (var hocas in hoca)
        //    {
        //        context.Hocalar.Add(hocas);
        //    }
        //    context.SaveChanges();

            

        //    var ogreci = new List<Ogrenci>()
        //    {
        //        new Ogrenci() {Name="Veli",Surname="Koyun",EMail="veli@gmail.com",Numara="191307031",Telefon="5434579738",Password="123456789",Create_Time=DateTime.Now,Update_Time=DateTime.Now,HocaId=1 },
        //        new Ogrenci() { Name="Ali",Surname="Koyun",EMail="ali@gmail.com",Numara="191307031",Telefon="5434579738",Password="123456789",Create_Time=DateTime.Now,Update_Time=DateTime.Now,HocaId=2 },
                
        //    };
        //    foreach (var ogrencis in ogreci)
        //    {
        //        context.Ogrenciler.Add(ogrencis);
        //    }
        //    context.SaveChanges();

           


        //    base.Seed(context);
        //}
    }
}