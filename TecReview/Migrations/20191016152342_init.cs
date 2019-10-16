using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TecReview.Migrations
{
    public partial class init : Migration
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
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
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
                    Header = table.Column<string>(nullable: true),
                    Summery = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    HomeImageUrl = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
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
                    { 1, -15132304, "World wide news", "World" },
                    { 2, -7667573, "Debates and conflicts", "Politics" },
                    { 3, -16751616, "Trade, commerce and money", "Business" },
                    { 4, -7667712, "And its a score!", "Sports" },
                    { 5, -2354116, "Music, movies and the starts", "Culture" },
                    { 6, -13726889, "I Think...", "Opinions" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CategoryId", "Content", "DateCreated", "Header", "HomeImageUrl", "IsShowMap", "Location", "Summery" },
                values: new object[,]
                {
                    { 1, 1, @"Perhaps inspired by the success of 2014's Unfriended, this mystery ventures in fresh, new directions while being superbly constructed, emotionally satisfying, and culturally relevant. David Kim becomes desperate when his 16-year-old daughter Margot disappears and an immediate police investigation leads nowhere. He soon decides to search the one place that no one else has -- Margot's laptop. Hoping to trace her digital footprints, David contacts her friends and looks at photos and videos for any possible clues to her whereabouts. , **bolds**, *""quotes""* and others.


                example paragraph
                --

                The statement from attorneys Debra Katz, Lisa Banks and Michael Bromwich came after a call Sunday with staff for the Senate Judiciary Committee. Kavanaugh has denied the allegations and said he wants to testify before the committee.

                *""Despite actual threats to her safety and her life, Dr. Ford believes it is important for Senators to hear directly from her about the sexual assault committed against her,""* the statement read.

                paragraph with image
                --
                *""We stand with the Iranian people against the scourge of radical Islamic terrorism and express our sympathy to them at this terrible time,""* she said Saturday.

                The parade was part of nationwide celebrations in Iran to mark the 30th anniversary of the end of its eight-year war with Iraq.
                Gunmen opened fire on armed forces marching inside a park as well as spectators who had gathered to watch the parade, Iranian armed forces spokesman Brig. Gen. Abolfazl Shekarchi told Mehr, a semi-official Iranian news agency.
                All four attackers were killed during clashes with security forces, IRNA reported, citing the deputy governor-general of Khuzestan province, where the attack happened.

                ![](https://cdn.cnn.com/cnnnext/dam/assets/180922044651-iran-parade-attack-09-22-18-exlarge-169.jpg)
                *Injured soldiers lie on the ground after Saturday's attack on a military parade Ahvaz, Iran.*

                *""The terrorists disguised as Islamic Revolution Guards Corps and Basij (volunteer) forces opened fire to the authority and people from behind the stand during the parade,""* said Gholam-Reza Shariati, governor of Khuzestan province, according to IRNA.
                Khuzestan is a province that borders Iraq and has a large ethnic Arab community, many of them Sunni. It was a major battleground during the Iran-Iraq War that killed half a million soldiers in the '80s.
                ", new DateTime(2018, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), "Iran blames US and Saudi Arabia for terror attack", "https://images.jpost.com/image/upload/f_auto,fl_lossy/t_Item2016_ControlFaceDetect/427101", true, "טהרן, אירן", "Iran blames the US and Saudi Arabia for military parade terror attack" },
                    { 3, 1, @"Perhaps inspired by the success of 2014's Unfriended, this mystery ventures in fresh, new directions while being superbly constructed, emotionally satisfying, and culturally relevant. David Kim becomes desperate when his 16-year-old daughter Margot disappears and an immediate police investigation leads nowhere. He soon decides to search the one place that no one else has -- Margot's laptop. Hoping to trace her digital footprints, David contacts her friends and looks at photos and videos for any possible clues to her whereabouts. , **bolds**, *""quotes""* and others.


                example paragraph
                --

                The statement from attorneys Debra Katz, Lisa Banks and Michael Bromwich came after a call Sunday with staff for the Senate Judiciary Committee. Kavanaugh has denied the allegations and said he wants to testify before the committee.

                *""Despite actual threats to her safety and her life, Dr. Ford believes it is important for Senators to hear directly from her about the sexual assault committed against her,""* the statement read.

                paragraph with image
                --
                *""We stand with the Iranian people against the scourge of radical Islamic terrorism and express our sympathy to them at this terrible time,""* she said Saturday.

                The parade was part of nationwide celebrations in Iran to mark the 30th anniversary of the end of its eight-year war with Iraq.
                Gunmen opened fire on armed forces marching inside a park as well as spectators who had gathered to watch the parade, Iranian armed forces spokesman Brig. Gen. Abolfazl Shekarchi told Mehr, a semi-official Iranian news agency.
                All four attackers were killed during clashes with security forces, IRNA reported, citing the deputy governor-general of Khuzestan province, where the attack happened.

                ![](https://cdn.cnn.com/cnnnext/dam/assets/180922044651-iran-parade-attack-09-22-18-exlarge-169.jpg)
                *Injured soldiers lie on the ground after Saturday's attack on a military parade Ahvaz, Iran.*

                *""The terrorists disguised as Islamic Revolution Guards Corps and Basij (volunteer) forces opened fire to the authority and people from behind the stand during the parade,""* said Gholam-Reza Shariati, governor of Khuzestan province, according to IRNA.
                Khuzestan is a province that borders Iraq and has a large ethnic Arab community, many of them Sunni. It was a major battleground during the Iran-Iraq War that killed half a million soldiers in the '80s.
                ", new DateTime(2018, 3, 7, 2, 22, 23, 0, DateTimeKind.Unspecified), "Russia: We were mislead by israel", "https://images.haarets.co.il/image/upload/w_2184,h_1270,x_0,y_75,c_crop,g_north_west/w_857,h_482,q_auto,c_fill,f_auto/fl_any_format.preserve_transparency.progressive:none/v1537691679/1.6494059.1232180831.jpg", true, "תל אביב, ישראל", "Maj. Gen. Igor Konashenkov, chief spokesman for the Russian Ministry of Defense, said that Israeli strikes in Syria put Russian forces there at risk." },
                    { 4, 1, @"Perhaps inspired by the success of 2014's Unfriended, this mystery ventures in fresh, new directions while being superbly constructed, emotionally satisfying, and culturally relevant. David Kim becomes desperate when his 16-year-old daughter Margot disappears and an immediate police investigation leads nowhere. He soon decides to search the one place that no one else has -- Margot's laptop. Hoping to trace her digital footprints, David contacts her friends and looks at photos and videos for any possible clues to her whereabouts. , **bolds**, *""quotes""* and others.


                example paragraph
                --

                The statement from attorneys Debra Katz, Lisa Banks and Michael Bromwich came after a call Sunday with staff for the Senate Judiciary Committee. Kavanaugh has denied the allegations and said he wants to testify before the committee.

                *""Despite actual threats to her safety and her life, Dr. Ford believes it is important for Senators to hear directly from her about the sexual assault committed against her,""* the statement read.

                paragraph with image
                --
                *""We stand with the Iranian people against the scourge of radical Islamic terrorism and express our sympathy to them at this terrible time,""* she said Saturday.

                The parade was part of nationwide celebrations in Iran to mark the 30th anniversary of the end of its eight-year war with Iraq.
                Gunmen opened fire on armed forces marching inside a park as well as spectators who had gathered to watch the parade, Iranian armed forces spokesman Brig. Gen. Abolfazl Shekarchi told Mehr, a semi-official Iranian news agency.
                All four attackers were killed during clashes with security forces, IRNA reported, citing the deputy governor-general of Khuzestan province, where the attack happened.

                ![](https://cdn.cnn.com/cnnnext/dam/assets/180922044651-iran-parade-attack-09-22-18-exlarge-169.jpg)
                *Injured soldiers lie on the ground after Saturday's attack on a military parade Ahvaz, Iran.*

                *""The terrorists disguised as Islamic Revolution Guards Corps and Basij (volunteer) forces opened fire to the authority and people from behind the stand during the parade,""* said Gholam-Reza Shariati, governor of Khuzestan province, according to IRNA.
                Khuzestan is a province that borders Iraq and has a large ethnic Arab community, many of them Sunni. It was a major battleground during the Iran-Iraq War that killed half a million soldiers in the '80s.
                ", new DateTime(2018, 10, 6, 11, 10, 2, 0, DateTimeKind.Unspecified), "Israel rejects russian claims: IAF did not hide behind russian plane", "https://www.jpost.com/HttpHandlers/ShowImage.ashx?id=350908&w=898&h=628", false, "תל אביב, ישראל", "The IAF did not hide behind any plane and Israeli fighter jets were in Israeli airspace when the Syrians attacked the Russian plane" },
                    { 5, 1, @"Perhaps inspired by the success of 2014's Unfriended, this mystery ventures in fresh, new directions while being superbly constructed, emotionally satisfying, and culturally relevant. David Kim becomes desperate when his 16-year-old daughter Margot disappears and an immediate police investigation leads nowhere. He soon decides to search the one place that no one else has -- Margot's laptop. Hoping to trace her digital footprints, David contacts her friends and looks at photos and videos for any possible clues to her whereabouts. , **bolds**, *""quotes""* and others.


                example paragraph
                --

                The statement from attorneys Debra Katz, Lisa Banks and Michael Bromwich came after a call Sunday with staff for the Senate Judiciary Committee. Kavanaugh has denied the allegations and said he wants to testify before the committee.

                *""Despite actual threats to her safety and her life, Dr. Ford believes it is important for Senators to hear directly from her about the sexual assault committed against her,""* the statement read.

                paragraph with image
                --
                *""We stand with the Iranian people against the scourge of radical Islamic terrorism and express our sympathy to them at this terrible time,""* she said Saturday.

                The parade was part of nationwide celebrations in Iran to mark the 30th anniversary of the end of its eight-year war with Iraq.
                Gunmen opened fire on armed forces marching inside a park as well as spectators who had gathered to watch the parade, Iranian armed forces spokesman Brig. Gen. Abolfazl Shekarchi told Mehr, a semi-official Iranian news agency.
                All four attackers were killed during clashes with security forces, IRNA reported, citing the deputy governor-general of Khuzestan province, where the attack happened.

                ![](https://cdn.cnn.com/cnnnext/dam/assets/180922044651-iran-parade-attack-09-22-18-exlarge-169.jpg)
                *Injured soldiers lie on the ground after Saturday's attack on a military parade Ahvaz, Iran.*

                *""The terrorists disguised as Islamic Revolution Guards Corps and Basij (volunteer) forces opened fire to the authority and people from behind the stand during the parade,""* said Gholam-Reza Shariati, governor of Khuzestan province, according to IRNA.
                Khuzestan is a province that borders Iraq and has a large ethnic Arab community, many of them Sunni. It was a major battleground during the Iran-Iraq War that killed half a million soldiers in the '80s.
                ", new DateTime(2017, 12, 11, 11, 10, 2, 0, DateTimeKind.Unspecified), "U.S. Terror victomsm ask Trump: bar Abbas", "https://images.jpost.com/image/upload/f_auto,fl_lossy/t_Item2016_ControlFaceDetect/428957", false, "תל אביב, ישראל", "The family members called the decision to allow Abbas’s entry to the US \"a slap in the face to every American who has suffered from terror.\"" },
                    { 2, 2, @"Perhaps inspired by the success of 2014's Unfriended, this mystery ventures in fresh, new directions while being superbly constructed, emotionally satisfying, and culturally relevant. David Kim becomes desperate when his 16-year-old daughter Margot disappears and an immediate police investigation leads nowhere. He soon decides to search the one place that no one else has -- Margot's laptop. Hoping to trace her digital footprints, David contacts her friends and looks at photos and videos for any possible clues to her whereabouts. , **bolds**, *""quotes""* and others.


                example paragraph
                --

                The statement from attorneys Debra Katz, Lisa Banks and Michael Bromwich came after a call Sunday with staff for the Senate Judiciary Committee. Kavanaugh has denied the allegations and said he wants to testify before the committee.

                *""Despite actual threats to her safety and her life, Dr. Ford believes it is important for Senators to hear directly from her about the sexual assault committed against her,""* the statement read.

                paragraph with image
                --
                *""We stand with the Iranian people against the scourge of radical Islamic terrorism and express our sympathy to them at this terrible time,""* she said Saturday.

                The parade was part of nationwide celebrations in Iran to mark the 30th anniversary of the end of its eight-year war with Iraq.
                Gunmen opened fire on armed forces marching inside a park as well as spectators who had gathered to watch the parade, Iranian armed forces spokesman Brig. Gen. Abolfazl Shekarchi told Mehr, a semi-official Iranian news agency.
                All four attackers were killed during clashes with security forces, IRNA reported, citing the deputy governor-general of Khuzestan province, where the attack happened.

                ![](https://cdn.cnn.com/cnnnext/dam/assets/180922044651-iran-parade-attack-09-22-18-exlarge-169.jpg)
                *Injured soldiers lie on the ground after Saturday's attack on a military parade Ahvaz, Iran.*

                *""The terrorists disguised as Islamic Revolution Guards Corps and Basij (volunteer) forces opened fire to the authority and people from behind the stand during the parade,""* said Gholam-Reza Shariati, governor of Khuzestan province, according to IRNA.
                Khuzestan is a province that borders Iraq and has a large ethnic Arab community, many of them Sunni. It was a major battleground during the Iran-Iraq War that killed half a million soldiers in the '80s.
                ", new DateTime(2018, 8, 7, 5, 22, 23, 0, DateTimeKind.Unspecified), "Gilad Erdan: Israel making progress against Terror", "https://images.jpost.com/image/upload/f_auto,fl_lossy/t_TopStoryMainImageFaceDetect/429944", false, "תל אביב, ישראל", "Erdan is responsible for the fight against BDS in the Strategic Affairs Ministry, and the steps he has taken in that battle are controversial and unconventional." },
                    { 10, 3, @"Perhaps inspired by the success of 2014's Unfriended, this mystery ventures in fresh, new directions while being superbly constructed, emotionally satisfying, and culturally relevant. David Kim becomes desperate when his 16-year-old daughter Margot disappears and an immediate police investigation leads nowhere. He soon decides to search the one place that no one else has -- Margot's laptop. Hoping to trace her digital footprints, David contacts her friends and looks at photos and videos for any possible clues to her whereabouts. , **bolds**, *""quotes""* and others.


                example paragraph
                --

                The statement from attorneys Debra Katz, Lisa Banks and Michael Bromwich came after a call Sunday with staff for the Senate Judiciary Committee. Kavanaugh has denied the allegations and said he wants to testify before the committee.

                *""Despite actual threats to her safety and her life, Dr. Ford believes it is important for Senators to hear directly from her about the sexual assault committed against her,""* the statement read.

                paragraph with image
                --
                *""We stand with the Iranian people against the scourge of radical Islamic terrorism and express our sympathy to them at this terrible time,""* she said Saturday.

                The parade was part of nationwide celebrations in Iran to mark the 30th anniversary of the end of its eight-year war with Iraq.
                Gunmen opened fire on armed forces marching inside a park as well as spectators who had gathered to watch the parade, Iranian armed forces spokesman Brig. Gen. Abolfazl Shekarchi told Mehr, a semi-official Iranian news agency.
                All four attackers were killed during clashes with security forces, IRNA reported, citing the deputy governor-general of Khuzestan province, where the attack happened.

                ![](https://cdn.cnn.com/cnnnext/dam/assets/180922044651-iran-parade-attack-09-22-18-exlarge-169.jpg)
                *Injured soldiers lie on the ground after Saturday's attack on a military parade Ahvaz, Iran.*

                *""The terrorists disguised as Islamic Revolution Guards Corps and Basij (volunteer) forces opened fire to the authority and people from behind the stand during the parade,""* said Gholam-Reza Shariati, governor of Khuzestan province, according to IRNA.
                Khuzestan is a province that borders Iraq and has a large ethnic Arab community, many of them Sunni. It was a major battleground during the Iran-Iraq War that killed half a million soldiers in the '80s.
                ", new DateTime(2018, 8, 6, 11, 10, 2, 0, DateTimeKind.Unspecified), "Comcast outbids 21st Century Fox for Sky", "https://i.cdn.turner.com/money/dam/assets/180920115724-comcast-fox-sky-780x439.jpg", false, "תל אביב, ישראל", "American cable giant Comcast lodged a winning bid of about $40 billion (£30.6 billion) for Sky following a rare, three round auction managed by UK's Takeover Panel" },
                    { 11, 3, @"Perhaps inspired by the success of 2014's Unfriended, this mystery ventures in fresh, new directions while being superbly constructed, emotionally satisfying, and culturally relevant. David Kim becomes desperate when his 16-year-old daughter Margot disappears and an immediate police investigation leads nowhere. He soon decides to search the one place that no one else has -- Margot's laptop. Hoping to trace her digital footprints, David contacts her friends and looks at photos and videos for any possible clues to her whereabouts. , **bolds**, *""quotes""* and others.


                example paragraph
                --

                The statement from attorneys Debra Katz, Lisa Banks and Michael Bromwich came after a call Sunday with staff for the Senate Judiciary Committee. Kavanaugh has denied the allegations and said he wants to testify before the committee.

                *""Despite actual threats to her safety and her life, Dr. Ford believes it is important for Senators to hear directly from her about the sexual assault committed against her,""* the statement read.

                paragraph with image
                --
                *""We stand with the Iranian people against the scourge of radical Islamic terrorism and express our sympathy to them at this terrible time,""* she said Saturday.

                The parade was part of nationwide celebrations in Iran to mark the 30th anniversary of the end of its eight-year war with Iraq.
                Gunmen opened fire on armed forces marching inside a park as well as spectators who had gathered to watch the parade, Iranian armed forces spokesman Brig. Gen. Abolfazl Shekarchi told Mehr, a semi-official Iranian news agency.
                All four attackers were killed during clashes with security forces, IRNA reported, citing the deputy governor-general of Khuzestan province, where the attack happened.

                ![](https://cdn.cnn.com/cnnnext/dam/assets/180922044651-iran-parade-attack-09-22-18-exlarge-169.jpg)
                *Injured soldiers lie on the ground after Saturday's attack on a military parade Ahvaz, Iran.*

                *""The terrorists disguised as Islamic Revolution Guards Corps and Basij (volunteer) forces opened fire to the authority and people from behind the stand during the parade,""* said Gholam-Reza Shariati, governor of Khuzestan province, according to IRNA.
                Khuzestan is a province that borders Iraq and has a large ethnic Arab community, many of them Sunni. It was a major battleground during the Iran-Iraq War that killed half a million soldiers in the '80s.
                ", new DateTime(2018, 8, 6, 10, 10, 2, 0, DateTimeKind.Unspecified), "BMW vision's for a self-driving electric car", "https://i.cdn.turner.com/money/dam/assets/180913172656-bmw-inext-780x439.jpg", false, "תל אביב, ישראל", "BMW has unveiled its vision for a self-driving electric crossover SUV and, if it actually ends up being a lot like the concept." },
                    { 6, 5, @"Perhaps inspired by the success of 2014's Unfriended, this mystery ventures in fresh, new directions while being superbly constructed, emotionally satisfying, and culturally relevant. David Kim becomes desperate when his 16-year-old daughter Margot disappears and an immediate police investigation leads nowhere. He soon decides to search the one place that no one else has -- Margot's laptop. Hoping to trace her digital footprints, David contacts her friends and looks at photos and videos for any possible clues to her whereabouts. , **bolds**, *""quotes""* and others.


                example paragraph
                --

                The statement from attorneys Debra Katz, Lisa Banks and Michael Bromwich came after a call Sunday with staff for the Senate Judiciary Committee. Kavanaugh has denied the allegations and said he wants to testify before the committee.

                *""Despite actual threats to her safety and her life, Dr. Ford believes it is important for Senators to hear directly from her about the sexual assault committed against her,""* the statement read.

                paragraph with image
                --
                *""We stand with the Iranian people against the scourge of radical Islamic terrorism and express our sympathy to them at this terrible time,""* she said Saturday.

                The parade was part of nationwide celebrations in Iran to mark the 30th anniversary of the end of its eight-year war with Iraq.
                Gunmen opened fire on armed forces marching inside a park as well as spectators who had gathered to watch the parade, Iranian armed forces spokesman Brig. Gen. Abolfazl Shekarchi told Mehr, a semi-official Iranian news agency.
                All four attackers were killed during clashes with security forces, IRNA reported, citing the deputy governor-general of Khuzestan province, where the attack happened.

                ![](https://cdn.cnn.com/cnnnext/dam/assets/180922044651-iran-parade-attack-09-22-18-exlarge-169.jpg)
                *Injured soldiers lie on the ground after Saturday's attack on a military parade Ahvaz, Iran.*

                *""The terrorists disguised as Islamic Revolution Guards Corps and Basij (volunteer) forces opened fire to the authority and people from behind the stand during the parade,""* said Gholam-Reza Shariati, governor of Khuzestan province, according to IRNA.
                Khuzestan is a province that borders Iraq and has a large ethnic Arab community, many of them Sunni. It was a major battleground during the Iran-Iraq War that killed half a million soldiers in the '80s.
                ", new DateTime(2017, 3, 8, 11, 10, 2, 0, DateTimeKind.Unspecified), "Trails and Tribulations of Eurovision 2019, What to expect next?", "https://images.jpost.com/image/upload/f_auto,fl_lossy/t_Item2016_ControlFaceDetect/429094", false, "תל אביב, ישראל", "For the next eight months, squabbles over politics, money and religion are bound to plague the upcoming Eurovision. But which arguments should be taken seriously?" },
                    { 7, 5, @"Perhaps inspired by the success of 2014's Unfriended, this mystery ventures in fresh, new directions while being superbly constructed, emotionally satisfying, and culturally relevant. David Kim becomes desperate when his 16-year-old daughter Margot disappears and an immediate police investigation leads nowhere. He soon decides to search the one place that no one else has -- Margot's laptop. Hoping to trace her digital footprints, David contacts her friends and looks at photos and videos for any possible clues to her whereabouts. , **bolds**, *""quotes""* and others.


                example paragraph
                --

                The statement from attorneys Debra Katz, Lisa Banks and Michael Bromwich came after a call Sunday with staff for the Senate Judiciary Committee. Kavanaugh has denied the allegations and said he wants to testify before the committee.

                *""Despite actual threats to her safety and her life, Dr. Ford believes it is important for Senators to hear directly from her about the sexual assault committed against her,""* the statement read.

                paragraph with image
                --
                *""We stand with the Iranian people against the scourge of radical Islamic terrorism and express our sympathy to them at this terrible time,""* she said Saturday.

                The parade was part of nationwide celebrations in Iran to mark the 30th anniversary of the end of its eight-year war with Iraq.
                Gunmen opened fire on armed forces marching inside a park as well as spectators who had gathered to watch the parade, Iranian armed forces spokesman Brig. Gen. Abolfazl Shekarchi told Mehr, a semi-official Iranian news agency.
                All four attackers were killed during clashes with security forces, IRNA reported, citing the deputy governor-general of Khuzestan province, where the attack happened.

                ![](https://cdn.cnn.com/cnnnext/dam/assets/180922044651-iran-parade-attack-09-22-18-exlarge-169.jpg)
                *Injured soldiers lie on the ground after Saturday's attack on a military parade Ahvaz, Iran.*

                *""The terrorists disguised as Islamic Revolution Guards Corps and Basij (volunteer) forces opened fire to the authority and people from behind the stand during the parade,""* said Gholam-Reza Shariati, governor of Khuzestan province, according to IRNA.
                Khuzestan is a province that borders Iraq and has a large ethnic Arab community, many of them Sunni. It was a major battleground during the Iran-Iraq War that killed half a million soldiers in the '80s.
                ", new DateTime(2018, 10, 30, 11, 10, 2, 0, DateTimeKind.Unspecified), "Livinng out the Baha'i: A journy to Israel", "https://images.jpost.com/image/upload/f_auto,fl_lossy/t_Item2016_ControlFaceDetect/429990", false, "תל אביב, ישראל", "More than a million people visit the gardens every year. Apart from being at the holiest site of his faith..." },
                    { 8, 5, @"Perhaps inspired by the success of 2014's Unfriended, this mystery ventures in fresh, new directions while being superbly constructed, emotionally satisfying, and culturally relevant. David Kim becomes desperate when his 16-year-old daughter Margot disappears and an immediate police investigation leads nowhere. He soon decides to search the one place that no one else has -- Margot's laptop. Hoping to trace her digital footprints, David contacts her friends and looks at photos and videos for any possible clues to her whereabouts. , **bolds**, *""quotes""* and others.


                example paragraph
                --

                The statement from attorneys Debra Katz, Lisa Banks and Michael Bromwich came after a call Sunday with staff for the Senate Judiciary Committee. Kavanaugh has denied the allegations and said he wants to testify before the committee.

                *""Despite actual threats to her safety and her life, Dr. Ford believes it is important for Senators to hear directly from her about the sexual assault committed against her,""* the statement read.

                paragraph with image
                --
                *""We stand with the Iranian people against the scourge of radical Islamic terrorism and express our sympathy to them at this terrible time,""* she said Saturday.

                The parade was part of nationwide celebrations in Iran to mark the 30th anniversary of the end of its eight-year war with Iraq.
                Gunmen opened fire on armed forces marching inside a park as well as spectators who had gathered to watch the parade, Iranian armed forces spokesman Brig. Gen. Abolfazl Shekarchi told Mehr, a semi-official Iranian news agency.
                All four attackers were killed during clashes with security forces, IRNA reported, citing the deputy governor-general of Khuzestan province, where the attack happened.

                ![](https://cdn.cnn.com/cnnnext/dam/assets/180922044651-iran-parade-attack-09-22-18-exlarge-169.jpg)
                *Injured soldiers lie on the ground after Saturday's attack on a military parade Ahvaz, Iran.*

                *""The terrorists disguised as Islamic Revolution Guards Corps and Basij (volunteer) forces opened fire to the authority and people from behind the stand during the parade,""* said Gholam-Reza Shariati, governor of Khuzestan province, according to IRNA.
                Khuzestan is a province that borders Iraq and has a large ethnic Arab community, many of them Sunni. It was a major battleground during the Iran-Iraq War that killed half a million soldiers in the '80s.
                ", new DateTime(2018, 9, 6, 11, 10, 2, 0, DateTimeKind.Unspecified), "Highlights: Texas snaps 4-game skid to No. 17 TCU", "https://img-s-msn-com.akamaized.net/tenant/amp/entityid/AAAuljC.img?h=170&w=300&m=6&q=60&u=t&o=t&l=f&f=jpg&x=585&y=345", false, "תל אביב, ישראל", "Finland has produced more Formula One champions per capita than any other country in the world" },
                    { 9, 6, @"Perhaps inspired by the success of 2014's Unfriended, this mystery ventures in fresh, new directions while being superbly constructed, emotionally satisfying, and culturally relevant. David Kim becomes desperate when his 16-year-old daughter Margot disappears and an immediate police investigation leads nowhere. He soon decides to search the one place that no one else has -- Margot's laptop. Hoping to trace her digital footprints, David contacts her friends and looks at photos and videos for any possible clues to her whereabouts. , **bolds**, *""quotes""* and others.


                example paragraph
                --

                The statement from attorneys Debra Katz, Lisa Banks and Michael Bromwich came after a call Sunday with staff for the Senate Judiciary Committee. Kavanaugh has denied the allegations and said he wants to testify before the committee.

                *""Despite actual threats to her safety and her life, Dr. Ford believes it is important for Senators to hear directly from her about the sexual assault committed against her,""* the statement read.

                paragraph with image
                --
                *""We stand with the Iranian people against the scourge of radical Islamic terrorism and express our sympathy to them at this terrible time,""* she said Saturday.

                The parade was part of nationwide celebrations in Iran to mark the 30th anniversary of the end of its eight-year war with Iraq.
                Gunmen opened fire on armed forces marching inside a park as well as spectators who had gathered to watch the parade, Iranian armed forces spokesman Brig. Gen. Abolfazl Shekarchi told Mehr, a semi-official Iranian news agency.
                All four attackers were killed during clashes with security forces, IRNA reported, citing the deputy governor-general of Khuzestan province, where the attack happened.

                ![](https://cdn.cnn.com/cnnnext/dam/assets/180922044651-iran-parade-attack-09-22-18-exlarge-169.jpg)
                *Injured soldiers lie on the ground after Saturday's attack on a military parade Ahvaz, Iran.*

                *""The terrorists disguised as Islamic Revolution Guards Corps and Basij (volunteer) forces opened fire to the authority and people from behind the stand during the parade,""* said Gholam-Reza Shariati, governor of Khuzestan province, according to IRNA.
                Khuzestan is a province that borders Iraq and has a large ethnic Arab community, many of them Sunni. It was a major battleground during the Iran-Iraq War that killed half a million soldiers in the '80s.
                ", new DateTime(2018, 9, 7, 11, 10, 2, 0, DateTimeKind.Unspecified), "Russia is still attacking the US and trying to help Trump", "https://img-s-msn-com.akamaized.net/tenant/amp/entityid/AAAuljC.img?h=170&w=300&m=6&q=60&u=t&o=t&l=f&f=jpg&x=585&y=345", false, "תל אביב, ישראל", "Microsoft's revelation of yet another Russian operation assaulting democratic institutions -- including conservative think tanks that disagree with President Trump -- proves that Vladimir Putin is still trying to help Trump, writes Frida Ghitis." }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Author", "Content", "DatePosted", "ItemId", "Sequence" },
                values: new object[] { 1, "The one who knows", "Example content for an example comment", new DateTime(2018, 8, 2, 8, 10, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Author", "Content", "DatePosted", "ItemId", "Sequence" },
                values: new object[] { 2, "Voldemort", "Multi line comment! I think this is an example comment", new DateTime(2018, 8, 16, 9, 10, 0, 0, DateTimeKind.Unspecified), 1, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "Author", "Content", "DatePosted", "ItemId", "Sequence" },
                values: new object[] { 3, "Jimmi", "Example content for an example comment", new DateTime(2018, 9, 2, 8, 0, 15, 0, DateTimeKind.Unspecified), 1, 3 });

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
