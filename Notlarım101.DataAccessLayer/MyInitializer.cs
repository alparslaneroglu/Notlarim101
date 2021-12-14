using Notlarım101.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notlarım101.DataAccessLayer
{
    public class MyInitializer : CreateDatabaseIfNotExists<NotlarimContext>
    {
        protected override void Seed(NotlarimContext context)
        {
            //Adding Admin User...
            NotlarimUser admin = new NotlarimUser()
            {
                Name = "Alparslan",
                Surname = "EROGLU",
                Email = "furkanalparslaneroglu@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Username = "alparslaneroglu",
                Password = "123456",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "alparslaneroglu"
            };
            //Adding Standart  User...
            NotlarimUser standartUser = new NotlarimUser()
            {
                Name = "Oguzhan",
                Surname = "EROGLU",
                Email = "oguzhaneroglu@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "oguzhaneroglu",
                Password = "654321",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "oguzhaneroglu"
            };
            context.NotlarimUsers.Add(admin);
            context.NotlarimUsers.Add(standartUser);

            for (int i = 0; i < 8; i++)
            {
                NotlarimUser user = new NotlarimUser()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = false,
                    Username = $"user-{i}", // User 0 , 1 ,2 diye ilerliyor.
                    Password = "654321",
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now), // 1 yıl içerisinde rastele bir tarih al.
                    ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    ModifiedUsername = $"user-{i}",
                };
                context.NotlarimUsers.Add(user);
            }

            context.SaveChanges();

            //User list for using..
            List<NotlarimUser> userList = context.NotlarimUsers.ToList();

            //Adding fake categories..
            for (int i = 0; i < 10; i++)
            {
                Category cat = new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "alparslaneroglu" // kategoriyi admin oluşturur.
                };
                context.Categories.Add(cat);

                //Adding fake notes...
                for (int k = 0; k < FakeData.NumberData.GetNumber(5 , 9); k++)
                {
                    NotlarimUser owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];
                    Note note = new Note()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        IsDraft = false, //yayına verilsinmi verilmesinmi taslak olarakda kalabilir.
                        LikeCount = FakeData.NumberData.GetNumber(1, 9),
                        Owner = owner, // Tabloda Id olarak gözükür fakat NotlarimUser  da bütün satırı ister(Bütün kayıta ulaştığı için aşağıda Username ni de çağırabiliyoruz.).Yukarıdaki oluşturduğumuz list den random alıyoruz.
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUsername = owner.Username

                    };
                    cat.Notes.Add(note);

                    //Adding fake comments...
                    for (int j = 0; j < FakeData.NumberData.GetNumber(3, 5); j++)
                    {
                        NotlarimUser comment_owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];
                        Comment comment = new Comment()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Owner = comment_owner,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUsername = comment_owner.Username
                        };
                        note.Comments.Add(comment);
                    }
                    for (int m = 0; m < note.LikeCount; m++)
                    {

                        Liked liked = new Liked()
                        {
                            LikedUser = userList[m]
                        };
                        note.Likes.Add(liked);
                    }
                }
            }
            context.SaveChanges();
        }
    }
}
