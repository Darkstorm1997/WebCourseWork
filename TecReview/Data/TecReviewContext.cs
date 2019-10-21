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
                Description = "Mouse, keybo",
                Color = System.Drawing.Color.SeaGreen
            });

            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    ItemId = 1,
                    CategoryId = 1,
                    Header = "Sony WH-1000XM3",
                    Summery = "If you settle only for the best",
                    DateCreated = new DateTime(2019, 10, 19, 8, 30, 52),
                    HomeImageUrl =
                        "https://www.sony.com/image/eb0062b3db03748efc7f5ca3fd82ccc5?fmt=pjpeg&bgcolor=FFFFFF&bgc=FFFFFF&wid=2515&hei=1320",
                    Location = "KSP החשמונאים, תל אביב",
                    IsShowMap = true,
                    Content = exampleContent
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

        static string exampleContent =
            "Perhaps inspired by the success of 2014's Unfriended, this mystery ventures in fresh, new directions while being superbly constructed, emotionally satisfying, and culturally relevant. David Kim becomes desperate when his 16-year-old daughter Margot disappears and an immediate police investigation leads nowhere. He soon decides to search the one place that no one else has -- Margot's laptop. Hoping to trace her digital footprints, David contacts her friends and looks at photos and videos for any possible clues to her whereabouts. , **bolds**, *\"quotes\"* and others.\r\n\r\n\r\nexample paragraph\r\n--\r\n\r\nThe statement from attorneys Debra Katz, Lisa Banks and Michael Bromwich came after a call Sunday with staff for the Senate Judiciary Committee. Kavanaugh has denied the allegations and said he wants to testify before the committee.\r\n\r\n*\"Despite actual threats to her safety and her life, Dr. Ford believes it is important for Senators to hear directly from her about the sexual assault committed against her,\"* the statement read.\r\n\r\nparagraph with image\r\n--\r\n*\"We stand with the Iranian people against the scourge of radical Islamic terrorism and express our sympathy to them at this terrible time,\"* she said Saturday.\r\n\r\nThe parade was part of nationwide celebrations in Iran to mark the 30th anniversary of the end of its eight-year war with Iraq.\r\nGunmen opened fire on armed forces marching inside a park as well as spectators who had gathered to watch the parade, Iranian armed forces spokesman Brig. Gen. Abolfazl Shekarchi told Mehr, a semi-official Iranian news agency.\r\nAll four attackers were killed during clashes with security forces, IRNA reported, citing the deputy governor-general of Khuzestan province, where the attack happened.\r\n\r\n![](https://cdn.cnn.com/cnnnext/dam/assets/180922044651-iran-parade-attack-09-22-18-exlarge-169.jpg)\r\n*Injured soldiers lie on the ground after Saturday's attack on a military parade Ahvaz, Iran.*\r\n\r\n*\"The terrorists disguised as Islamic Revolution Guards Corps and Basij (volunteer) forces opened fire to the authority and people from behind the stand during the parade,\"* said Gholam-Reza Shariati, governor of Khuzestan province, according to IRNA.\r\nKhuzestan is a province that borders Iraq and has a large ethnic Arab community, many of them Sunni. It was a major battleground during the Iran-Iraq War that killed half a million soldiers in the '80s.\r\n";
    }
}