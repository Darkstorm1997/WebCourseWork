using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TecReview.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ColorARGB = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    Header = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    HomeImageUrl = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    IsShowMap = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    DatePosted = table.Column<DateTime>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "ColorARGB", "Description", "Name" },
                values: new object[,]
                {
                    { 1, -15132304, "All about high quality headphones", "Headphones" },
                    { 2, -7667573, "Speaks for home and for studio", "Speakers" },
                    { 3, -16751616, "Laptops and desktops", "Computers" },
                    { 4, -7667712, "iPhone, Samsung and more", "Cellphones" },
                    { 5, -2354116, "Small computers which could be carried to anywhere", "Tablets" },
                    { 6, -13726889, "Mouse, keyboard", "Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CategoryId", "Content", "DateCreated", "Header", "HomeImageUrl", "IsShowMap", "Location", "Summary" },
                values: new object[,]
                {
                    { 1, 1, "**The Good:**<ul><li>The third iteration of the WH-1000X is more comfortable, sounds slightly better and features even better noise-canceling performance along with USB-C charging.</li><li>The excellent-sounding Sony WH-1000XM3 is more comfortable and 20 percent lighter than its predecessor.</li><li>It offers slightly improved noise canceling and performs better as a headset for making calls.</li><li>Battery life is strong, and it has some nifty extra features geared toward frequent travelers.</li></ul><br/>**The Bad:** <ul><li>Your ears can get a little warm inside the ear cups</li><li>I encountered some adaptive noise-canceling hiccups.</li></ul><br/>**The Botom Line:** With its more comfortable fit and improved performance, the Sony WH-1000XM3 becomes the noise-canceling headphone to beat.<br/>", new DateTime(2019, 8, 7, 8, 30, 52, 0, DateTimeKind.Unspecified), "Sony WH-1000XM3", "https://www.sony.com/image/eb0062b3db03748efc7f5ca3fd82ccc5?fmt=png-alpha&wid=440", true, "KSP החשמונאים, תל אביב", "If you settle only for the best" },
                    { 28, 6, "**The Good:** <ul><li>The MX Master is a rechargeable wireless mouse for Macs and Windows PCs that offers smooth, precise operation, lots of customization options, good ergonomics, and works on almost any surface</li><li>You can connect to up to three computers using Logitech's included Unifying Receiver USB dongle or opt for Bluetooth connectivity</li><li>Speed-adaptive scroll wheel lets you auto-shift from click-to-click to hyper-fast scrolling and a thumbwheel lets you scroll side-to-side</li></ul><br />**The Bad:** <ul><li>It's somewhat expensive</li><li>The rechargeable battery isn't user-replaceable (but should last several years)</li></ul><br />**The Bottom Line:** While somewhat pricey, the Logitech MX Master's expansive feature set and smooth operation make it a worthwhile purchase for power users seeking a high-performance wireless mouse.", new DateTime(2019, 8, 11, 11, 24, 47, 0, DateTimeKind.Unspecified), "Logitech MX Master", "https://assets.logitech.com/assets/65106/4/mx-master-2s.png", true, "באג סניף וייצמן, תל אביב", "One smooth, feature-packed wireless mouse" },
                    { 27, 6, "**The Good:** <ul><li>The Logitech K380 is a compact, solidly built wireless Bluetooth keyboard that pairs with up to three devices at once and lets you toggles between them</li><li>It's compatible with most Bluetooth-enabled computers, tablets, and smartphones and offers long battery life at up to 2 years from two AAA batteries</li></ul><br />**The Bad:** <ul><li>Keys may be a little cramped for users with very large hands</li><li>Caps Lock is a little close to the 'a' key and can be accidentally pressed</li></ul><br />**The Bottom Line:** With its ability to toggle between nearly any smartphone, tablet and most computers, Logitech's smooth-operating and affordable K380 is one of the best multidevice wireless keyboards you can buy.", new DateTime(2019, 8, 11, 11, 23, 10, 0, DateTimeKind.Unspecified), "Logitech K380", "https://zdnet1.cbsistatic.com/hub/i/r/2017/03/26/25415333-0911-476d-a5de-5c7e79fdcaaf/resize/770xauto/6b5936f08e05493ef16d0104cedeb598/k380-blue.png", true, "באג סניף וייצמן, תל אביב", "The best multidevice Bluetooth keyboard yet" },
                    { 26, 6, "**The Good:** <ul><li>The Logitech MX Anywhere 2 is a rechargeable wireless mouse for Macs and Windows PCs that offers smooth, precise operation, lots of customization options and decent ergonomics for a mobile mouse, and works on almost any surface</li><li>You can connect to up to three computers using Logitech's included Unifying Receiver USB dongle or opt for Bluetooth connectivity</li><li>A speed-adaptive scroll wheel lets you autoshift from click-to-click to hyperfast scrolling</li><li>Battery life is good</li></ul><br />**The Bad:** <ul><li>Ergonomics aren't as good as on Logitech's larger MX Master</li><li>The rechargeable battery isn't user-replaceable (but should last several years)</li></ul><br />**The Bottom Line:** The MX Anywhere 2 is a top-notch mobile mouse.", new DateTime(2019, 8, 10, 11, 20, 39, 0, DateTimeKind.Unspecified), "Logitech MX Anywhere 2", "https://assets.logitech.com/assets/53655/4/mx-anywhere-2.png", true, "KSP החשמונאים, תל אביב", "A high-performance mouse for mobile users" },
                    { 25, 5, "**The Good:** <ul><li>The 2018 version of the Amazon Fire HD 8 has a few small upgrades, including a better front-facing camera and the ability to issue Alexa voice commands even with your screen on standby</li><li>Its 8-inch screen is bright, the speakers are loud and it offers expandable microSD storage and ample parental controls</li><li>Amazon Prime members can access gobs of free video, music and other content with their subscription</li></ul><br />**The Bad:** <ul><li>Display isn't as sharp as the iPad's</li><li>To truly take advantage of what the tablet has to offer, you need an Amazon Prime membership</li><li>Slow charging (takes 6 hours to fully cap battery)</li></ul><br />**The Bottom Line:** The latest HD 8 isn't much of an upgrade over last year's model, but the 'always-ready' hands-free Alexa feature is a nice addition to what remains the best tablet value.", new DateTime(2019, 8, 10, 11, 14, 45, 0, DateTimeKind.Unspecified), "Amazon Fire HD 8 (2018)", "https://www.skymartbw.com/wp-content/uploads/2016/05/Fire-HD-6-6-HD-Display-Wi-Fi-8-GB.png", true, "באג סניף וייצמן, תל אביב", "Small upgrades sweeten the deal just a bit" },
                    { 24, 5, "**The Good:** <ul><li>The 2018 entry-level iPad supports the Apple Pencil for art work and annotation, and adds a faster A10 processor</li><li>iOS continues to offer the best overall selection of free and paid apps on affordable tablets</li></ul><br />**The Bad:** <ul><li>Lacks the bigger, better screen, quad speakers and Smart Connector found on pricier iPad Pros</li><li>The Pencil, case and keyboard add-ons will bring the price up to laptop level</li></ul><br />**The Bottom Line:** The 2018 entry-level iPad doesn't add much, but it makes an already excellent tablet a better buy than ever.", new DateTime(2019, 8, 10, 11, 9, 10, 0, DateTimeKind.Unspecified), "Apple iPad (9.7-inch, 2018)", "https://static-www.o2.co.uk/sites/default/files/product_images/tablets/apple_ipad_9_7_2018_32gb_silver/apple_ipad_9_7_2018_32gb_silver_sku_header.png", true, "iStore סניף הרצליה", "The iPad for everyone" },
                    { 23, 5, "**The Good:** <ul><li>The Surface Go delivers Microsoft's great Surface design and accessories</li><li>It comes at a lower price and in a smaller size than its competitors</li></ul><br />**The Bad:** <ul><li>The Pentium processor isn't suited for all tasks</li><li>A keyboard cover is a must-have add-on but still sold separately</li><li>And, you'll probably want to pay extra for more storage and RAM, too</li><li>Battery life is lacking for a go-anywhere PC</li></ul><br />**The Bottom Line:** The new Microsoft Surface Go is the perfect size for casual coffee-shop computing, but getting the full experience quickly drives up the price.", new DateTime(2019, 8, 10, 11, 7, 23, 0, DateTimeKind.Unspecified), "Microsoft Surface Go", "https://media.ao.com/en-GB/Productimages/Images/rvLarge/mhn-00002_microsoft_surfacego_02_l.png", true, "KSP החשמונאים, תל אביב", "This shrunken-down Surface is fun and practical, but more expensive than it looks" },
                    { 21, 5, "**The Good:** <ul><li>The Samsung Galaxy Tab S6 out-performs its predecessor with a more powerful processor, optimized DeX mode and increased storage space</li><li>It also gets a new minimalistic design and updated S Pen stylus</li></ul><br />**The Bad:** <ul><li>The keyboard is not included, and it's expensive and takes time to adjust to its small keys</li><li>In the tablet/laptop hybrid wars, there’s little clamor for an Android model, especially in light of Android app support on Chromebooks</li></ul><br />**The Bottom Line:** The Samsung Galaxy Tab S6 is a great update to last year’s premium Android tablet but doesn’t make the case for ditching the iPad Pro, Surface Pro or other options.", new DateTime(2019, 8, 10, 11, 4, 45, 0, DateTimeKind.Unspecified), "Samsung Galaxy Tab S6", "https://eddy.com.sa/26251-thickbox_default/samsung-galaxy-note10-black-256-gb.jpg", true, "באג סניף וייצמן, תל אביב", "As good as Android tablets get" },
                    { 20, 4, "**The Good:** <ul><li>The Galaxy Note 10 Plus delivers the premium goods</li><li>It has a killer 6.8-inch screen and all-day battery life to excellent camera tools</li></ul><br />**The Bad:** <ul><li>The Bad The Note 10 Plus is expensive</li><li>There's no headphone jack, which will disappoint long-time Samsung fans</li><li>The depth-sensing camera is extremely limited</li></ul><br />**The Bottom Line:** Samsung closed the camera gap with rivals and created a top-of-the-line phone for people who want the best Android has to offer.", new DateTime(2019, 8, 10, 11, 3, 12, 0, DateTimeKind.Unspecified), "Samsung Galaxy Note 10", "https://www.affordablemobiles.co.uk/files/images/handsets/samsung/note-10-black-front.png", true, "KSP החשמונאים, תל אביב", "The most premium Android phone for your money" },
                    { 19, 4, "**The Good:** <ul><li>The Huawei P30 Pro's four cameras take astounding photos</li><li>Its battery life is superb</li><li>The design is beautiful</li></ul>**The Bad:** <ul><li>Processor performance and screen resolution aren't up there with the best</li><li>The lack of headphone jack will upset people with wired headphones and the P30 Pro uses proprietary expandable storage</li></ul><br />**The Bottom Line:** The Huawei P30 Pro's impressive camera skills and vibrant design easily beat the Galaxy S10 Plus and the Pixel 3, but political entanglements mean the phone won't come to the US.", new DateTime(2019, 8, 10, 10, 59, 4, 0, DateTimeKind.Unspecified), "Huawei P30 Pro", "https://www.loveitcoverit.ie/wp-content/uploads/huawei-p30.png", true, "KSP החשמונאים, תל אביב", "The absolute best camera on any phone" },
                    { 17, 4, "**The Good:** <ul><li>The Pixel 3A is cheaper than the original Pixel 3 but packs the same grade-A camera that shoots great in lowlight</li><li>It can also record time-lapse videos and has a headphone jack</li></ul><br />**The Bad:** <ul><li>The phone isn't water resistant and doesn't have wireless charging</li><li>Local storage is capped at 64GB, and Pixel 3A owners have unlimited uploads to Google Photos at a compressed high quality resolution, not original</li></ul><br />**The Bottom Line:** The Pixel 3A has the best camera for its price. But if a fast processor or more memory is your priority, get the OnePlus 6T instead.", new DateTime(2019, 8, 10, 10, 53, 14, 0, DateTimeKind.Unspecified), "Google Pixel 3A", "https://i1.wp.com/metro.co.uk/wp-content/uploads/2019/05/Google-Pixel-3a-2-6b07.png?quality=90&strip=all&zoom=1&resize=644%2C508&ssl=1", true, "באג סניף וייצמן, תל אביב", "A cheaper Pixel 3 with the same great rear camera" },
                    { 16, 4, "**The Good:** <ul><li>Even faster speed, improved battery life</li><li>The iPhone 11's cameras get an excellent new Night Mode and an ultrawide-angle camera that can add extra detail in photos</li><li>Fantastic video camera</li></ul><br />**The Bad:** <ul><li>Only Pro models get the 2x telephoto</li><li>The ultrawide-angle camera doesn’t add Night Mode</li><li>No USB-C port</li><li>The Pro phones have a faster 18-watt charger but iPhone 11 doesn't</li><li>Still has a good (but not OLED) display</li></ul><br />**The Bottom Line:** Apple may have skipped flashy extras on this year's phones, but the iPhone 11 is the best midtier model the company's ever made.", new DateTime(2019, 8, 10, 10, 47, 40, 0, DateTimeKind.Unspecified), "Apple iPhone 11", "http://static-www.o2.co.uk/sites/default/files/iphone-11-black-sku-header-100919.png", true, "iStore סניף הרצליה", "The best $700 iPhone Apple has ever made" },
                    { 14, 3, "**The Good:** <ul><li>The HP Spectre x360 13 is one of the best ultraportable two-in-ones available with lots of component options including three display choices, multiple privacy and security features and class-leading battery life</li><li>HP includes a laptop sleeve and full-size active pen</li></ul><br />**The Bad:** <ul><li>Premium laptops come with premium prices</li><li>The low-power display is too dim for outdoor use</li></ul><br />**The Bottom Line:** A stylish, thoughtful design, excellent component options and looooooong battery life all make the HP Spectre x360 13 one of the best premium two-in-one ultraportables around.", new DateTime(2019, 8, 10, 10, 44, 40, 0, DateTimeKind.Unspecified), "HP Spectre x360", "https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c06138726.png", true, "KSP החשמונאים, תל אביב", "A classy little laptop that can -- and will -- run all day" },
                    { 13, 3, "**The Good:** <ul><li>Typically great Razer design, at its best in the alternate Mercury White color scheme</li><li>Excellent performance, especially considering the small size</li><li>One of the only gaming laptops with a very thin screen bezel</li></ul><br />**The Bad:** <ul><li>Faster RTX 2070 and RTX 2080 GPUs are not available in the white color scheme</li><li>The system can get very hot, which has led to some online complaints</li></ul><br />**The Bottom Line:** The Razer Blade 15-inch gaming laptop keeps up with the Nvidia RTX trend. The base model feels expensive, but the higher-end version hits a good mix of price and performance.", new DateTime(2019, 8, 10, 9, 52, 5, 0, DateTimeKind.Unspecified), "Razer Blade Advanced", "https://assets.razerzone.com/eeimages/support/products/1517/1517_blade15_mid2019.png", true, "באג סניף וייצמן, תל אביב", "One of our favorite gaming designs, but be prepared to pay for it" },
                    { 12, 3, "**The Good:** <ul><li>The Apple iMac's 27-inch 5K display remains the most color-accurate monitor we've seen thus far in an all-in-one</li><li>Improved performance is especially impressive in the Core i9 model</li><li>Two USB-C/Thunderbolt connectors drive more external displays and faster file data transfers</li></ul><br />**The Bad:** <ul><li>The design, including thick screen bezels, feels dated</li><li>UHS-II SD cards still aren't fully supported</li><li>The tilt-only screen doesn't offer enough adjustment options</li></ul><br />**The Bottom Line:** It's something of a miracle that Apple can continue to cram newer (and hotter) components into the tiny space behind the iMac's screen, but we're already ready for a bigger redesign.", new DateTime(2019, 10, 9, 10, 51, 11, 0, DateTimeKind.Unspecified), "Apple iMac 27-inch (2019)", "https://mollaks.com/id/wp-content/uploads/2017/10/iMac-27-2.png", true, "iStore סניף הרצליה", "Apple iMac 2019 is a millennial trapped in the body of a baby boomer" },
                    { 11, 3, "**The Good:** <ul><li>The XPS 8900 is a decent-looking desktop tower with reasonable expandability</li><li>It's only $999 as part of an Oculus Rift bundle, and includes a very good graphics card</li></ul><br />**The Bad:** <ul><li>This VR-on-a-budget configuration may feel dated quickly as VR games become more ambitious</li><li>The Core i5 CPU holds this system back from being a PC-gaming workhorse</li></ul><br />**The Bottom Line:** One of the least-expensive Oculus-ready PCs, the Dell XPS 8900 Special Edition hits the required specs for virtual reality, but just barely.", new DateTime(2019, 8, 9, 9, 49, 34, 0, DateTimeKind.Unspecified), "Dell XPS 8900", "https://i.dell.com/is/image/DellContent/content/dam/global-site-design/product_images/dell_client_products/desktops/xps_desktops/xps_8930/global_spi/desktop-xps-8930-vmax-cfl-hero-504x350-ng.psd?fmt=png-alpha", true, "KSP החשמונאים, תל אביב", "An Oculus-approved, VR-ready desktop for less" },
                    { 9, 2, "**The Good:** <ul><li>The affordable Q Acoustics 3020i give smooth, rich sound in a relatively compact design.</li><li>The speakers are well built, look sweet and are available in a number of attractive finishes</li></ul><br />**The Bad:** <ul><li>Despite simplified speaker connectors, the 3020is are not suited to wall-mounting</li><li>The Elac Debut B6.2 offer better performance for the same money</li></ul>**The Bottom Line:** The Q Acoustics 3020i bookshelf speakers combine cutting-edge design with excellent sonics and are suited to systems with tight space requirements.", new DateTime(2019, 8, 9, 9, 40, 5, 0, DateTimeKind.Unspecified), "Q Acoustics 3020i", "https://www.harmonieaudio.com/wp-content/uploads/2018/03/3020leather.png", true, "KSP החשמונאים, תל אביב", "Big, smooth sound from small, affordable speakers" },
                    { 7, 2, "**The Good:**<ul><li>The sleek Bose SoundLink Plus Bluetooth speaker sounds excellent for its compact size</li><li>It has a built-in handle for easy transport and is water-resistant</li><li>Battery life is good at 16 hours</li><li>There's a threaded tripod mount on the bottom of the speaker and an integrated microphone for speakerphone calls</li></ul><br />**The Bad:** <ul><li>Expensive</li><li>The cradle that makes charging easier is an optional $30 accessory</li></ul><br />**The Bottom Line:** Bose's expensive SoundLink Plus is arguably the best-sounding Bluetooth speaker for its size.", new DateTime(2019, 8, 8, 8, 37, 0, 0, DateTimeKind.Unspecified), "Bose SoundLink Revolve+", "https://assets.bose.com/content/dam/Bose_DAM/Web/consumer_electronics/global/products/speakers/soundlink_revolve_plus_images/images/soundlink_revolve_plus_similar_speakers_revolve_1x1.psd/_jcr_content/renditions/cq5dam.web.320.320.png", true, "באג סניף וייצמן, תל אביב", "This pricey Bluetooth speaker sounds great in every direction" },
                    { 6, 2, "**The Good:** <ul><li>The Wonderboom is compact, fully waterproof, plays very loud for its size with a good amount of bass for its small size</li><li>It also floats in water, is shock resistant and has decent battery life</li><li>You can pair two Wonderbooms together to augment the sound</li></ul><br />**The Bad:** <ul><li>No speakerphone capabilities</li><li>It's slightly too bulky for travel use</li></ul><br />**The Bottom Line:** For its size, the affordable and durable UE Wonderboom is one of the fullest sounding mini Bluetooth speakers you can buy.", new DateTime(2019, 8, 8, 8, 34, 11, 0, DateTimeKind.Unspecified), "Wonderboom", "https://fgl.scene7.com/is/image/FGLSportsLtd/FGL_332751167_40_b-ue-wonderboom?bgColor=0,0,0,0&fmt=png-alpha&hei=528&resMode=sharp&qlt=85,1&op_sharpen=1", true, "KSP החשמונאים, תל אביב", "A waterproof mini Bluetooth speaker that packs a punch" },
                    { 5, 1, "**The Good:**<ul><li>The third iteration of the WH-1000X is more comfortable, sounds slightly better and features even better noise-canceling performance along with USB-C charging.</li><li>The excellent-sounding Sony WH-1000XM3 is more comfortable and 20 percent lighter than its predecessor</li><li>It offers slightly improved noise canceling and performs better as a headset for making calls</li><li>Battery life is strong, and it has some nifty extra features geared toward frequent travelers</li></ul><br />**The Bad:** <ul><li>Your ears can get a little warm inside the ear cups</li><li>I encountered some adaptive noise-canceling hiccups.</li></ul><br />**The Botom Line:** With its more comfortable fit and improved performance, the Sony WH-1000XM3 becomes the noise-canceling headphone to beat.", new DateTime(2019, 8, 8, 8, 33, 5, 0, DateTimeKind.Unspecified), "Bose QuietComfort 35 II", "https://s3-eu-west-1.amazonaws.com/htsi-ez-prod/ez/images/8/4/5/6/886548-1-eng-GB/main_4491d981-7466-48d9-97b0-50d259bc4305.png", true, "KSP סניף הרצליה מרכז", "These already excellent headphones get a touch better" },
                    { 4, 1, "**The Good:**<ul><li>The Jabra Active Elite 65t are fully sweat-resistant truly wireless earphones that fit comfortably and securely</li><li>They sound excellent, perform reliably and are great for making calls, with two microphones in each earpiece</li><li>Battery life is decent at 5 hours and the included charging case delivers two extra charges</li><li>A quick-charge feature allows you to get 1.5 hours of juice from a 15-minute charge</li></ul><br/>**The Bad:**<ul><li>The relatively tight, noise-isolating fit isn't for everyone</li><li>Motion sensor doesn't have much use at this point</li></ul><br />**The Bottom Line:**The Jabra Active Elite 65t truly wireless earphones are the best alternative to Apple's AirPods, but the stepdown non-Elite model will save you a bit of cash.", new DateTime(2019, 10, 7, 8, 31, 54, 0, DateTimeKind.Unspecified), "Jabra Elite Active 65t", "https://www.mea.jabra.com/-/media/Images/Products/Jabra-Elite-65t-Active/Color-Picker/elite_active_65t_blue.png?w=550&la=en-MEA&hash=1B8EB1D2C4E28EB578CED5A8F5FE87D12AAAB554", true, "באג סניף וייצמן, תל אביב", "These wireless headphones beat out AirPods on sound quality" },
                    { 2, 1, "**The Good:**<ul><li>The Bose Noise Cancelling Headphones 700 are very comfortable, have excellent noise canceling and work really well as a headset for making calls.</li><li>They sound better than the Quiet Comfort 35 II, are loaded with features, including the option for hands-free Alexa and Bose AR.</li><li>Noise-canceling levels are adjustable, they work without power</li><li>USB-C charging</li><li>Transparency mode</li></ul><br />**The Bad:**<ul><li>$50 to $100 more than their closest competitors</li><li>QuietComfort 35 II is slightly more comfortable</li><li>Battery life isn't as good as the of some competitors</li><li>The accompanying mobile app isn't fully baked</li></ul><br />**The Bottom Line:** While not a quantum leap forward over the QC35 IIs, the Bose Noise Cancelling Headphones 700 offers slightly better noise canceling, sound and call quality.", new DateTime(2019, 8, 7, 8, 30, 53, 0, DateTimeKind.Unspecified), "Bose Headphones 700", "https://assets.bose.com/content/dam/Bose_DAM/Web/consumer_electronics/global/better_with_bose/new_headphones/stories_hp2-0_nch700_1x1.psd/_jcr_content/renditions/cq5dam.web.320.320.png", true, "", "Top noise-canceling headphones take it up just a notch" },
                    { 29, 6, "**The Good:** <ul><li>The BlackWidow Chroma V2 has very easily programmable macro keys</li><li>It has a full suite of gaming keyboard functionality and Razer Synapse compatibility</li></ul><br />**The Bad:** <ul><li>You're really going to need to weigh those features against a hefty price tag</li></ul><br />**The Bottom Line:** The BlackWidow Chroma V2 is pretty much everything you want out of your gaming keyboard. But there are most cost effective options if you're not ensconced in the Razer ecosystem.", new DateTime(2019, 8, 11, 11, 48, 3, 0, DateTimeKind.Unspecified), "Razer BlackWidow Chroma", "https://www.gudanggaming.com/storage/store/products/razer-blackwidow-chroma-v2-gallery-02-wristrest.png", true, "KSP החשמונאים, תל אביב", "Razer BlackWidow Chroma V2 is sweet, sweet overkill" },
                    { 30, 6, "**The Good:** <ul><li>The Apple Magic Keyboard with Numeric Keypad has light, bouncy keys that are great to type with</li><li>The new number pad makes it easier to input figures or work with some creative software shortcuts</li><li>It pairs easily and lasts a long time between charges</li></ul><br />**The Bad:** <ul><li>The flat design can put strain on your wrist</li><li>The lack of backlight makes it harder to work with the keys at night</li></ul><br />**The Bottom Line:** Apple's slim, light, wireless Magic Keyboard gets a makeover, bringing back the number pad previously found in the old wired version. But it also costs more, so the standard Magic Keyboard may be better for you.", new DateTime(2019, 8, 12, 11, 51, 28, 0, DateTimeKind.Unspecified), "Apple Magic Keyboard", "https://www.ifrog.com.au/WebRoot/Store4/Shops/Ifrogs/5936/F77D/9BB7/F4EE/9ABD/AC10/004C/B3B0/shopping_ml.png", true, "iStore סניף הרצליה", "Apple's new keyboard rescues the number pad" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Author", "Content", "DatePosted", "ItemId", "Sequence" },
                values: new object[,]
                {
                    { 1, "Pikachu", "I chose this headphone, electrifying product!", new DateTime(2019, 8, 14, 8, 10, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 32, "Kim Jong Un", "Worth every dollar, very comfortable for daily usage", new DateTime(2019, 10, 20, 18, 20, 0, 0, DateTimeKind.Unspecified), 28, 32 },
                    { 31, "Trump", "Built for non-stop binge", new DateTime(2019, 10, 20, 11, 20, 0, 0, DateTimeKind.Unspecified), 27, 1 },
                    { 30, "Tom (Tom & Jery)", "The only mouse I get along with", new DateTime(2019, 10, 20, 10, 12, 0, 0, DateTimeKind.Unspecified), 26, 1 },
                    { 29, "Glenn Quagmire", "Giggity", new DateTime(2019, 10, 19, 18, 28, 0, 0, DateTimeKind.Unspecified), 25, 2 },
                    { 28, "Ronaldo", "Siiiiiii", new DateTime(2019, 10, 19, 18, 23, 0, 0, DateTimeKind.Unspecified), 25, 1 },
                    { 27, "Bibi Netanyahu", "Better than the previous generation", new DateTime(2019, 10, 19, 18, 20, 0, 0, DateTimeKind.Unspecified), 24, 1 },
                    { 26, "Batman", "Great for binging Netflix on the go", new DateTime(2019, 10, 19, 15, 43, 0, 0, DateTimeKind.Unspecified), 23, 2 },
                    { 25, "Neymar", "Flexible tablet, my favourite", new DateTime(2019, 10, 19, 15, 21, 0, 0, DateTimeKind.Unspecified), 23, 1 },
                    { 24, "Messi", "If Zlatan says its the best, it must be the best", new DateTime(2019, 10, 19, 14, 20, 0, 0, DateTimeKind.Unspecified), 21, 2 },
                    { 23, "Zlatan Ibrahimovich", "Simply the best", new DateTime(2019, 10, 19, 11, 20, 0, 0, DateTimeKind.Unspecified), 21, 1 },
                    { 22, "Shrek", "Too small for my fingers, amazing performance though", new DateTime(2019, 10, 19, 10, 20, 0, 0, DateTimeKind.Unspecified), 20, 1 },
                    { 21, "Eran Zahavi", "Best Chinese phone out there", new DateTime(2019, 10, 19, 9, 20, 0, 0, DateTimeKind.Unspecified), 19, 1 },
                    { 20, "Paul McCartney", "Love it", new DateTime(2019, 10, 18, 9, 20, 0, 0, DateTimeKind.Unspecified), 17, 2 },
                    { 19, "The Joker", "Camera is top class", new DateTime(2019, 10, 18, 8, 20, 0, 0, DateTimeKind.Unspecified), 17, 1 },
                    { 18, "Darth Vader", "I have some problems with the face recognition", new DateTime(2019, 10, 17, 10, 20, 0, 0, DateTimeKind.Unspecified), 16, 1 },
                    { 17, "Tim Cook", "Best battery of a laptop I ever seen", new DateTime(2019, 10, 17, 10, 2, 0, 0, DateTimeKind.Unspecified), 14, 3 },
                    { 16, "Madonna", "The pen is amazing addition", new DateTime(2019, 9, 17, 8, 54, 0, 0, DateTimeKind.Unspecified), 14, 2 },
                    { 2, "Bill Gates", "Amazing for such a price", new DateTime(2019, 8, 14, 8, 15, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, "Ronaldo", "The best headphones to prevent from hearing your wife", new DateTime(2019, 8, 14, 8, 20, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 4, "Jurgen Klopp", "With these heaphones I never walk alone", new DateTime(2019, 8, 14, 8, 27, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 5, "Bibi Netanyahu", "I would vote for Jabra at any day, any time", new DateTime(2019, 8, 14, 8, 48, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 6, "Anonymous", "Best on the market", new DateTime(2019, 9, 14, 9, 20, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 7, "Snoop Dogg", "This is a true wonder", new DateTime(2019, 9, 14, 9, 40, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 33, "Kanye West", "The colors are mesmerizing", new DateTime(2019, 10, 20, 18, 50, 0, 0, DateTimeKind.Unspecified), 29, 1 },
                    { 8, "Trump", "The natural choice of the white house", new DateTime(2019, 9, 15, 18, 25, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 10, "Someone", "Anyone got this and can comment if it worth the price?", new DateTime(2019, 9, 16, 19, 5, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 11, "Messi", "Elegant view, nice for big saloon", new DateTime(2019, 9, 16, 19, 20, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 12, "Eric Cartman", "Why would anyone still want to use desktops?", new DateTime(2019, 9, 16, 21, 20, 0, 0, DateTimeKind.Unspecified), 11, 1 },
                    { 13, "Bill Gates", "Innovative and well worths the price", new DateTime(2019, 9, 16, 21, 20, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 14, "Justin Beiber", "Don't buy it, I stopped my carrer music because of gaming addiction", new DateTime(2019, 9, 16, 21, 27, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 15, "Drake", "HP are the best", new DateTime(2019, 9, 17, 8, 20, 0, 0, DateTimeKind.Unspecified), 14, 1 },
                    { 9, "Ronaldo", "I bought this to my son, he loves it", new DateTime(2019, 9, 15, 18, 58, 0, 0, DateTimeKind.Unspecified), 7, 2 },
                    { 34, "Avi Biter", "Can't use my mac without this wonder", new DateTime(2019, 10, 21, 8, 20, 0, 0, DateTimeKind.Unspecified), 30, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ItemId",
                table: "Comments",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
