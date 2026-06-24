using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project.DatabaseUtilities;
using Project.LoggingUtilities;
using Project.ServerUtilities;
using System.Collections.Generic;

class Restaurant
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string City { get; set; } = "";

    public string Type { get; set; } = "";

    public string Address { get; set; } = "";

    public string Image { get; set; } = "";

    public bool IsKosher { get; set; }

    public double Rating { get; set; }
}

class Booking
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public string BookingDate { get; set; } = "";

    public string BookingTime { get; set; } = "";
}

class Review
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public string UserName { get; set; } = "";

    public string Comment { get; set; } = "";

    public int Stars { get; set; }
}

class Database() : DatabaseCore("database")
{
    public DbSet<Restaurant> Restaurants { get; set; } = default!;

    public DbSet<Booking> Bookings { get; set; } = default!;

    public DbSet<Review> Reviews { get; set; } = default!;
}

class Program
{
    static void Main()
    {
        int port = 5000;

        var server = new Server(port);

        var database = new Database();

        database.Database.EnsureCreated();

        var restaurants = new List<Restaurant>
        {
            new Restaurant
            {
                Name = "סושי טוקיו",
                City = "תל אביב",
                Type = "אסייתי",
                Address = "תובל 21",
                IsKosher = true, 
                Image =
                    "https://images.unsplash.com/photo-1553621042-f6e147245754",
                Rating = 4.8
            },

            new Restaurant
            {
                Name = "פיצה רומא",
                City = "תל אביב",
                Type = "איטלקי",
                Address = "עולי ציון 9",
                IsKosher = false,
                Image =
                    "https://images.unsplash.com/photo-1600891964599-f61ba0e24092",
                Rating = 4.5
            },

            new Restaurant
            {
                Name = "Hudson Brasserie",
                City = "תל אביב",
                Type = "בשרי",
                Address = "הברזל 27",
                IsKosher = true, 
                Image =
                    "https://www.bing.com/th/id/OLC.SoObuK5YxuekuQ480x360?w=200&h=200&c=8&rs=1&qlt=90&cdv=1&dpr=1.5&pid=Local",
                Rating = 4.5
            },

            new Restaurant
            {
                Name = "Juno Cafe",
                City = "תל אביב",
                Type = "בית קפה",
                Address =  "יהודה מכבי 4",
                IsKosher = false,
                Image =
                    "https://images.rest.co.il/Rests/Media/Articles/17895/aeb8e0a2b8a14157b0535a10df4d103a.jpg",
                Rating = 4.5
            },

            new Restaurant
            {
                Name = "בורגר TLV",
                City = "תל אביב",
                Type = "בשרי",
                Address = "רוטשילד 45",
                IsKosher = true, 
                Image =
                    "https://medias.timeout.co.il/www/uploads/2022/05/Agadir01-1000x667.jpg",
                Rating = 4.9
            },

            new Restaurant
            {
                Name = "הדסון",
                City = "תל אביב",
                Type = "בשרי",
                Address = "הברזל 27, רמת החייל",
                IsKosher = true, 
                Image =
                    "https://images.rest.co.il/Customers/80022346/9e0a6fb7abfb4e27ac8bd71fe9a8ff2e_56.jpg",
                Rating = 4.8
            },

               new Restaurant
            {
                Name = "מקס ברנר",
                City = "תל אביב",
                Type = "בית קפה",
                Address = "אלוף קלמן מגן 3, מתחם שרונה",
                IsKosher = false, 
                Image =
                    "https://images.rest.co.il/Customers/80215919/63e4ecf5accf4667b0c78b9b60712129_56.jpg",
                Rating = 4.8
            },
            
               new Restaurant
            {
                Name = "גוסטו",
                City = "תל אביב",
                Type = "איטלקי",
                Address = "פרישמן 90",
                IsKosher = false, 
                Image =
                    "https://images.rest.co.il/Customers/80054273/981a951efd5849b78de68e8cbac12749_56.jpg",
                Rating = 4.8
            },

                 new Restaurant
            {
                Name = "ניני האצי",
                City = "תל אביב",
                Type = "אסייתי",
                Address = "בן יהודה 228,",
                IsKosher = false, 
                Image =
                    "https://images.rest.co.il/Customers/80178589/6f5696bd516c4bbdbd9825e02b539bc1_56.png",
                Rating = 4.8
            },

                new Restaurant
            {
                Name = "בוצ'רי דה ברילוצ'ה",
                City = "תל אביב",
                Type = "בשרי",
                Address = "הברזל 4, רמת החייל",
                IsKosher = false, 
                Image =
                    "https://th.bing.com/th/id/OIP.zOl72qvNVebjFHk8WhyqXwHaFj?w=230&h=180&c=7&r=0&o=7&dpr=1.5&pid=1.7&rm=3",
                Rating = 4.8
            },

                 new Restaurant
            {
                Name = "אליבי בר",
                City = "תל אביב",
                Type = "אסייתי",
                Address = "פרישמן 41, דיזנגוף",
                IsKosher = false, 
                Image =
                    "https://images.rest.co.il/Customers/80331402/49be80ecc04c43e7832bc1d1ab520658_56.png",
                Rating = 4.8
            },

                 new Restaurant
            {
                Name = "ארנסטו",
                City = "תל אביב",
                Type = "איטלקי",
                Address = "בן יהודה 90",
                IsKosher = false, 
                Image =
                    "https://th.bing.com/th/id/OIP.VWDtWNdD667I_u_SkA3x3QHaFj?o=7rm=3&rs=1&pid=ImgDetMain&o=7&rm=3",
                Rating = 4.9
            },

                new Restaurant
            {
                Name = "מחניודה",
                City = "ירושלים",
                Type = "בשרי",
                Address = "מחנה יהודה 5",
                IsKosher = true, 
                Image =
                    "https://images.unsplash.com/photo-1504674900247-0877df9cc836",
                Rating = 4.9
            },

                new Restaurant
            {
                Name = "קפה ירושלים",
                City = "ירושלים",
                Type = "בתי קפה",
                Address = "יפו 12",
                IsKosher = true, 
                Image =
                    "https://images.unsplash.com/photo-1495474472287-4d71bcdd2085",
                Rating = 4.6
            },

               new Restaurant
            {
                Name = "לה סטורי",
                City = "ירושלים",
                Type = "בתי קפה",
                Address = "האייל 16",
                IsKosher = true, 
                Image =
                    "https://images.rest.co.il/Customers/80320913/460140c372a24586903d306073dca068_56.png",
                Rating = 4.6
            },

                   new Restaurant
            {
                Name = "סושי אנד בייגלס",
                City = "ירושלים",
                Type = "אסייתי",
                Address = "ירמיהו 68",
                IsKosher = true, 
                Image =
                    "https://images.rest.co.il/Customers/80381546/e8a6526a57d241409557d67430d7b66c_56.png",
                Rating = 4.6
            },

               new Restaurant
            {
                Name = "פאפאגאיו ירושלים",
                City = "ירושלים",
                Type = "בשרי",
                Address = "יד חרוצים 3",
                IsKosher = true, 
                Image =
                    "https://images.rest.co.il/Customers/80054013/49f19311f75f48a0b523eb7db8f337dc_56.png",
                Rating = 4.6
            },

               new Restaurant
            {
                Name = "נוקטורנו",
                City = "ירושלים",
                Type = "בית קפה",
                Address = "בצלאל 7",
                IsKosher = true, 
                Image =
                    "https://images.rest.co.il/Customers/29490890/679f744f9adf49cab1d89656f13291dc_56.jpg",
                Rating = 4.6
            },

           new Restaurant
            {
                Name = "פלומינו",
                City = "ירושלים",
                Type = "איטלקי",
                Address = "המלך ג'ורג' 41",
                IsKosher = true, 
                Image =
                    "https://images.rest.co.il/Customers/80338684/b757ea614a51489bb601de5662fcce50_56.jpg",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "קיטשן בראסרי",
                City = "ירושלים",
                Type = "בתי קפה",
                Address = "ממילא 13, שדרות אלרוב ממילא",
                IsKosher = true, 
                Image =
                    "https://images.rest.co.il/Customers/80385723/6befd3df64a049ed80c0d107e3ced013_56.png",
                Rating = 4.8
            },

                    new Restaurant
            {
                Name = "פיצה קראפט",
                City = "ירושלים",
                Type = "איטלקי",
                Address = "התפוח 12, מחנה יהודה",
                IsKosher = true, 
                Image =
                    "https://images.rest.co.il/Customers/80309145/a3a984872d364badb7499227ecf28995_56.png",
                Rating = 4.8
            },

               new Restaurant
            {
                Name = "אנטוני",
                City = "ירושלים",
                Type = "איטלקי",
                Address = "שושן 4",
                IsKosher = false, 
                Image =
                    "https://images.rest.co.il/Customers/80320913/460140c372a24586903d306073dca068_56.png",
                Rating = 4.6
            },

               new Restaurant
            {
                Name = "sheyan",
                City = "ירושלים",
                Type = "אסייתי",
                Address = "רחוב רמב״ן 8",
                IsKosher = true, 
                Image =
                    "https://images.openai.com/static-rsc-4/aFJzW5ngkMPN_JIgQW2rp8zYLWimLKxGs1dLeH0xevF5Ej5L3b9W1wJALoJUd3OhWW11YNLZRlcIaT4s6IbLzRe3C4I_SKl86wJaJvB4o2MtJFsaBBYtdPYA3v5sI4DzxgPBMQzhxSMx_sdhjtTG54X02H9Y_o6ly6XaPACuCyrfoTuHkQbySEOmxeYRxcvh?purpose=fullsize",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "station 9",
                City = "ירושלים",
                Type = "אסייתי",
                Address = "דוד אמז 4",
                IsKosher = true, 
                Image =
                    "https://images.openai.com/static-rsc-4/qe6pEvyyCjRCNhGttnin8MwI8-KxMnhkBthHXAhdLaXQ1ER-zgTCTvfDDDxLz_bekrDmCkJQmj5EmfNRx8_dQf9Sm0Dsk5el5E-O9XYckdl55y3SUu-faTbjb8i_c89nGXfIUzi8DwVlFvam0RKFdMSMOBBSL_usMKxtZG2UVAaiMmm-76Muf6pDaLdgYp-u?purpose=fullsize",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "קפאו",
                City = "פתח תקווה",
                Type = "אסייתי",
                Address = "תוצרת הארץ 3",
                IsKosher = false, 
                Image =
                    "https://media.istockphoto.com/id/2212437605/photo/sushi-platter-with-sashimi-and-rolls.jpg?b=1&s=612x612&w=0&k=20&c=06_BzGarZyPEr_xgHVejkwtIfx08DobfcnvEKeCIV7E=",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "thai chu",
                City = "פתח תקווה",
                Type = "אסייתי",
                Address = "ברקת 9",
                IsKosher = false, 
                Image =
                    "https://media.istockphoto.com/id/913931820/photo/chef-in-restaurant-kitchen-at-stove-with-high-burning-flames.jpg?b=1&s=612x612&w=0&k=20&c=NxOph5wF85uaRbXJPFY4Tbfx6QnPvGB-F_wQjH9p19g=",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "ג'אפן ג'אפן פתח תקווה",
                City = "פתח תקווה",
                Type = "אסייתי",
                Address = "העצמאות 63",
                IsKosher = true, 
                Image =
                    "https://media.istockphoto.com/id/1312283557/photo/classic-thai-food-dishes.jpg?b=1&s=612x612&w=0&k=20&c=riDDbZKpS5_BZCqM1KA_XjQ3zyywvbZN3DSCcZ69XaY=",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "nini choo",
                City = "פתח תקווה",
                Type = "אסייתי",
                Address = "הסיבים 18",
                IsKosher = true, 
                Image =                
                    "https://media.istockphoto.com/id/545286388/photo/chinese-food-blank-background.jpg?b=1&s=612x612&w=0&k=20&c=3YJ8cHPcY2-Hxzcbu9ZFPgm_fDegRqL77VZADwD38-A=",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "vivino",
                City = "פתח תקווה",
                Type = "איטלקי",
                Address = "תוצרת הארץ 2",
                IsKosher = true, 
                Image =
                    "https://content.pexels.com/aigc-bundle/images/b2148c89-8119-42b4-94c5-dbef74deab6d.jpg",
                Rating = 4.6
            },

            new Restaurant
            {
                Name = "מריונלה",
                City = "פתח תקווה",
                Type = "איטלקי",
                Address = "הסיבים 18",
                IsKosher = true, 
                Image =
                    "https://media.istockphoto.com/id/488960908/photo/homemade-pasta.jpg?b=1&s=612x612&w=0&k=20&c=EYJ-tXFoLzl030GbqshihHD1LlHRwifGnV7zZ2hadMw=",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "goomba",
                City = "פתח תקווה",
                Type = "איטלקי",
                Address = "לשם 11",
                IsKosher = false, 
                Image =
                    "https://media.istockphoto.com/id/1227415751/photo/full-table-of-italian-meals-on-plates-pizza-pasta-ravioli-carpaccio-caprese-salad-and-tomato.jpg?b=1&s=612x612&w=0&k=20&c=tiPc3o6o65Ok6dYLtZza4mXPK-z59OBqnWqtuQPY3EU=",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "joya deatalia",
                City = "פתח תקווה",
                Type = "איטלקי",
                Address = "הסיבים 18",
                IsKosher = true, 
                Image =
                    "https://media.istockphoto.com/id/637214478/photo/pasta-plate.jpg?b=1&s=612x612&w=0&k=20&c=qEGakiVzhvYQW4uTHbAgeU4qogOcq-w0ZkIOQNEtdp4=",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "pitmaster",
                City = "פתח תקווה",
                Type = "בשרי",
                Address = "ברקת 4",
                IsKosher = true, 
                Image =
                    "https://media.istockphoto.com/id/500466008/photo/beef-steak.jpg?b=1&s=612x612&w=0&k=20&c=YCIgji9aQF8aBN0QGtZjIf5L2JCZ9bVjcHzbj92nqHU=",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "entrecote grill house",
                City = "פתח תקווה",
                Type = "בשרי",
                Address = "א.ד.גורדון 28",
                IsKosher = true, 
                Image =
                    "https://media.istockphoto.com/id/1213640567/photo/grilled-ribeye-beef-steak-with-rosemary-and-salt.jpg?b=1&s=612x612&w=0&k=20&c=cSuv4B2tqWc6CFLDfUZ-Jrww8rUDlzXyNe0LvhaPzPQ=",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "לחם בשר",
                City = "פתח תקווה",
                Type = "בשרי",
                Address = "תוצרת הארץ 3",
                IsKosher = true, 
                Image =
                    "https://media.istockphoto.com/id/2154353434/photo/mens-hands-holding-knife-and-fork-cutting-grilled-steak.jpg?b=1&s=612x612&w=0&k=20&c=x9qC28dEEojdtb2MWHdBYCObWQKP64M7n2eNIqNoMBc=",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "ayalon taverns",
                City = "פתח תקווה",
                Type = "בשרי",
                Address = "דנמרק 4",
                IsKosher = true, 
                Image =
                    "https://www.bing.com/th/id/OIP.LfqdZ97P-KFKgcMv1NV-WgHaJQ?w=193&h=241&c=8&rs=1&qlt=90&o=6&dpr=1.5&pid=3.1&rm=2",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "biscotti",
                City = "פתח תקווה",
                Type = "בתי קפה",
                Address = "העצמאות 104",
                IsKosher = true, 
                Image =
                    "https://media.istockphoto.com/id/1859646927/photo/closeup-image-of-a-man-and-a-woman-clinking-white-coffee-mugs-in-cafe.jpg?b=1&s=612x612&w=0&k=20&c=65GrpOlHHFI6xclmLItHEvIxTP3TlLIKrbcWDaEPjng=",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "bulochka",
                City = "פתח תקווה",
                Type = "בתי קפה",
                Address = "פינסקר 29",
                IsKosher = true, 
                Image =
                    "https://media.istockphoto.com/id/2232885441/photo/white-cup-of-black-coffee-on-coffee-beans-background-top-view.jpg?b=1&s=612x612&w=0&k=20&c=tDZdLhbSQqwxzgtPd5YCD-0j9f_BfIqZuQCeT0UIul4=",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "coffee don",
                City = "פתח תקווה",
                Type = "בתי קפה",
                Address = "זוסיה שפיגל 1",
                IsKosher = true, 
                Image =
                    "https://th.bing.com/th/id/OIP.mahtksW2Cyc0ATDx2nB9ZwHaJ4?w=121&h=180&c=7&r=0&o=7&dpr=1.5&pid=1.7&rm=3",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "קפה נויה",
                City = "פתח תקווה",
                Type = "בתי קפה",
                Address = "בלפור 4",
                IsKosher = true, 
                Image =
                    "https://content.pexels.com/aigc-bundle/images/66d25f28-091e-44d0-8868-fec630ab9539.jpg",
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "asian deli",
                City = "הוד השרון",
                Type = "אסייתי",
                Address = "הבנים 15",
                IsKosher = true, 
                Image =                
                    "https://media.istockphoto.com/id/1053854126/photo/all-you-can-eat-sushi.jpg?b=1&s=612x612&w=0&k=20&c=vhfVMBBDr6FwPcIZVHKElAbMVUBJNDvEDlNaF67JP_0=",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "yamatoya bistro bar",
                City = "הוד השרון",
                Type = "אסייתי",
                Address = "בני ברית 6",
                IsKosher = true, 
                Image =                
                    "https://media.istockphoto.com/id/1616721452/photo/anonymous-people-having-lunch-with-sushi.jpg?b=1&s=612x612&w=0&k=20&c=p3YkAJ-T3oI5X85xUl2OyqTIVg9fwaBEgkDfSMmSa5I=",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "arigsto sushi bar",
                City = "הוד השרון",
                Type = "אסייתי",
                Address = "10 סוקולוב",
                IsKosher = true, 
                Image =                
                    "https://media.istockphoto.com/id/1365977387/photo/ramen-with-steaming-sizzle.jpg?b=1&s=612x612&w=0&k=20&c=7OPPO6AjMXYbPVzjZcQRXlLdz87ThgJuqlbC9scpgP8=",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "nay lon",
                City = "הוד השרון",
                Type = "אסייתי",
                Address = "סוקולוב 46",
                IsKosher = true, 
                Image =                
                    "https://media.istockphoto.com/id/1135293039/photo/ramen-asian-noodle-in-broth-with-beef-tongue-meat-mushroom-and-ajitama-pickled-egg-in-bowl-on.jpg?b=1&s=612x612&w=0&k=20&c=iWX4ZnHntJ7TCV8BaE6mRTpQs4AkAxLoqKgHSknQbrc=",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "nono",
                City = "הוד השרון",
                Type = "איטלקי",
                Address = "זבוטינסקי 2",
                IsKosher = false, 
                Image =                
                    "https://media.istockphoto.com/id/938742222/photo/cheesy-pepperoni-pizza.jpg?b=1&s=612x612&w=0&k=20&c=ZcLXrogjpyc5froC5ZIP-0uepbhldATwmCbt3mzViGQ=",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "Nono & Mimi",
                City = "הוד השרון",
                Type = "איטלקי",
                Address = "סוקולוב 46",
                IsKosher = true, 
                Image =                
                    "https://media.istockphoto.com/id/1442417585/photo/person-getting-a-piece-of-cheesy-pepperoni-pizza.jpg?b=1&s=612x612&w=0&k=20&c=HU9fGxunk5fCW3pN-I1cS53X8--QBgYYDUPInhyTMZU=",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "saporito",
                City = "הוד השרון",
                Type = "איטלקי",
                Address = "רמתיים 96",
                IsKosher = false, 
                Image =                
                    "https://media.istockphoto.com/id/1189709277/photo/pasta-penne-with-roasted-tomato-sauce-mozzarella-cheese-grey-stone-background-top-view.jpg?b=1&s=612x612&w=0&k=20&c=5F4SvP5LPjDtjDqohFrTSV1qLrjxG1Edniu4I9WzM8c=",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "ragazzi",
                City = "הוד השרון",
                Type = "איטלקי",
                Address = "רמתיים 24",
                IsKosher = true, 
                Image =                
                    "https://media.istockphoto.com/id/1144823591/photo/spaghetti-in-a-dish-on-a-white-background.jpg?b=1&s=612x612&w=0&k=20&c=yWXnUB0TbGVWD5NE-dbu33KzQ_ujPXWQtU7809AUwxE=",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "chop chop hod hasharon",
                City = "הוד השרון",
                Type = "בשרי",
                Address = "הבנים 3",
                IsKosher = false, 
                Image =                
                    "https://media.istockphoto.com/id/535786572/photo/grilled-striploin-steak.jpg?b=1&s=612x612&w=0&k=20&c=4MAcTyBrF7XkcltOt9WpTXwM6-uuf7qWUP6-j7srefc=",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "meat time",
                City = "הוד השרון",
                Type = "בשרי",
                Address = "סוקולוב 46",
                IsKosher = false, 
                Image =                
                    "https://th.bing.com/th/id/OIP.mgNMn9nLnnoVzXzYSiJLvwHaLH?w=186&h=279&c=7&r=0&o=7&dpr=1.5&pid=1.7&rm=3",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "diner",
                City = "הוד השרון",
                Type = "בשרי",
                Address = "הרחבון 2",
                IsKosher = true, 
                Image =                
                    "https://th.bing.com/th/id/OIP.aqHchCJ94qkdvxIa1SrDlQHaLH?w=111&h=180&c=7&r=0&o=7&dpr=1.5&pid=1.7&rm=3",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "pasta mia",
                City = "הוד השרון",
                Type = "בשרי",
                Address = "הבנים 3",
                IsKosher = true, 
                Image =                
                    "https://th.bing.com/th/id/OIF.AuufyOyAsHz4yHc0TcT8Pw?w=328&h=184&c=7&r=0&o=7&dpr=1.5&pid=1.7&rm=3",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "landwer cafe",
                City = "הוד השרון",
                Type = "בתי קפה",
                Address = "רמתיים 18",
                IsKosher = true, 
                Image =                
                    "https://th.bing.com/th/id/OIP.ANp738uQSg9Zbo97dvG5WQHaD4?w=338&h=180&c=7&r=0&o=7&dpr=1.5&pid=1.7&rm=3",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "alexa wine & coffee house",
                City = "הוד השרון",
                Type = "בתי קפה",
                Address = "רמתיים 96",
                IsKosher = true, 
                Image =                
                    "https://th.bing.com/th/id/OIP.qJ63h72e1j5vyJg0bHZy0QAAAA?w=239&h=181&c=7&r=0&o=7&dpr=1.5&pid=1.7&rm=3",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "קפה גן",
                City = "הוד השרון",
                Type = "בתי קפה",
                Address = "הציונות 7",
                IsKosher = true, 
                Image =                
                    "https://images.pexels.com/photos/1448721/pexels-photo-1448721.jpeg?dpr=2&w=341.25&h=552.5&fit=crop",                
                Rating = 4.6
            },

                new Restaurant
            {
                Name = "ארצ'י ואמה",
                City = "הוד השרון",
                Type = "בתי קפה",
                Address = "הגאולה 26",
                IsKosher = true, 
                Image =                
                    "https://media.istockphoto.com/id/1829241109/photo/enjoying-a-brunch-together.jpg?b=1&s=612x612&w=0&k=20&c=Mn_EPBAGwtzh5K6VyfDmd7Q5eJFXSHhGWVr3T4WDQRo=",                
                Rating = 4.6
            },

      
        };
        // הוספת המסעדות לדאטאבייס
        // רק אם הן עדיין לא קיימות
        foreach (var restaurant in restaurants)
        {
            if (!database.Restaurants.Any(
                r => r.Name == restaurant.Name))
            {
                database.Restaurants.Add(restaurant);
            }
        }

        database.SaveChanges();

        Console.WriteLine("The server is running");

        // לולאה אינסופית שמחכה לבקשות מהלקוח
        while (true)
        {
            var request = server.WaitForRequest();

            try
            {
                // כל המסעדות
                if (request.Name == "getRestaurants")
                {
                    request.Respond(
                        database.Restaurants
                    );
                }

                // פילטר עיר + סוג
                else if (request.Name == "getFilteredRestaurants")
                {
                    dynamic data =
                        request.GetParams<dynamic>();

                    string city = data.city ?? "";

                    string type = data.type ?? "";

                    var filteredRestaurants =
                        database.Restaurants.AsQueryable();

                    if (!string.IsNullOrEmpty(city))
                    {
                        filteredRestaurants =
                            filteredRestaurants.Where(
                                r => r.City == city
                            );
                    }

                    if (!string.IsNullOrEmpty(type))
                    {
                        filteredRestaurants =
                            filteredRestaurants.Where(
                                r => r.Type == type
                            );
                    }

                    request.Respond(
                        filteredRestaurants.ToList()
                    );
                }

                // הזמנה
                else if (request.Name == "addBooking")
                {
                    var booking =
                        request.GetParams<Booking>();

                    database.Bookings.Add(booking);

                    database.SaveChanges();

                    request.Respond("Booking Added");

                    
                }

                // ביקורות
                else if (request.Name == "getReviews")
                {
                    request.Respond(
                        database.Reviews.ToList()
                    );
                }

                // הוספת ביקורת
                else if (request.Name == "addReview")
{
    var review =
        request.GetParams<Review>();

    Console.WriteLine(
        $"RestaurantId={review.RestaurantId}, Stars={review.Stars}"
    );

    database.Reviews.Add(review);

    database.SaveChanges();

    var reviews =
        database.Reviews
        .Where(r => r.RestaurantId == review.RestaurantId)
        .ToList();

    Console.WriteLine(
        $"Reviews Count = {reviews.Count}"
    );

    double average =
        reviews.Average(r => r.Stars);

    Console.WriteLine(
        $"Average = {average}"
    );

    var restaurant =
        database.Restaurants
        .First(r => r.Id == review.RestaurantId);

    restaurant.Rating = average;

    database.SaveChanges();

    request.Respond("Review Added");
}
            }
            catch (Exception exception)
            {
                request.SetStatusCode(500);

                Log.WriteException(exception);
            }
        }
    }
}
