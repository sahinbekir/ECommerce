using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using City = EntityLayer.Concrete.City;

namespace ECommerce.Controllers
{
    [AllowAnonymous]
    public class ModeratorController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public ModeratorController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        GenderManager _genderManager = new GenderManager(new EfGenderRepository());
        CityManager _cityManager = new CityManager(new EfCityRepository());
        StateManager _stateManager = new StateManager(new EfStateRepository());

        AboutUsManager _aboutUsManager = new AboutUsManager(new EfAboutUsRepository());
        ContactUsManager _contactUsManager = new ContactUsManager(new EfContactUsRepository());

        BrandManager _brandManager = new BrandManager(new EfBrandRepository());
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        SubCategoryManager _subCategoryManager = new SubCategoryManager(new EfSubCategoryRepository());

        ProductManager _productManager = new ProductManager(new EfProductRepository());
        StockPieceManager _stockPieceManager = new StockPieceManager(new EfStockPieceRepository());

        ShoppingCartManager _shoppingCartManager = new ShoppingCartManager(new EfShoppingCartRepository());
        ProductCartManager _productCartManager = new ProductCartManager(new EfProductCartRepository());
        NewsProductManager _newsProductManager = new NewsProductManager(new EfNewsProductRepository());

        ProductCommentManager _productCommentManager = new ProductCommentManager(new EfProductCommentRepository());

        NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
        MessageManager _messageManager = new MessageManager(new EfMessageRepository());

        ProductRatingManager _productRatingManager = new ProductRatingManager(new EfProductRatingRepository());

