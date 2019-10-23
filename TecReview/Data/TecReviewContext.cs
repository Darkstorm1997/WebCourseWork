using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace TecReview.Models
{
    public class TecReviewContext : IdentityDbContext<ApplicationUser>
    {
        public TecReviewContext(DbContextOptions<TecReviewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TecReview.Models.Item> Items { get; set; }

        public virtual DbSet<TecReview.Models.Category> Categories { get; set; }

        public virtual DbSet<TecReview.Models.Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>()
                .HasOne(p => p.Category)
                .WithMany(b => b.Items)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(p => p.Item)
                .WithMany(b => b.Comments)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 1,
                Name = "Headphones",
                Description = "All about high quality headphones",
                Color = System.Drawing.Color.MidnightBlue
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 2,
                Name = "Speakers",
                Description = "Speaks for home and for studio",
                Color = System.Drawing.Color.DarkMagenta
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 3,
                Name = "Computers",
                Description = "Laptops and desktops",
                Color = System.Drawing.Color.DarkGreen
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 4,
                Name = "Cellphones",
                Description = "iPhone, Samsung and more",
                Color = System.Drawing.Color.DarkRed
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 5,
                Name = "Tablets",
                Description = "Small computers which could be carried to anywhere",
                Color = System.Drawing.Color.Crimson
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = 6,
                Name = "Accessories",
                Description = "Mouse, keyboard",
                Color = System.Drawing.Color.SeaGreen
            });

            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    ItemId = 1,
                    CategoryId = 1,
                    Header = "Sony WH-1000XM3",
                    Summery = "If you settle only for the best",
                    DateCreated = new DateTime(2019, 10, 17, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://www.sony.com/image/eb0062b3db03748efc7f5ca3fd82ccc5?fmt=pjpeg&bgcolor=FFFFFF&bgc=FFFFFF&wid=2515&hei=1320",
                    Location = "החשמונאים 88, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:**The third iteration of the WH-1000X is more comfortable, sounds slightly better and features even better noise-canceling performance along with USB-C charging.

                            The excellent-sounding Sony WH-1000XM3 is more comfortable and 20 percent lighter than its predecessor. It offers slightly improved noise canceling and performs better as a headset for making calls. Battery life is strong, and it has some nifty extra features geared toward frequent travelers.

                            **The Bad:** Your ears can get a little warm inside the ear cups; I encountered some adaptive noise-canceling hiccups.

                            **The Botom Line:** With its more comfortable fit and improved performance, the Sony WH-1000XM3 becomes the noise-canceling headphone to beat."
                },


                new Item()
                {
                    ItemId = 2,
                    CategoryId = 1,
                    Header = "Bose Headphones 700",
                    Summery = "Top noise-canceling headphones take it up just a notch",
                    DateCreated = new DateTime(2019, 10, 17, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://assets.bose.com/content/dam/Bose_DAM/Web/consumer_electronics/global/better_with_bose/new_headphones/stories_hp2-0_nch700_1x1.psd/_jcr_content/renditions/cq5dam.web.320.320.png",
                    Location = "וייצמן 14, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The Bose Noise Cancelling Headphones 700 are very comfortable, have excellent noise canceling and work really well as a headset for making calls. They sound better than the Quiet Comfort 35 II, are loaded with features, including the option for hands-free Alexa and Bose AR. Noise-canceling levels are adjustable, they work without power; USB-C charging; transparency mode.

                            **The Bad:** $50 to $100 more than their closest competitors; QuietComfort 35 II is slightly more comfortable; battery life isn't as good as the of some competitors; the accompanying mobile app isn't fully baked.
                            
                            **The Bottom Line:**While not a quantum leap forward over the QC35 IIs, the Bose Noise Cancelling Headphones 700 offers slightly better noise canceling, sound and call quality."
                },

                new Item()
                {
                    ItemId = 4,
                    CategoryId = 1,
                    Header = "Jabra Elite Active 65t",
                    Summery = "These wireless headphones beat out AirPods on sound quality",
                    DateCreated = new DateTime(2019, 9, 1, 8, 10, 53, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://www.mea.jabra.com/-/media/Images/Products/Jabra-Elite-65t-Active/Color-Picker/elite_active_65t_blue.png?w=550&la=en-MEA&hash=1B8EB1D2C4E28EB578CED5A8F5FE87D12AAAB554",
                    Location = "וייצמן 14, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:**The Jabra Active Elite 65t are fully sweat-resistant truly wireless earphones that fit comfortably and securely. They sound excellent, perform reliably and are great for making calls, with two microphones in each earpiece. Battery life is decent at 5 hours and the included charging case delivers two extra charges. A quick-charge feature allows you to get 1.5 hours of juice from a 15-minute charge.

                            **The Bad:**The relatively tight, noise-isolating fit isn't for everyone. Motion sensor doesn't have much use at this point.

                            **The Bottom Line:**The Jabra Active Elite 65t truly wireless earphones are the best alternative to Apple's AirPods, but the stepdown non-Elite model will save you a bit of cash."
                },

                new Item()
                {
                    ItemId = 5,
                    CategoryId = 1,
                    Header = "Bose QuietComfort 35 II",
                    Summery = "These already excellent headphones get a touch better",
                    DateCreated = new DateTime(2019, 8, 6, 3, 4, 5, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://s3-eu-west-1.amazonaws.com/htsi-ez-prod/ez/images/8/4/5/6/886548-1-eng-GB/main_4491d981-7466-48d9-97b0-50d259bc4305.png",
                    Location = "שדרות בן גוריון 33, הרצליה",
                    IsShowMap = true,
                    Content = @"**The Good:** The Bose QuietComfort 35 II headphone adds a dedicated button for Google Assistant, but it can be programmed for other functions, too. Retains its predecessor's top-of-the-line active-noise canceling, excellent wireless Bluetooth sound and extra-comfortable design. Works in wired mode with included cord if battery dies.

                            **The Bad:** Battery isn't replaceable; same apparent design and performance as previous model.

                            **The Bottom Line:** Existing QC35 owners don't need to upgrade, but the addition of a dedicated Google Assistant button gives the already excellent wireless noise-canceling headphone an extra bit of personality."
                },

                new Item()
                {
                    ItemId = 6,
                    CategoryId = 2,
                    Header = "Wonderboom",
                    Summery = "A waterproof mini Bluetooth speaker that packs a punch",
                    DateCreated = new DateTime(2019, 10, 17, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://fgl.scene7.com/is/image/FGLSportsLtd/FGL_332751167_40_b-ue-wonderboom?bgColor=0,0,0,0&fmt=png-alpha&hei=528&resMode=sharp&qlt=85,1&op_sharpen=1",
                    Location = "החשמונאים 88, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The Wonderboom is compact, fully waterproof, plays very loud for its size with a good amount of bass for its small size. It also floats in water, is shock resistant and has decent battery life. You can pair two Wonderbooms together to augment the sound.

                            **The Bad:** No speakerphone capabilities. It's slightly too bulky for travel use.

                            **The Bottom Line:** For its size, the affordable and durable UE Wonderboom is one of the fullest sounding mini Bluetooth speakers you can buy."
                },

                new Item()
                {
                    ItemId = 7,
                    CategoryId = 2,
                    Header = "Bose SoundLink Revolve+",
                    Summery = "This pricey Bluetooth speaker sounds great in every direction",
                    DateCreated = new DateTime(2019, 7, 1, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://assets.bose.com/content/dam/Bose_DAM/Web/consumer_electronics/global/products/speakers/soundlink_revolve_plus_images/images/soundlink_revolve_plus_similar_speakers_revolve_1x1.psd/_jcr_content/renditions/cq5dam.web.320.320.png",
                    Location = "וייצמן 14, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** he sleek Bose SoundLink Plus Bluetooth speaker sounds excellent for its compact size, has a built-in handle for easy transport and is water-resistant. Battery life is good at 16 hours, there's a threaded tripod mount on the bottom of the speaker and an integrated microphone for speakerphone calls.

                            **The Bad:** Expensive, and the cradle that makes charging easier is an optional $30 accessory.

                            **The Bottom Line:** Bose's expensive SoundLink Plus is arguably the best-sounding Bluetooth speaker for its size."
                },

                new Item()
                {
                    ItemId = 8,
                    CategoryId = 2,
                    Header = "Elac Debut 2.0 B6.2",
                    Summery = "Clearer sound, better build quality, same incredible value",
                    DateCreated = new DateTime(2019, 8, 16, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://picscdn.redblue.de/doi/pixelboxx-mss-78393194/fee_786_587_png",
                    Location = "וייצמן 14, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The affordable Elac Debut 2.0 B6.2 offers class-leading sound along with excellent build quality and attractive looks. The front-facing bass port allows them it be placed close to walls.

                            **The Bad:** Big, boxy design compared to some competitors. Not as easygoing or forgiving as its predecessor.

                            **The Bottom Line:** The Elac Debut 2.0 B6.2 is one of the best speakers at this price, with great sound and excellent build quality.@"
                },

                new Item()
                {
                    ItemId = 9,
                    CategoryId = 2,
                    Header = "Q Acoustics 3020i",
                    Summery = "Big, smooth sound from small, affordable speakers",
                    DateCreated = new DateTime(2019, 9, 12, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://www.harmonieaudio.com/wp-content/uploads/2018/03/3020leather.png",
                    Location = "החשמונאים 88, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The affordable Q Acoustics 3020i give smooth, rich sound in a relatively compact design. The speakers are well built, look sweet and are available in a number of attractive finishes.

                            **The Bad:** Despite simplified speaker connectors, the 3020is are not suited to wall-mounting. The Elac Debut B6.2 offer better performance for the same money.

                            **The Bottom Line:** The Q Acoustics 3020i bookshelf speakers combine cutting-edge design with excellent sonics and are suited to systems with tight space requirements."
                },

                new Item()
                {
                    ItemId = 10,
                    CategoryId = 2,
                    Header = "Vizio SB3621",
                    Summery = "The king of the budget sound bars",
                    DateCreated = new DateTime(2019, 6, 16, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://thegoodguys.sirv.com/products/50065721/50065721_626607.PNG?scale.height=215&scale.width=215&canvas.height=215&canvas.width=215&canvas.opacity=0",
                    Location = "וייצמן 14, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The Vizio SB3621 offers excellent performance for an ultra-budget sound bar with great movie sound and toe-tapping music playback. The sound bar offers a decent selection of inputs including Bluetooth and will decode both Dolby and DTS. The sound bar and wireless sub feature excellent build quality and a seamless setup.

                        **The Bad:** The LED display is not very helpful, and the WAV-file-only USB port is a little weird.

                        **The Bottom Line:** The Vizio SB3621n-E8 is the best sound bar under $300 we have ever heard. If you want better TV sound, it's the new budget benchmark.
"
                },

                new Item()
                {
                    ItemId = 11,
                    CategoryId = 3,
                    Header = "Dell XPS 8900",
                    Summery = "An Oculus-approved, VR-ready desktop for less",
                    DateCreated = new DateTime(2019, 5, 7, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://i.dell.com/is/image/DellContent/content/dam/global-site-design/product_images/dell_client_products/desktops/xps_desktops/xps_8930/global_spi/desktop-xps-8930-vmax-cfl-hero-504x350-ng.psd?fmt=png-alpha",
                    Location = "החשמונאים 88, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The XPS 8900 is a decent-looking desktop tower with reasonable expandability. It's only $999 as part of an Oculus Rift bundle, and includes a very good graphics card.

                        **The Bad:** This VR-on-a-budget configuration may feel dated quickly as VR games become more ambitious. The Core i5 CPU holds this system back from being a PC-gaming workhorse.

                        **The Bottom Line:** One of the least-expensive Oculus-ready PCs, the Dell XPS 8900 Special Edition hits the required specs for virtual reality, but just barely."

                },

                new Item()
                {
                    ItemId = 12,
                    CategoryId = 3,
                    Header = "Apple iMac 27-inch (2019)",
                    Summery = "Apple iMac 2019 is a millennial trapped in the body of a baby boomer",
                    DateCreated = new DateTime(2019, 4, 7, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://mollaks.com/id/wp-content/uploads/2017/10/iMac-27-2.png",
                    Location = "דיזינגוף 149, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The Apple iMac's 27-inch 5K display remains the most color-accurate monitor we've seen thus far in an all-in-one. Improved performance is especially impressive in the Core i9 model. Two USB-C/Thunderbolt connectors drive more external displays and faster file data transfers.

                        **The Bad:** The design, including thick screen bezels, feels dated. UHS-II SD cards still aren't fully supported. The tilt-only screen doesn't offer enough adjustment options.

                        **The Bottom Line:** It's something of a miracle that Apple can continue to cram newer (and hotter) components into the tiny space behind the iMac's screen, but we're already ready for a bigger redesign."

                },

                new Item()
                {
                    ItemId = 13,
                    CategoryId = 3,
                    Header = "Razer Blade Advanced",
                    Summery = "One of our favorite gaming designs, but be prepared to pay for it",
                    DateCreated = new DateTime(2019, 3, 8, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://assets.razerzone.com/eeimages/support/products/1517/1517_blade15_mid2019.png",
                    Location = "וייצמן 14, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** Typically great Razer design, at its best in the alternate Mercury White color scheme. Excellent performance, especially considering the small size. One of the only gaming laptops with a very thin screen bezel.

                        **The Bad:** Faster RTX 2070 and RTX 2080 GPUs are not available in the white color scheme. The system can get very hot, which has led to some online complaints.

                        **The Bottom Line:** The Razer Blade 15-inch gaming laptop keeps up with the Nvidia RTX trend. The base model feels expensive, but the higher-end version hits a good mix of price and performance."

                },

                new Item()
                {
                    ItemId = 14,
                    CategoryId = 3,
                    Header = "HP Spectre x360",
                    Summery = "A classy little laptop that can -- and will -- run all day",
                    DateCreated = new DateTime(2019, 2, 2, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                    "https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c06138726.png",
                    Location = "החשמונאים 88, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The HP Spectre x360 13 is one of the best ultraportable two-in-ones available with lots of component options including three display choices, multiple privacy and security features and class-leading battery life. HP includes a laptop sleeve and full-size active pen.

                        **The Bad:** Premium laptops come with premium prices. The low-power display is too dim for outdoor use.

                        **The Bottom Line:** A stylish, thoughtful design, excellent component options and looooooong battery life all make the HP Spectre x360 13 one of the best premium two-in-one ultraportables around."
                },

                new Item()
                {
                    ItemId = 15,
                    CategoryId = 3,
                    Header = "Lenovo Yoga C930",
                    Summery = "Lenovo's top 2-in-1 perfected",
                    DateCreated = new DateTime(2019, 6, 8, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://www.powerxpc.com/image/cache/catalog/laptop/lenovo/yoga13/0-500x500.png",
                    Location = "החשמונאים 88, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** Lenovo's Yoga C930 puts its 360-degree hinges to work as the two-in-one's speaker system. The included active pen is discreetly housed and charged in the C930's body and its webcam has a physical slider to block it when not in use. Performance and battery life are excellent for its class.

                        **The Bad:** The included pen is a little small for extended use and there's no option for discrete graphics, but no real deal breakers unless you object to its price.

                        **The Bottom Line:** Excellent performance and a stylish and functional design make the Lenovo Yoga C930 simply one of the best two-in-one laptops available."

                },

                new Item()
                {
                    ItemId = 16,
                    CategoryId = 4,
                    Header = "Apple iPhone 11",
                    Summery = "The best $700 iPhone Apple has ever made",
                    DateCreated = new DateTime(2019, 7, 9, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "http://static-www.o2.co.uk/sites/default/files/iphone-11-black-sku-header-100919.png",
                    Location = "דיזינגוף 149, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** Even faster speed, improved battery life. The iPhone 11's cameras get an excellent new Night Mode and an ultrawide-angle camera that can add extra detail in photos. Fantastic video camera.

                        **The Bad:** Only Pro models get the 2x telephoto. The ultrawide-angle camera doesn’t add Night Mode. No USB-C port. The Pro phones have a faster 18-watt charger but iPhone 11 doesn't. Still has a good (but not OLED) display.

                        **The Bottom Line:** Apple may have skipped flashy extras on this year's phones, but the iPhone 11 is the best midtier model the company's ever made."

                },

                new Item()
                {
                    ItemId = 17,
                    CategoryId = 4,
                    Header = "Google Pixel 3A",
                    Summery = "A cheaper Pixel 3 with the same great rear camera",
                    DateCreated = new DateTime(2019, 9, 9, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://i1.wp.com/metro.co.uk/wp-content/uploads/2019/05/Google-Pixel-3a-2-6b07.png?quality=90&strip=all&zoom=1&resize=644%2C508&ssl=1",
                    Location = "וייצמן 14, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The Pixel 3A is cheaper than the original Pixel 3 but packs the same grade-A camera that shoots great in lowlight. It can also record time-lapse videos and has a headphone jack.

                        **The Bad:** The phone isn't water resistant and doesn't have wireless charging. Local storage is capped at 64GB, and Pixel 3A owners have unlimited uploads to Google Photos at a compressed high quality resolution, not original.

                        **The Bottom Line:** The Pixel 3A has the best camera for its price. But if a fast processor or more memory is your priority, get the OnePlus 6T instead."

                },

                new Item()
                {
                    ItemId = 18,
                    CategoryId = 4,
                    Header = "OnePlus 7 Pro",
                    Summery = "The best Android phone value of 2019",
                    DateCreated = new DateTime(2019, 4, 10, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://www.yaphone.com/2716-tm_thickbox_default/oneplus-7-pro-256gb-dual-sim-8gb-ram-mirror-grey.jpg",
                    Location = "החשמונאים 88, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The OnePlus 7 Pro is fast, has a neat pop-up camera and its triple rear cameras take fantastic pictures -- all at $80 less than its closest Samsung and iPhone rivals.

                        **The Bad:**OnePlus' new phone is heavy and isn't rated for water resistance. It lacks wireless charging and a headphone jack.

                        **The Bottom Line:**The OnePlus 7 Pro's camera, performance and price make it the go-to premium Android phone of 2019."
                },

                new Item()
                {
                    ItemId = 19,
                    CategoryId = 4,
                    Header = "Huawei P30 Pro",
                    Summery = "The absolute best camera on any phone",
                    DateCreated = new DateTime(2019, 7, 11, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://www.loveitcoverit.ie/wp-content/uploads/huawei-p30.png",
                    Location = "החשמונאים 88, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The Huawei P30 Pro's four cameras take astounding photos, its battery life is superb and the design is beautiful.

                        **The Bad:** Processor performance and screen resolution aren't up there with the best. The lack of headphone jack will upset people with wired headphones and the P30 Pro uses proprietary expandable storage.

                        **The Bottom Line:** The Huawei P30 Pro's impressive camera skills and vibrant design easily beat the Galaxy S10 Plus and the Pixel 3, but political entanglements mean the phone won't come to the US."

                },

                new Item()
                {
                    ItemId = 20,
                    CategoryId = 4,
                    Header = "Samsung Galaxy Note 10",
                    Summery = "The most premium Android phone for your money",
                    DateCreated = new DateTime(2019, 8, 16, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://www.affordablemobiles.co.uk/files/images/handsets/samsung/note-10-black-front.png",
                    Location = "החשמונאים 88, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The Galaxy Note 10 Plus delivers the premium goods, from a killer 6.8-inch screen and all-day battery life to excellent camera tools.

                        **The Bad:** The Bad The Note 10 Plus is expensive. There's no headphone jack, which will disappoint long-time Samsung fans. The depth-sensing camera is extremely limited.

                        **The Bottom Line:** Samsung closed the camera gap with rivals and created a top-of-the-line phone for people who want the best Android has to offer."

                },

                new Item()
                {
                    ItemId = 21,
                    CategoryId = 5,
                    Header = "Samsung Galaxy Tab S6",
                    Summery = "As good as Android tablets get",
                    DateCreated = new DateTime(2019, 9, 17, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://eddy.com.sa/26251-thickbox_default/samsung-galaxy-note10-black-256-gb.jpg",
                    Location = "וייצמן 14, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The Samsung Galaxy Tab S6 out-performs its predecessor with a more powerful processor, optimized DeX mode and increased storage space. It also gets a new minimalistic design and updated S Pen stylus.

                        **The Bad:** The keyboard is not included, and it's expensive and takes time to adjust to its small keys. In the tablet/laptop hybrid wars, there’s little clamor for an Android model, especially in light of Android app support on Chromebooks.

                        **The Bottom Line:** The Samsung Galaxy Tab S6 is a great update to last year’s premium Android tablet but doesn’t make the case for ditching the iPad Pro, Surface Pro or other options."

                },

                new Item()
                {
                    ItemId = 22,
                    CategoryId = 5,
                    Header = "Microsoft Surface Pro 6",
                    Summery = "Racing ahead of last year's model",
                    DateCreated = new DateTime(2019, 3, 12, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://www.gravitygaming.com/wp-content/uploads/2018/04/surface-pro-6-new-1000x1000-png.png",
                    Location = "החשמונאים 88, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The Surface Pro 6's jump to new quad-core processors pays off in big performance gains. The new black color option looks cool. Still the best kickstand and keyboard for Windows tablets.

                        **The Bad:** Be ready to shell out extra for the keyboard cover, stylus and even for the new matte black design. CPU and color aside, it's a very minimal upgrade over the previous version.

                        **The Bottom Line:** The latest Surface Pro tablet doesn't make any radical design changes, but the performance jump makes it viable as a mainstream performance laptop replacement."

                },

                new Item()
                {
                    ItemId = 23,
                    CategoryId = 5,
                    Header = "Microsoft Surface Go",
                    Summery = "This shrunken-down Surface is fun and practical, but more expensive than it looks",
                    DateCreated = new DateTime(2019, 7, 5, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://media.ao.com/en-GB/Productimages/Images/rvLarge/mhn-00002_microsoft_surfacego_02_l.png",
                    Location = "החשמונאים 88, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The Surface Go delivers Microsoft's great Surface design and accessories at a lower price and in a smaller size.

                        **The Bad:** The Pentium processor isn't suited for all tasks. A keyboard cover is a must-have add-on but still sold separately. And you'll probably want to pay extra for more storage and RAM, too. Battery life is lacking for a go-anywhere PC.

                        **The Bottom Line:** The new Microsoft Surface Go is the perfect size for casual coffee-shop computing, but getting the full experience quickly drives up the price."

                },

                new Item()
                {
                    ItemId = 24,
                    CategoryId = 5,
                    Header = "Apple iPad (9.7-inch, 2018)",
                    Summery = "The iPad for everyone",
                    DateCreated = new DateTime(2019, 8, 5, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://static-www.o2.co.uk/sites/default/files/product_images/tablets/apple_ipad_9_7_2018_32gb_silver/apple_ipad_9_7_2018_32gb_silver_sku_header.png",
                    Location = "דיזינגוף 149, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The 2018 entry-level iPad supports the Apple Pencil for art work and annotation, and adds a faster A10 processor. iOS continues to offer the best overall selection of free and paid apps on affordable tablets.

                        **The Bad:** Lacks the bigger, better screen, quad speakers and Smart Connector found on pricier iPad Pros. The Pencil, case and keyboard add-ons will bring the price up to laptop level.

                        **The Bottom Line:** The 2018 entry-level iPad doesn't add much, but it makes an already excellent tablet a better buy than ever."

                },

                new Item()
                {
                    ItemId = 25,
                    CategoryId = 5,
                    Header = "Amazon Fire HD 8 (2018)",
                    Summery = "Small upgrades sweeten the deal just a bit",
                    DateCreated = new DateTime(2019, 8, 1, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://www.skymartbw.com/wp-content/uploads/2016/05/Fire-HD-6-6-HD-Display-Wi-Fi-8-GB.png",
                    Location = "וייצמן 14, תל אביב",
                    IsShowMap = true,
                    Content = @" **The Good:** The 2018 version of the Amazon Fire HD 8 has a few small upgrades, including a better front-facing camera and the ability to issue Alexa voice commands even with your screen on standby. Its 8-inch screen is bright, the speakers are loud and it offers expandable microSD storage and ample parental controls. Amazon Prime members can access gobs of free video, music and other content with their subscription.

                        **The Bad:** Display isn't as sharp as the iPad's; to truly take advantage of what the tablet has to offer, you need an Amazon Prime membership; slow charging (takes 6 hours to fully cap battery).

                        **The Bottom Line:** The latest HD 8 isn't much of an upgrade over last year's model, but the 'always-ready' hands-free Alexa feature is a nice addition to what remains the best tablet value."

                },

                new Item()
                {
                    ItemId = 26,
                    CategoryId = 6,
                    Header = "Logitech MX Anywhere 2",
                    Summery = "A high-performance mouse for mobile users",
                    DateCreated = new DateTime(2019, 7, 17, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://assets.logitech.com/assets/53655/4/mx-anywhere-2.png",
                    Location = "החשמונאים 88, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The Logitech MX Anywhere 2 is a rechargeable wireless mouse for Macs and Windows PCs that offers smooth, precise operation, lots of customization options and decent ergonomics for a mobile mouse, and works on almost any surface. You can connect to up to three computers using Logitech's included Unifying Receiver USB dongle or opt for Bluetooth connectivity. A speed-adaptive scroll wheel lets you autoshift from click-to-click to hyperfast scrolling. Battery life is good.

                        **The Bad:** Ergonomics aren't as good as on Logitech's larger MX Master; the rechargeable battery isn't user-replaceable (but should last several years).

                        **The Bottom Line:** The MX Anywhere 2 is a top-notch mobile mouse."

                },

                new Item()
                {
                    ItemId = 27,
                    CategoryId = 6,
                    Header = "Logitech K380",
                    Summery = "The best multidevice Bluetooth keyboard yet",
                    DateCreated = new DateTime(2019, 1, 1, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://zdnet1.cbsistatic.com/hub/i/r/2017/03/26/25415333-0911-476d-a5de-5c7e79fdcaaf/resize/770xauto/6b5936f08e05493ef16d0104cedeb598/k380-blue.png",
                    Location = "וייצמן 14, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The Logitech K380 is a compact, solidly built wireless Bluetooth keyboard that pairs with up to three devices at once and lets you toggles between them. It's compatible with most Bluetooth-enabled computers, tablets, and smartphones and offers long battery life at up to 2 years from two AAA batteries.

                        **The Bad:** Keys may be a little cramped for users with very large hands; Caps Lock is a little close to the 'a' key and can be accidentally pressed.

                        **The Bottom Line:** With its ability to toggle between nearly any smartphone, tablet and most computers, Logitech's smooth-operating and affordable K380 is one of the best multidevice wireless keyboards you can buy."

                },

                new Item()
                {
                    ItemId = 28,
                    CategoryId = 6,
                    Header = "Logitech MX Master",
                    Summery = "One smooth, feature-packed wireless mouse",
                    DateCreated = new DateTime(2019, 1, 7, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://assets.logitech.com/assets/65106/4/mx-master-2s.png",
                    Location = "וייצמן 14, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The MX Master is a rechargeable wireless mouse for Macs and Windows PCs that offers smooth, precise operation, lots of customization options, good ergonomics, and works on almost any surface. You can connect to up to three computers using Logitech's included Unifying Receiver USB dongle or opt for Bluetooth connectivity. Speed-adaptive scroll wheel lets you auto-shift from click-to-click to hyper-fast scrolling and a thumbwheel lets you scroll side-to-side.

                        **The Bad:** It's somewhat expensive, and the rechargeable battery isn't user-replaceable (but should last several years).

                        **The Bottom Line:** While somewhat pricey, the Logitech MX Master's expansive feature set and smooth operation make it a worthwhile purchase for power users seeking a high-performance wireless mouse."

                },

                new Item()
                {
                    ItemId = 29,
                    CategoryId = 6,
                    Header = "Razer BlackWidow Chroma",
                    Summery = "Razer BlackWidow Chroma V2 is sweet, sweet overkill",
                    DateCreated = new DateTime(2019, 3, 4, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://www.gudanggaming.com/storage/store/products/razer-blackwidow-chroma-v2-gallery-02-wristrest.png",
                    Location = "החשמונאים 88, תל אביב",
                    IsShowMap = true,
                    Content =

@"**The Good:** The BlackWidow Chroma V2 has very easily programmable macro keys, a full suite of gaming keyboard functionality and Razer Synapse compatibility.
**The Bad:** You're really going to need to weigh those features against a hefty price tag.
**The Bottom Line:** The BlackWidow Chroma V2 is pretty much everything you want out of your gaming keyboard. But there are most cost effective options if you're not ensconced in the Razer ecosystem."

                },

                new Item()
                {
                    ItemId = 30,
                    CategoryId = 6,
                    Header = "Apple Magic Keyboard",
                    Summery = "Apple's new keyboard rescues the number pad",
                    DateCreated = new DateTime(2019, 7, 7, 8, 30, 52, 0, DateTimeKind.Unspecified),
                    HomeImageUrl =
                        "https://www.ifrog.com.au/WebRoot/Store4/Shops/Ifrogs/5936/F77D/9BB7/F4EE/9ABD/AC10/004C/B3B0/shopping_ml.png",
                    Location = "דיזינגוף 149, תל אביב",
                    IsShowMap = true,
                    Content = @"**The Good:** The Apple Magic Keyboard with Numeric Keypad has light, bouncy keys that are great to type with. The new number pad makes it easier to input figures or work with some creative software shortcuts. It pairs easily and lasts a long time between charges.

                        **The Bad:** The flat design can put strain on your wrist. The lack of backlight makes it harder to work with the keys at night.

                        **The Bottom Line:** Apple's slim, light, wireless Magic Keyboard gets a makeover, bringing back the number pad previously found in the old wired version. But it also costs more, so the standard Magic Keyboard may be better for you."

                }

            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment()
                {
                    CommentId = 1,
                    DatePosted = new DateTime(2018, 8, 2, 8, 10, 0),
                    ItemId = 1,
                    Author = "The one who knows",
                    Content = "Example content for an example comment",
                    Sequence = 1
                },
                new Comment()
                {
                    CommentId = 2,
                    DatePosted = new DateTime(2018, 8, 16, 9, 10, 0),
                    ItemId = 1,
                    Author = "Voldemort",
                    Content = "Multi line comment! I think this is an example comment",
                    Sequence = 2
                },
                new Comment()
                {
                    CommentId = 3,
                    DatePosted = new DateTime(2018, 9, 2, 8, 0, 15),
                    ItemId = 1,
                    Author = "Jimmi",
                    Content = "Example content for an example comment",
                    Sequence = 3
                }
            );
        }

    }
}