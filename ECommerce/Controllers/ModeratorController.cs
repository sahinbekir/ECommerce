using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        CityManager cm = new CityManager(new EfCityRepository());
        VillageManager vm = new VillageManager(new EfVillageRepository());
        GenderManager gm = new GenderManager(new EfGenderRepository());

        BrandManager brandm = new BrandManager(new EfBrandRepository());
        CategoryManager categorym = new CategoryManager(new EfCategoryRepository());
        SubCategoryManager subcategorym = new SubCategoryManager(new EfSubCategoryRepository());
        ProductManager productm = new ProductManager(new EfProductRepository());
        StockAmountManager stockam = new StockAmountManager(new EfStockAmountRepository());
        public async Task<IActionResult> DefaultModerator()
        {
            /*
             * AboutUs-ContactUs Default
             */
            var verify = _userManager.Users.FirstOrDefault();
            if (verify != null) { return RedirectToAction("Index", "Moderator"); }

            var c1 = new City() { Name = "Adana" };
            cm.TAdd(c1);
            var c2 = new City() { Name = "Adıyaman" };
            cm.TAdd(c2);
            var v11 = new Village { CityId = 1, Name = "Aladağ" };
            vm.TAdd(v11);
            var v12 = new Village { CityId = 1, Name = "Ceyhan" };
            vm.TAdd(v12);
            var v2 = new Village { CityId = 2, Name = "Besni" };
            vm.TAdd(v2);
            var g1 = new Gender { Name = "Male", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            gm.TAdd(g1);
            var g2 = new Gender { Name = "Female", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            gm.TAdd(g2);
            var g3 = new Gender { Name = "Other", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            gm.TAdd(g3);
            AppRole role1 = new AppRole
            {
                Name = "Admin"
            };
            var result = await _roleManager.CreateAsync(role1);
            AppRole role2 = new AppRole
            {
                Name = "User"
            };
            var result2 = await _roleManager.CreateAsync(role2);

            AppUser admin1 = new AppUser();
            admin1.Email = "admin1@ec.io";
            admin1.UserName = "admin1";
            admin1.FullName = "Admin Admin1";
            admin1.PhoneNumber = "5311313071";
            admin1.BornDate = DateTime.Now;
            admin1.CityId = 1;
            admin1.VillageId = 1;
            admin1.Address = "";
            admin1.GenderId = 1;
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
            user1.CityId = 1;
            user1.VillageId = 1;
            user1.Address = "";
            user1.GenderId = 1;
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
            user2.CityId = 1;
            user2.VillageId = 1;
            user2.Address = "";
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

            var brand1 = new Brand() { Name = "Nike", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            brandm.TAdd(brand1);
            var brand2 = new Brand() { Name = "Adidas", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            brandm.TAdd(brand2);
            var brand3 = new Brand() { Name = "Polo", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            brandm.TAdd(brand3);

            var category1 = new Category() { Name = "Shoe", Description = "There are various styles of shoes for different occasions, such as athletic shoes, dress shoes, sandals, and boots.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            categorym.TAdd(category1);
            var category2 = new Category() { Name = "T-Shirt", Description = "Below we have mentioned the most popular necklines that have given the t-shirt a modern twist without compromising on its aesthetics.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            categorym.TAdd(category2);
            var category3 = new Category() { Name = "Pants", Description = "Depending on the definition, there are between 12 and 16 different types of trousers based on factors such as the material used, design elements, fit, and occasion. Most men will be familiar with classics like jeans, chinos, and sweatpants, as well as the many variations on dress pants.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            categorym.TAdd(category3);
            var category4 = new Category() { Name = "Jacket", Description = "What are the different types of jackets? There are several jacket styles to choose from, and some of the types that every man should own include; bomber, biker, trucker, denim, track, blouson, hooded, overcoat, parka, pea coat, trench coat, raincoat, shearling jacket, anorak, and a Crombie coat.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            categorym.TAdd(category4);

            var scat1 = new SubCategory() { CategoryId = 1, Name = "Dress Shoes", Description = "A dress shoe is anything that's not a sneaker, boot or any style of footwear that exposes your feet – which means a brogue, a Derby, an Oxford or a monk-strap shoe.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            subcategorym.TAdd(scat1);
            var scat2 = new SubCategory() { CategoryId = 1, Name = "Boots", Description = "Boots are commonly used for work wear, industry, mining, military, riding, walking in snow, skiing, snowboarding, and ice skating. However, with boots now being available in smooth and soft material, it is fashionable for women to use boots with dresses.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            subcategorym.TAdd(scat2);
            var scat3 = new SubCategory() { CategoryId = 1, Name = "Athletic Shoes", Description = "A shoe designed to be worn for sports, exercising, or recreational activity, as racquetball, jogging, or aerobic dancing.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            subcategorym.TAdd(scat3);
            var scat4 = new SubCategory() { CategoryId = 2, Name = "Seasonal Tee", Description = "For spring...", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            subcategorym.TAdd(scat4);
            var scat5 = new SubCategory() { CategoryId = 2, Name = "Summer Tee", Description = "For summer...", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            subcategorym.TAdd(scat5);
            var scat6 = new SubCategory() { CategoryId = 3, Name = "Jeans", Description = "Jeans blue pants.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            subcategorym.TAdd(scat6);
            var scat7 = new SubCategory() { CategoryId = 3, Name = "Suits", Description = "Suit pants.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            subcategorym.TAdd(scat7);
            var scat8 = new SubCategory() { CategoryId = 3, Name = "Shorts", Description = "Short pants.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            subcategorym.TAdd(scat8);
            var scat9 = new SubCategory() { CategoryId = 4, Name = "Suits", Description = "Suit jackets.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            subcategorym.TAdd(scat9);
            var scat10 = new SubCategory() { CategoryId = 4, Name = "Jeans", Description = "Jeans blue jackets.", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            subcategorym.TAdd(scat10);

            var product1 = new Product() { UserId = 2, Cost = 90, Version = "2022 Winter", Description = "A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description generator. A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description generator. A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description generator.", BrandId = 1, Name = "HyperVenom", ImageUrl = "/Media/ecpp2.png", ThumbnailImgUrl = "/Media/ecpp1.png", MovieUrl = "/Media/ecpm.mp4", SubCategoryId = 3, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            productm.TAdd(product1);
            var product2 = new Product() { UserId = 3, Cost = 99, Version = "2022 Winter", Description = "A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description generator. A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description generator. A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description generator.", BrandId = 2, Name = "Mercurial", ImageUrl = "/Media/ecpp2.png", ThumbnailImgUrl = "/Media/ecpp1.png", MovieUrl = "/Media/ecpm.mp4", SubCategoryId = 3, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            productm.TAdd(product2);
            var product3 = new Product() { UserId = 2, Cost = 90, Version = "2022 Winter", Description = "A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description generator. A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description generator. A sports shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description generator.", BrandId = 1, Name = "Winter Climber", ImageUrl = "/Media/ecpp2.png", ThumbnailImgUrl = "/Media/ecpp1.png", MovieUrl = "/Media/ecpm.mp4", SubCategoryId = 2, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            productm.TAdd(product3);
            var product4 = new Product() { UserId = 2, Cost = 99, Version = "2022 Winter", Description = "A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description generator.A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description generator. A football shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description generator. A sports shoe. Example : Here are some custom show product description examples for you to copy, steal and use in your shop. I picked 5 shoe products from AliExpress under the best seller category. It is the start of summer when writing this post, so a lot of sandals were popular. I did try to get a bit of variety.\r\n\r\nI started with the product description generator and then expanded the writing from there. Each description is at least 100 words and took about 30 minutes for each description, including some research. I try to make each description focus on details unique to that pair of shoes.\r\n\r\nIf you need more descriptions you can use the product description generator. If you need something more niche related, I recommend checking out the advanced product description generator.", BrandId = 3, Name = "Normal Walker", ImageUrl = "/Media/ecpp2.png", ThumbnailImgUrl = "/Media/ecpp1.png", MovieUrl = "/Media/ecpm.mp4", SubCategoryId = 3, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            productm.TAdd(product4);

            var stock1 = new StockAmount() { ProductId = 1, StockScore = 100, SoldScore = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            stockam.TAdd(stock1);
            var stock2 = new StockAmount() { ProductId = 2, StockScore = 100, SoldScore = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            stockam.TAdd(stock2);
            var stock3 = new StockAmount() { ProductId = 3, StockScore = 100, SoldScore = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            stockam.TAdd(stock3);
            var stock4 = new StockAmount() { ProductId = 4, StockScore = 100, SoldScore = 0, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now, IsDeleted = false };
            stockam.TAdd(stock4);
            return RedirectToAction("Index", "Product");
        }
    }
}