        // GENDER-CITY-STATE
        public IActionResult Index()
        {
            var verify = _userManager.Users.FirstOrDefault();
            if (verify != null) { return RedirectToAction("Index", "Moderator"); }
            else
            {
                // GENDER
                var gender = new Gender { Name = "Person - Male", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _genderManager.TAdd(gender);

                gender = new Gender { Name = "Person - Female", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _genderManager.TAdd(gender);

                gender = new Gender { Name = "Company - Unity", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _genderManager.TAdd(gender);


                // CITY
                var city = new City() { Name = "Adana" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Adıyaman" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Afyon" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Ağrı" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Amasya" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Ankara" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Antalya" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Artvin" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Aydın" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Balıkesir" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Bilecik" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Bingöl" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Bitlis" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Bolu" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Burdur" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Bursa" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Çanakkale" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Çankırı" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Çorum" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Denizli" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Diyarbakır" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Edirne" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Elazığ" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Erzincan" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Erzurum" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Eskişehir" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Gaziantep" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Giresun" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Gümüşhane" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Hakkari" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Hatay" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Isparta" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Mersin" };
                _cityManager.TAdd(city);

                city = new City() { Name = "İstanbul" };
                _cityManager.TAdd(city);

                city = new City() { Name = "İzmir" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Kars" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Kastamonu" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Kayseri" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Kırklareli" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Kırşehir" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Kocaeli" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Konya" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Kütahya" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Malatya" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Manisa" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Kahramanmaraş" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Mardin" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Muğla" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Muş" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Nevşehir" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Niğde" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Ordu" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Rize" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Sakarya" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Samsun" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Siirt" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Sinop" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Sivas" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Tekirdağ" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Tokat" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Trabzon" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Tunceli" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Şanlıurfa" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Uşak" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Van" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Yozgat" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Zonguldak" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Aksaray" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Bayburt" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Karaman" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Kırıkkale" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Batman" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Şırnak" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Bartın" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Ardahan" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Iğdır" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Yalova" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Karabük" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Kilis" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Osmaniye" };
                _cityManager.TAdd(city);

                city = new City() { Name = "Düzce" };
                _cityManager.TAdd(city);


                // STATE
                var state = new State { CityId = 1, Name = "Adana Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 2, Name = "Adıyaman Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 3, Name = "Afyon Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 4, Name = "Ağrı Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 5, Name = "Amasya Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 6, Name = "Ankara Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 7, Name = "Antalya Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 8, Name = "Artvin Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 9, Name = "Aydın Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 10, Name = "Balıkesir Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 11, Name = "Bilecik Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 12, Name = "Bingöl Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 13, Name = "Bitlis Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 14, Name = "Bolu Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 15, Name = "Burdur Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 16, Name = "Bursa Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 17, Name = "Çanakkale Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 18, Name = "Çankırı Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 19, Name = "Çorum Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 20, Name = "Denizli Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 21, Name = "Diyarbakır Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 22, Name = "Edirne Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 23, Name = "Elazığ Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 24, Name = "Erzincan Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 25, Name = "Erzurum Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 26, Name = "Eskişehir Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 27, Name = "Gaziantep Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 28, Name = "Giresun Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 29, Name = "Gümüşhane Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 30, Name = "Hakkari Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 31, Name = "Hatay Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 32, Name = "Isparta Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 33, Name = "Mersin Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 34, Name = "İstanbul Avrupa Yakası Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 34, Name = "İstanbul Asya Yakası Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 35, Name = "İzmir Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 36, Name = "Kars Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 37, Name = "Kastamonu Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 38, Name = "Kayseri Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 39, Name = "Kırklareli Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 40, Name = "Kırşehir Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 41, Name = "Kocaeli Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 42, Name = "Konya Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 43, Name = "Kütahya Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 44, Name = "Malatya Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 45, Name = "Manisa Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 46, Name = "Kahramanmaraş Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 47, Name = "Mardin Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 48, Name = "Muğla Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 49, Name = "Muş Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 50, Name = "Nevşehir Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 51, Name = "Niğde Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 52, Name = "Ordu Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 53, Name = "Rize Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 54, Name = "Sakarya Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 55, Name = "Samsun Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 56, Name = "Siirt Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 57, Name = "Sinop Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 58, Name = "Sivas Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 59, Name = "Tekirdağ Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 60, Name = "Tokat Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 61, Name = "Trabzon Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 62, Name = "Tunceli Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 63, Name = "Şanlıurfa Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 64, Name = "Uşak Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 65, Name = "Van Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 66, Name = "Yozgat Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 67, Name = "Zonguldak Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 68, Name = "Aksaray Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 69, Name = "Bayburt Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 70, Name = "Karaman Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 71, Name = "Kırıkkale Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 72, Name = "Batman Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 73, Name = "Şırnak Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 74, Name = "Bartın Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 75, Name = "Ardahan Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 76, Name = "Iğdır Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 77, Name = "Yalova Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 78, Name = "Karabük Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 79, Name = "Kilis Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 80, Name = "Osmaniye Merkez" };
                _stateManager.TAdd(state);

                state = new State { CityId = 81, Name = "Düzce Merkez" };
                _stateManager.TAdd(state);

            }
            return RedirectToAction("Index2", "Moderator");
        }

        // ABOUTUS-CONTACTUS
        public IActionResult Index2()
        {
            var verify = _userManager.Users.FirstOrDefault();
            if (verify != null) { return RedirectToAction("Index", "Moderator"); }
            else
            {
                var aboutus = new AboutUs
                {
                    ImageV1 = "/Media/eci1.png",
                    ImageV2 = "/Media/eci2.png",
                    MovieV1 = "/Media/ecm1.mp4",
                    Company = "E-Com SB",
                    Email = "ecom@come.io",
                    Phone = "5714531881",
                    Country = "Turkey",
                    State = "Antakia",
                    MapLocationV1 = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d103000.43678361534!2d36.02209944082478!3d36." +
                    "22093929994746!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x1525c24ab71e4761%3A0x9151857a8d1bab72!2zQW50YWt5YSwgS8O8w6fDvGtkYWx5YW4sIEFudGFreWEvSGF0YXk!" +
                    "5e0!3m2!1str!2str!4v1670834422901!5m2!1str!2str",
                    DetailsV1 = "DetailsV1 First",
                    DetailsV2 = "DetailsV2 Second",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                };
                _aboutUsManager.TAdd(aboutus);

                var contactus = new ContactUs
                {
                    UserName = "Contacter 1",
                    Mail = "contact1@ecom.io",
                    Subject = "Subject1",
                    Context = "Context1 Context1 Context1 Context1 Context1 Context1 Context1",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                };
                _contactUsManager.TAdd(contactus);

                contactus = new ContactUs
                {
                    UserName = "Contacter 2",
                    Mail = "contact2@ecom.io",
                    Subject = "Subject2",
                    Context = "Context2 Context2 Context2 Context2 Context2 Context2 Context2",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                };
                _contactUsManager.TAdd(contactus);
            }
            return RedirectToAction("Index3", "Moderator");
        }

        // 
        public IActionResult Index3()
        {
            var verify = _userManager.Users.FirstOrDefault();
            if (verify != null) { return RedirectToAction("Index", "Moderator"); }
            else
            {
                var brand = new Brand() { Name = "Nike", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _brandManager.TAdd(brand);
                brand = new Brand() { Name = "Adidas", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _brandManager.TAdd(brand);
                brand = new Brand() { Name = "Polo", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _brandManager.TAdd(brand);

                var category = new Category()
                {
                    Name = "Shoe",
                    Description = "There are various styles of shoes for different occasions, such as athletic shoes, dress shoes, sandals, and boots.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                };
                _categoryManager.TAdd(category);
                category = new Category()
                {
                    Name = "T-Shirt",
                    Description = "Below we have mentioned the most popular necklines that have given the t-shirt a modern twist without compromising on its aesthetics.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                };
                _categoryManager.TAdd(category);
                category = new Category()
                {
                    Name = "Pants",
                    Description = "Depending on the definition, there are between 12 and 16 different types of trousers based on factors such as the material used," +
                    " design elements, fit, and occasion. Most men will be familiar with classics like jeans, chinos, and sweatpants, as well as the many variations on dress pants.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                };
                _categoryManager.TAdd(category);
                category = new Category()
                {
                    Name = "Jacket",
                    Description = "What are the different types of jackets? There are several jacket styles to choose from, and some of the types that" +
                    " every man should own include; bomber, biker, trucker, denim, track, blouson, hooded, overcoat, parka, pea coat, trench coat, raincoat, shearling jacket, anorak, and a Crombie coat.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                };
                _categoryManager.TAdd(category);

                var subcategory = new SubCategory()
                {
                    CategoryId = 1,
                    Name = "Dress Shoes",
                    Description = "A dress shoe is anything that's not a sneaker, boot or any style of footwear that exposes your feet – " +
                    "which means a brogue, a Derby, an Oxford or a monk-strap shoe.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                };
                _subCategoryManager.TAdd(subcategory);
                subcategory = new SubCategory()
                {
                    CategoryId = 1,
                    Name = "Boots",
                    Description = "Boots are commonly used for work wear, industry, mining, military, riding, walking in snow," +
                    " skiing, snowboarding, and ice skating. However, with boots now being available in smooth and soft material, it is fashionable for women to use boots with dresses.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                };
                _subCategoryManager.TAdd(subcategory);
                subcategory = new SubCategory()
                {
                    CategoryId = 1,
                    Name = "Athletic Shoes",
                    Description = "A shoe designed to be worn for sports, exercising, or recreational activity, as racquetball," +
                    " jogging, or aerobic dancing.",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                };
                _subCategoryManager.TAdd(subcategory);
                subcategory = new SubCategory() { CategoryId = 2, Name = "Seasonal Tee", Description = "For spring...", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _subCategoryManager.TAdd(subcategory);
                subcategory = new SubCategory() { CategoryId = 2, Name = "Summer Tee", Description = "For summer...", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _subCategoryManager.TAdd(subcategory);
                subcategory = new SubCategory() { CategoryId = 3, Name = "Jeans", Description = "Jeans blue pants.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _subCategoryManager.TAdd(subcategory);
                subcategory = new SubCategory() { CategoryId = 3, Name = "Suits", Description = "Suit pants.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _subCategoryManager.TAdd(subcategory);
                subcategory = new SubCategory() { CategoryId = 3, Name = "Shorts", Description = "Short pants.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _subCategoryManager.TAdd(subcategory);
                subcategory = new SubCategory() { CategoryId = 4, Name = "Suits", Description = "Suit jackets.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _subCategoryManager.TAdd(subcategory);
                subcategory = new SubCategory() { CategoryId = 4, Name = "Jeans", Description = "Jeans blue jackets.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _subCategoryManager.TAdd(subcategory);
            }
            return RedirectToAction("Index4", "Moderator");
        }

        // ROLE-USER-USERROLES
        public async Task<IActionResult> Index4()
        {
            var verify = _userManager.Users.FirstOrDefault();
            if (verify != null) { return RedirectToAction("Index", "Moderator"); }
            else
            {
                AppRole role1 = new AppRole
                {
                    Name = "Admin"
                };
                var result = await _roleManager.CreateAsync(role1);

                AppRole role2 = new AppRole
                {
                    Name = "User"
                };
                result = await _roleManager.CreateAsync(role2);

                AppRole role3 = new AppRole
                {
                    Name = "Seller"
                };
                result = await _roleManager.CreateAsync(role3);

                AppRole role4 = new AppRole
                {
                    Name = "Buyer"
                };
                result = await _roleManager.CreateAsync(role4);


                AppUser admin1 = new AppUser();
                admin1.Email = "admin1@ec.io";
                admin1.UserName = "admin1";
                admin1.FullName = "Admin Admin1";
                admin1.PhoneNumber = "5311313071";
                admin1.BornDate = DateTime.Now;
                admin1.CityId = 6;
                admin1.StateId = 1;
                admin1.Address = "Atatürk Cd. Cumhuriyet Sk. no:1881";
                admin1.GenderId = 3;
                admin1.ImageUrl = "/Media/ecpp.png";
                admin1.RegisterDate = DateTime.Now;
                admin1.ProfileUpdatedDate = DateTime.Now;
                admin1.IsBlocked = false;
                admin1.IsDeleted = false;
                var Password1 = "Aa.12345";
                var result3 = await _userManager.CreateAsync(admin1, Password1);

                AppUser user1 = new AppUser();
                user1.Email = "user1@ec.io";
                user1.UserName = "user1";
                user1.FullName = "User User1";
                user1.PhoneNumber = "2711378654";
                user1.BornDate = DateTime.Now;
                user1.CityId = 48;
                user1.StateId = 1;
                user1.Address = "Atatürk Cd. Cumhuriyet Sk. no:1453";
                user1.GenderId = 2;
                user1.ImageUrl = "/Media/ecpp.png";
                user1.RegisterDate = DateTime.Now;
                user1.ProfileUpdatedDate = DateTime.Now;
                user1.IsBlocked = false;
                user1.IsDeleted = false;
                var Password2 = "Aa.12345";
                var result4 = await _userManager.CreateAsync(user1, Password2);

                AppUser user2 = new AppUser();
                user2.Email = "user2@ec.io";
                user2.UserName = "user2";
                user2.FullName = "User User2";
                user2.PhoneNumber = "7311373307";
                user2.BornDate = DateTime.Now;
                user2.CityId = 31;
                user2.StateId = 1;
                user2.Address = "Atatürk Cd. Cumhuriyet Sk. no:1071";
                user2.GenderId = 1;
                user2.ImageUrl = "/Media/ecpp.png";
                user2.RegisterDate = DateTime.Now;
                user2.ProfileUpdatedDate = DateTime.Now;
                user2.IsBlocked = false;
                user2.IsDeleted = false;
                var Password3 = "Aa.12345";
                var result5 = await _userManager.CreateAsync(user2, Password3);

                var user1admin = _userManager.Users.FirstOrDefault(x => x.UserName == "admin1");
                await _userManager.AddToRoleAsync(user1admin, "ADMIN");

                var user2user = _userManager.Users.FirstOrDefault(x => x.UserName == "user1");
                await _userManager.AddToRoleAsync(user2user, "USER");
                var user3user = _userManager.Users.FirstOrDefault(x => x.UserName == "user2");
                await _userManager.AddToRoleAsync(user3user, "USER");

            }
            return RedirectToAction("Index5", "Moderator");
        }

        // PRODUCT
        public IActionResult Index5()
        {
            var verify = _userManager.Users.FirstOrDefault();
            if (verify == null) { return RedirectToAction("Index", "Moderator"); }
            else
            {
                var product1 = new Product() { UserId = 2, CategoryId = 1, Cost = 90, Version = "2022 Winter", Description = "A football shoe. Example1 : " +
                    "Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. " +
                    "It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\n" +
                    "I started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description," +
                    " including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator." +
                    " If you need something more niche related, I recommend checking out the advanced product description generator. A football shoe. Example : Here are some custom show product description " +
                    "examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of " +
                    "sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 " +
                    "words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\n" +
                    "If you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description generator." +
                    " A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller" +
                    " category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\n" +
                    "I started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description," +
                    " including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator." +
                    " If you need something more niche related, I recommend checking out the advanced product description generator.",
                    BrandId = 1, Name = "HyperVenom", ImageUrl1 = "/Media/ecpp2.png", ImageUrl2 = "/Media/ecpp3.png", ThumbnailImgUrl = "/Media/ecpp1.png", MovieUrl = "/Media/ecpm.mp4",
                    SubCategoryId = 3, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _productManager.TAdd(product1);
                var product2 = new Product() { UserId = 3, CategoryId = 1, Cost = 99, Version = "2022 Winter", Description = "A football shoe. Example2 : " +
                    "Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category." +
                    " It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and " +
                    "then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description " +
                    "focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend " +
                    "checking out the advanced product description generator. A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I" +
                    " picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety." +
                    "\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, " +
                    "including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator." +
                    " If you need something more niche related, I recommend checking out the advanced product description generator. A football shoe. Example : Here are some custom show product description" +
                    " examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a" +
                    " lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at " +
                    "least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\n" +
                    "If you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description" +
                    " generator.", BrandId = 2, Name = "Mercurial", ImageUrl1 = "/Media/ecpp2.png",
                    ImageUrl2 = "/Media/ecpp3.png",
                    ThumbnailImgUrl = "/Media/ecpp1.png", MovieUrl = "/Media/ecpm.mp4",
                    SubCategoryId = 3, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _productManager.TAdd(product2);
                var product3 = new Product() { UserId = 2, CategoryId = 1, Cost = 90, Version = "2022 Winter", Description = "A football shoe. Example3 : " +
                    "Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the" +
                    " best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI" +
                    " started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 min" +
                    "utes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need m" +
                    "ore descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced produc" +
                    "t description generator. A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop" +
                    ". I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were " +
                    "popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each des" +
                    "cription is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on detail" +
                    "s unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche re" +
                    "lated, I recommend checking out the advanced product description generator. A sports shoe. Example : Here are some custom show product description exa" +
                    "mples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer " +
                    "when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator " +
                    "and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some rese" +
                    "arch. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product des" +
                    "cription generator. If you need something more niche related, I recommend checking out the advanced product description generator.",
                    BrandId = 1, Name = "Winter Climber", ImageUrl1 = "/Media/ecpp2.png",
                    ImageUrl2 = "/Media/ecpp3.png",
                    ThumbnailImgUrl = "/Media/ecpp1.png", MovieUrl = "/Media/ecpm.mp4", 
                    SubCategoryId = 2, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _productManager.TAdd(product3);
                var product4 = new Product() { UserId = 2, CategoryId = 1, Cost = 99, Version = "2022 Winter", Description = "A football shoe. Example4 : Here ar" +
                    "e some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the b" +
                    "est seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI" +
                    " started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 m" +
                    "inutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you n" +
                    "eed more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advance" +
                    "d product description generator.A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in" +
                    " your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of s" +
                    "andals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from t" +
                    "here. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description" +
                    " focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need somet" +
                    "hing more niche related, I recommend checking out the advanced product description generator. A football shoe. Example : Here are some custom show" +
                    " product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category" +
                    ". It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the " +
                    "product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each de" +
                    "scription, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions" +
                    " you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description gene" +
                    "rator. A sports shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe prod" +
                    "ucts from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get" +
                    " a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 wo" +
                    "rds and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of sho" +
                    "es.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking o" +
                    "ut the advanced product description generator.", BrandId = 3, Name = "Normal Walker", ImageUrl1 = "/Media/ecpp2.png",
                    ImageUrl2 = "/Media/ecpp4.png",
                    ThumbnailImgUrl = "/Media/ecpp1.png",
                    MovieUrl = "/Media/ecpm.mp4", SubCategoryId = 3, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _productManager.TAdd(product4);

                var stock1 = new StockPiece() { ProductId = 1, RemainingPiece = 100, SoldPiece = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _stockPieceManager.TAdd(stock1);
                var stock2 = new StockPiece() { ProductId = 2, RemainingPiece = 100, SoldPiece = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _stockPieceManager.TAdd(stock2);
                var stock3 = new StockPiece() { ProductId = 3, RemainingPiece = 100, SoldPiece = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _stockPieceManager.TAdd(stock3);
                var stock4 = new StockPiece() { ProductId = 4, RemainingPiece = 100, SoldPiece = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
                _stockPieceManager.TAdd(stock4);

                //var pcomment = new ProductComment { };
                //_productCommentManager.TAdd(pcomment);
            }
            return RedirectToAction("Index", "Product");
        }
    }
}
